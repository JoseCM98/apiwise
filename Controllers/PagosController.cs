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
    [Route("api/")]
    [ApiController]
    [Authorize]
    public class PagosController : ControllerBase
    {
        public readonly DataContext _datacontext;
        public readonly IMapper _mapper;
        private readonly ILoggerWise _logger;
        private readonly DataContextProcedures _ctxProcedure;

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
                                    return BadRequest(ResquestPay(false, "No existe saldo por pagar."));
                                }
                                else
                                {
                                    return Ok(ResquestPay(true, "OK", respago[0]));
                                }
                            }
                            else
                            {
                                return BadRequest(ResquestPay(false, "No Existe Informacion del credito/cuota para realizar el pago."));
                            }
                        }
                        else
                        {
                            return BadRequest(ResquestPay(false, $"ValorTotal:{pay.ValorTotal} es diferente a la suma de valores de abono:{TotalCuotas} de cuotas."));
                        }
                    }
                    else
                    {
                        return BadRequest(ResquestPay(false, $"ValorTotal:{pay.ValorTotal} tiene que ser mayor a cero."));
                    }
                }
                else
                {
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
////http://192.168.0.250:122/Pagos
//[AllowAnonymous]
//[HttpPost]
//public async Task<ActionResult> PostPagosAsync(PagosGrabarDto pagos)
//{
//    _logger.LogInformation("INICIO: PostPagosAsync");
//    ServerRespuesta respuestaServidor = new();
//    string mensaje = "";
//    string idPagos = "";
//    try
//    {
//        if (pagos.pagoscabecera != null)
//        {
//            idPagos = pagos.pagoscabecera[0].CodigoPagoCabecera;
//            if (pagos.pagoscabecera.Count > 0)
//            {
//                for (int i = 0; i <= pagos.pagoscabecera.Count - 1; i++)
//                {
//                    if (!_datacontext.Set<Pagoscabecera>().Any(e => e.CodigoPagoCabecera == pagos.pagoscabecera[i].CodigoPagoCabecera))
//                    {
//                        _datacontext.Pagoscabeceras.Add(pagos.pagoscabecera[i]);
//                    }
//                }
//            }
//            //_datacontext.Pagoscabecera.AddRange(pagos.pagoscabecera);
//            mensaje += "Se inserto pagos cabecera.";
//        }
//        if (pagos.pagosdetalle != null)
//        {
//            if (pagos.pagosdetalle.Count > 0)
//            {
//                for (int i = 0; i <= pagos.pagosdetalle.Count - 1; i++)
//                {
//                    if (!_datacontext.Set<Pagosdetalle>().Any(e => e.CodigoPagoDetalle == pagos.pagosdetalle[i].CodigoPagoDetalle))
//                    {
//                        _datacontext.Pagosdetalles.Add(pagos.pagosdetalle[i]);
//                    }
//                }
//            }
//            // _datacontext.Pagosdetalle.AddRange(pagos.pagosdetalle);
//            mensaje += "Se inserto pagos detalles.";
//        }
//        if (pagos.pagosmanejoscajas != null)
//        {
//            if (pagos.pagosmanejoscajas.Count > 0)
//            {
//                for (int i = 0; i <= pagos.pagosmanejoscajas.Count - 1; i++)
//                {
//                    if (!_datacontext.Set<Pagosmanejoscaja>().Any(e => e.CodigoPagoManejoCaja == pagos.pagosmanejoscajas[i].CodigoPagoManejoCaja))
//                    {
//                        _datacontext.Pagosmanejoscajas.Add(pagos.pagosmanejoscajas[i]);
//                    }
//                }
//            }

//            //  _datacontext.Pagosmanejoscajas.AddRange(pagos.pagosmanejoscajas);
//            mensaje += "Se inserto pagos manejos cajas.";
//        }
//        if (pagos.pagosdetalleintereses != null)
//        {
//            if (pagos.pagosdetalleintereses.Count > 0)
//            {
//                for (int i = 0; i <= pagos.pagosdetalleintereses.Count - 1; i++)
//                {
//                    if (!_datacontext.Set<Pagosdetalleinterese>().Any(e => e.CodigoPagoDetalleInteres == pagos.pagosdetalleintereses[i].CodigoPagoDetalleInteres))
//                    {
//                        _datacontext.Pagosdetalleintereses.Add(pagos.pagosdetalleintereses[i]);
//                    }
//                }
//            }

//            // _datacontext.Pagosdetalleintereses.AddRange(pagos.pagosdetalleintereses);
//            mensaje += "Se inserto pagos detalle intereses.";
//        }
//        if (pagos.pagoschequedetalle != null)
//        {
//            if (pagos.pagoschequedetalle.Count > 0)
//            {
//                for (int i = 0; i <= pagos.pagoschequedetalle.Count - 1; i++)
//                {
//                    if (!_datacontext.Set<Pagoschequedetalle>().Any(e => e.CodigoPagoChequeDetalle == pagos.pagoschequedetalle[i].CodigoPagoChequeDetalle))
//                    {
//                        _datacontext.Pagoschequedetalles.Add(pagos.pagoschequedetalle[i]);
//                    }
//                }
//            }
//            //_datacontext.Pagoschequedetalles.AddRange(pagos.pagoschequedetalle);
//            mensaje += "Se inserto pagos Cheque detalle.";
//        }
//        if (mensaje != "")
//        {
//            await _datacontext.SaveChangesAsync();
//            respuestaServidor.Success = true;
//            respuestaServidor.Message = mensaje;
//            _logger.LogInformation("CORRECTO:PostPagosAsync" + mensaje + ":" + idPagos);
//        }
//        else
//        {
//            respuestaServidor.Success = false;
//            respuestaServidor.Message = "No se encontro nada que grabar.";
//            _logger.LogInformation("CORRECTO:PostPagosAsync DATOS VACIO: " + mensaje + ":" + idPagos);
//        }
//        return Ok(respuestaServidor);
//    }
//    catch (Exception ex)
//    {
//        respuestaServidor.Success = false;
//        respuestaServidor.Message = ex.Message + ": " + (ex.InnerException != null ? ex.InnerException.Message : "");
//        _logger.LogError("ERROR:PostPagosAsync " + respuestaServidor.Message + ":" + idPagos);
//        return BadRequest(respuestaServidor);
//    }
//}

////http://192.168.0.250:122/Pagos/CobrosRealizados/ecosuiza/2873dd4e-89e2-4500-af47-6b30da48e385
//[AllowAnonymous]
//[HttpGet("CobrosRealizados/{idEmpresa}/{idCredito}")]
//public async Task<ActionResult> GetPagosPorCreditoAsync(string idEmpresa, string idCredito)
//{
//    _logger.LogInformation("INICIO: GetPagosPorCreditoAsync");
//    ServerRespuesta respuestaServidor = new();
//    try
//    {
//        List<Pagoscabecera> listaPagos;
//        if (idCredito != "")
//        {
//            listaPagos = await _datacontext.Pagoscabeceras.Include(a => a.Pagosmanejoscajas).Include(det => det.Pagosdetalles.Where(x => x.CreditosDetallePagoDetalle == idCredito)).ThenInclude(x => x.CreditosDetallePagoDetalleNavigation)
//                .Where(e => e.EstadoPagoCabecera == "0" && e.EmpresasPagoCabecera == idEmpresa && e.Pagosdetalles.Any(pd => pd.CreditosDetallePagoDetalle == idCredito))
//                .ToListAsync();
//            _logger.LogInformation("RETORNA: item indi GetPagosPorCreditoAsync.");
//            return Ok(listaPagos);
//        }
//        else
//        {
//            _logger.LogInformation("RETORNA:vacio GetPagosPorCreditoAsync.");
//            return Ok("OK");
//        }
//    }
//    catch (Exception ex)
//    {
//        respuestaServidor.Success = false;
//        respuestaServidor.Message = ex.Message + ": " + (ex.InnerException != null ? ex.InnerException.Message : "");
//        _logger.LogError("ERROR:GetPagosPorCreditoAsync " + respuestaServidor.Message + ":" + idCredito);
//        return BadRequest(respuestaServidor);
//    }
//}

