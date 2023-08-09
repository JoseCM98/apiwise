using apiwise.Data;
using apiwise.Interface;
using apiwise.Models.Contratos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apiwise.Controllers
{
    /// <summary>
    /// </summary>
    [Route("api/")]
    [ApiController]
    public class ContratosController : ControllerBase
    {
        private readonly DataContextProcedures _ctxProcedure;
        public readonly IMapper _mapper;
        public readonly ILoggerWise _logger;

        public ContratosController(DataContextProcedures ctxProcedure, IMapper mapper, ILoggerWise logger)
        {
            _ctxProcedure = ctxProcedure;
            _logger = logger;
            _mapper = mapper;
        }
        /// <summary>
        /// </summary>= "0101804086001"
        /// <param name="codigo">identificacion del cliente DNI</param>
        /// <returns></returns>

        [HttpGet("contratosclientes")]
        public async Task<ActionResult> GetResultContratoCliente(string codigo)
        {
            /// http://10.101.1.39:85/api/contratosclientes?codigo=0101804086001
            _logger.LogInformation($"Consultar:{codigo}");
            try
            {
                List<SaldoContratoClienteWeb> cliente = await _ctxProcedure.SaldoContratoClientes.FromSqlRaw($"CALL ObtenerDatosContratoClientesApiWise('{codigo}','','','0')").ToListAsync();
                if (cliente.Count > 0)
                {
                    List<InformacionContrato> infocontratos = await _ctxProcedure.InformacionContratos.FromSqlRaw($"CALL ObtenerDatosContratoClientesApiWise('','{cliente[0].Id}','',1);").ToListAsync();
                    if (infocontratos.Count > 0)
                    {
                        for (int i = 0; i < infocontratos.Count; i++)
                        {
                            List<DetalleContrato> detalles = await _ctxProcedure.DetalleContratos.FromSqlRaw($"CALL ObtenerDatosContratoClientesApiWise('','','{infocontratos[i].Idcontrato}',2);").ToListAsync();
                            infocontratos[i].Detalles = detalles;
                            List<OrdenesServicioTecnico> ordenes = await _ctxProcedure.OrdenesServicioTecnicos.FromSqlRaw($"CALL ObtenerDatosContratoClientesApiWise('','','{infocontratos[i].Idcontrato}',4);").ToListAsync();
                            infocontratos[i].ordenesServiciosTecnico = ordenes;
                        }
                        for (int i = 0; i < infocontratos.Count; i++)
                        {
                            List<CreditoXCobrar> deudas = await _ctxProcedure.CreditoXCobrars.FromSqlRaw($"CALL ObtenerDatosContratoClientesApiWise('','','{infocontratos[i].Idcontrato}',3);").ToListAsync();
                            infocontratos[i].CantidadDeuda = deudas.Count;
                            infocontratos[i].Deudaspendiente = deudas;
                            infocontratos[i].Deudatotal = deudas.Sum(e => e.Deuda);
                        }
                    }
                    cliente[0].Infocontratos = infocontratos;
                }
                return Ok(cliente[0]);
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message + ": " + (ex.InnerException != null ? ex.InnerException.Message : "");
                _logger.LogError($"ERROR: contratosclientes {mensaje}");
                return BadRequest(new { Success = false, Message = mensaje });
            }
        }
    }
}
