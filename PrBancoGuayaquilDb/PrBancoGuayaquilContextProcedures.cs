﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PrBancoGuayaquilDb;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace PrBancoGuayaquilDb
{
    public partial class PrBancoGuayaquilContext
    {
        private IPrBancoGuayaquilContextProcedures _procedures;

        public virtual IPrBancoGuayaquilContextProcedures Procedures
        {
            get
            {
                if (_procedures is null) _procedures = new PrBancoGuayaquilContextProcedures(this);
                return _procedures;
            }
            set
            {
                _procedures = value;
            }
        }

        public IPrBancoGuayaquilContextProcedures GetProcedures()
        {
            return Procedures;
        }
    }

    public partial class PrBancoGuayaquilContextProcedures : IPrBancoGuayaquilContextProcedures
    {
        private readonly PrBancoGuayaquilContext _context;

        public PrBancoGuayaquilContextProcedures(PrBancoGuayaquilContext context)
        {
            _context = context;
        }

        public virtual async Task<List<sp_consulta_personaResult>> sp_consulta_personaAsync(string i_CodicionBusqueda, string i_DatoBusqueda, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "i_CodicionBusqueda",
                    Size = 24,
                    Value = i_CodicionBusqueda ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "i_DatoBusqueda",
                    Size = 128,
                    Value = i_DatoBusqueda ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<sp_consulta_personaResult>("EXEC @returnValue = [dbo].[sp_consulta_persona] @i_CodicionBusqueda = @i_CodicionBusqueda, @i_DatoBusqueda = @i_DatoBusqueda", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }
    }
}
