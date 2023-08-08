using apiwise.Data;
using apiwise.Helps;
using apiwise.Interface;
using apiwise.Models.Pagos.PagosDto;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace apiwise.Controllers
{
    /// <summary>
    /// </summary>
    [Route("api/")]
    [ApiController]
    [Authorize]
    public class PagosController : ControllerBase
    {
        public readonly DataContext _datacontext;
        public readonly IMapper _mapper;
        private readonly ILoggerWise _logger;
        private readonly DataContextProcedures _ctxProcedure;

        /// <summary>
        /// </summary>
        /// <param name="dataContext"></param>
        /// <param name="mapper"></param>
        /// <param name="logger"></param>
        /// <param name="ctxProcedure"></param>
        public PagosController(DataContext dataContext, IMapper mapper, ILoggerWise logger, DataContextProcedures ctxProcedure)
        {
            _datacontext = dataContext;
            _mapper = mapper;
            _logger = logger;
            _ctxProcedure = ctxProcedure;
        }

        /// <summary>
        /// Registrar pagos clientes
        /// </summary>
        /// <param name="pay">Json para ejecutar el pago</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("pagoscliente")]
        public async Task<ActionResult> PostPaymentsEasyAsync(Payment pay)
        {
            //call GrabarPagosApiWise(ParId VARCHAR(36),ParEstado INT(1))
            string jsonString = JsonSerializer.Serialize(pay);
            _logger.LogInformation($"INI: PostPaymentsEasyAsync {jsonString}");
            string idPagos = Guid.NewGuid().ToString();
            try
            {
                if (pay != null)
                {
                    if (pay.ValorTotal > 0)
                    {
                        decimal TotalCuotas = pay.Cuotas.Sum(e => e.ValorAbono);
                        if (pay.ValorTotal == TotalCuotas)
                        {
                            var pagos = await _datacontext.Database.ExecuteSqlInterpolatedAsync($"INSERT INTO cfm_pagos VALUES({idPagos},{pay.NumRecibo},{pay.IdFactura},{pay.IdUsuario},{pay.FormaPago},{pay.ValorTotal},{pay.Observacion},0,NOW());");
                            if (pay.Cuotas.Count > 0)
                            {
                                foreach (PaymentDetail row in pay.Cuotas)
                                {
                                    var detalle = await _datacontext.Database.ExecuteSqlInterpolatedAsync($"INSERT INTO cfm_pagosdetalle VALUES({Guid.NewGuid()},{idPagos},{row.IdCuota},{row.ValorAbono},{row.Propietario},{row.IdBanco},{row.NumCuenta},{row.NumCheque},{row.Fechadoc})");
                                }
                                List<ResultPay> respago = await _ctxProcedure.ResultPays.FromSqlRaw($"CALL cfm_GrabarPagosApiWise('{idPagos}',0)").ToListAsync();
                                if (respago[0].Idpago.Equals(""))
                                {
                                    _logger.LogError($"PostPaymentsEasyAsync:No existe saldo por pagar");
                                    return BadRequest(ResquestPay(false, "No existe saldo por pagar."));
                                }
                                else
                                {
                                    _logger.LogInformation($"FIN: PostPaymentsEasyAsync:OK {respago[0]}");
                                    return Ok(ResquestPay(true, "OK", respago[0]));
                                }
                            }
                            else
                            {
                                _logger.LogError($"PostPaymentsEasyAsync:No Existe Informacion del credito/cuota para realizar el pago.");
                                return BadRequest(ResquestPay(false, "No Existe Informacion del credito/cuota para realizar el pago."));
                            }
                        }
                        else
                        {
                            _logger.LogError($"PostPaymentsEasyAsync:ValorTotal:{pay.ValorTotal} es diferente a la suma de valores de abono:{TotalCuotas} de cuotas.");
                            return BadRequest(ResquestPay(false, $"ValorTotal:{pay.ValorTotal} es diferente a la suma de valores de abono:{TotalCuotas} de cuotas."));
                        }
                    }
                    else
                    {
                        _logger.LogError($"PostPaymentsEasyAsync:ValorTotal:{pay.ValorTotal} tiene que ser mayor a cero.");
                        return BadRequest(ResquestPay(false, $"ValorTotal:{pay.ValorTotal} tiene que ser mayor a cero."));
                    }
                }
                else
                {
                    _logger.LogError($"PostPaymentsEasyAsync:No Existe Informacion para realizar el pago.");
                    return BadRequest(ResquestPay(false, "No Existe Informacion para realizar el pago."));
                }
            }
            catch (Exception ex)
            {
                string RMsj = $"{ex.Message}:{(ex.InnerException != null ? ex.InnerException.Message : "")}";
                _logger.LogError($"ERROR:PostPaymentsEasyAsync {RMsj}:{idPagos}");
                return BadRequest(ResquestPay(false, RMsj));
            }
        }
        /// <summary>
        /// </summary>
        /// <param name="Success"></param>
        /// <param name="Msj"></param>
        /// <param name="ObjResult"></param>
        /// <returns></returns>
        private ServerRespuesta ResquestPay(bool Success, string Msj, object? ObjResult = null)
        {
            ServerRespuesta respuestaServidor = new()
            {
                Success = Success,
                Message = Msj,
                ResponsesObject = ObjResult
            };
            return respuestaServidor;
        }
    }
}

