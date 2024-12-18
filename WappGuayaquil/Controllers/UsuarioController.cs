using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrBancoGuayaquilDb;
using PrBancoGuayaquilDto;
using WappGuayaquil.Utilities;

namespace WappGuayaquil.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly PrBancoGuayaquilContext _prBancoGuayaquilContext;
        private readonly Utilidades _utilidades;

        public UsuarioController(PrBancoGuayaquilContext prBancoGuayaquilContext, Utilidades utilidades)
        {
            _prBancoGuayaquilContext = prBancoGuayaquilContext;
            _utilidades = utilidades;
        }


        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] PbgUsuarioEDto pbgUsuarioEDto)
        {
            try
            {
                //recupero los datos del usuario
                PbgUsuario usuario = new PbgUsuario
                {
                    Usuario = pbgUsuarioEDto.Usuario,
                    Pass = _utilidades.encriptarSHA256(pbgUsuarioEDto.Pass)
                };

                // paso los datos del usuario
                _prBancoGuayaquilContext.PbgUsuario.Add(usuario);
                //guardo los datos en DB
                await _prBancoGuayaquilContext.SaveChangesAsync();

                if (usuario.Identificador != 0)
                    return StatusCode(StatusCodes.Status200OK, new { isSuccess = true });
                else
                    return StatusCode(StatusCodes.Status200OK, new { isSuccess = false });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = false });
            }
        }


        // HttpGet: metodo de busqueda para logeo del usuario
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult> Login(PbgUsuarioEDto usuario)
        {
            
            try
            {
                // Llama al método que ejecuta el procedimiento almacenado y pasa los parámetros
                var usuarioregistrado = await _prBancoGuayaquilContext.PbgUsuario
                    .Where(u => u.Usuario.Contains(usuario.Usuario) && u.Pass == _utilidades.encriptarSHA256(usuario.Pass)) // Filtra por usuario y contraseña
                    .Select(u => new PbgUsuarioSDto
                    {
                        Identificador = u.Identificador,
                        Usuario = u.Usuario,
                        FechaCreacion = u.FechaCreacion
                    }).FirstOrDefaultAsync();

                if (usuarioregistrado == null)
                    return StatusCode(StatusCodes.Status200OK, new { isSuccess = false, token = "" });
                else
                    return StatusCode(StatusCodes.Status200OK, new { isSuccess = true, token = _utilidades.generarJWT(usuarioregistrado) });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = false, token = "" });
            }
            
        }
    }
}
