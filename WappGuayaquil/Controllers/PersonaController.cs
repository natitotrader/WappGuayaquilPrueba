using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrBancoGuayaquilDb;
using PrBancoGuayaquilDto;

namespace WappGuayaquil.Controllers
{

    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class PersonaController : ControllerBase
    {

        private readonly PrBancoGuayaquilContext _prBancoGuayaquilContext;
        public PersonaController(PrBancoGuayaquilContext prBancoGuayaquilContext)
        {
            _prBancoGuayaquilContext = prBancoGuayaquilContext;
        }

        // Post: Metodo para guardar una nueva persona
        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] PbgPersonaEDto personaEsDto)
        {

            try
            {
                //recupero los datos de la persona
                PbgPersona persona = new PbgPersona
                {
                    Nombre = personaEsDto.Nombre,
                    Apellido = personaEsDto.Apellido,
                    TipoIdentificacion = personaEsDto.TipoIdentificacion,
                    NumeroIdentificacion = personaEsDto.NumeroIdentificacion,
                    Email = personaEsDto.Email,

                };

                // paso los datos de la persona
                _prBancoGuayaquilContext.PbgPersona.Add(persona);
                //guardo los datos en DB
                await _prBancoGuayaquilContext.SaveChangesAsync();

                if (persona.Identificador != 0)
                    return StatusCode(StatusCodes.Status200OK, new { isSuccess = true });
                else
                    return StatusCode(StatusCodes.Status200OK, new { isSuccess = false });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = false });
            }

        }


        // HttpGet: metodo de busqueda por parametro
        [HttpGet]
        [Route("ConsultaPersonas")]
        public async Task<ActionResult<List<sp_consulta_personaResultDto>>> ConsultaPersonas(PbgPersonaConsultaEDto pbgPersonaConsultaEDto)
        {
            List<sp_consulta_personaResultDto> respuestaItem = new List<sp_consulta_personaResultDto>();  // Inicializar con una lista vacía

            try
            {
                // Llama al método que ejecuta el procedimiento almacenado y pasa los parámetros
                var personas = await _prBancoGuayaquilContext.GetProcedures().sp_consulta_personaAsync(pbgPersonaConsultaEDto.CondicionBusqueda, pbgPersonaConsultaEDto.DatoBusqueda);

                // Verifica si se obtuvo algún resultado
                if (personas != null)
                {
                    // Aquí, mapeamos el resultado del procedimiento almacenado al DTO
                    respuestaItem = personas.Select(persona => new sp_consulta_personaResultDto
                    {
                        Identificador = persona.Identificador,
                        Nombre = persona.Nombre,
                        Apellido = persona.Apellido,
                        TipoIdentificacion = persona.TipoIdentificacion,
                        NumeroIdentificacion = persona.NumeroIdentificacion,
                        Email = persona.Email,
                        FechaCreacion = persona.FechaCreacion,
                        ConcatenaNombresApellidos = persona.ConcatenaNombresApellidos,
                        ConcatenaIdentificacionTipo = persona.ConcatenaIdentificacionTipo
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = false });
            }

            return Ok(respuestaItem);
        }

    }
}
