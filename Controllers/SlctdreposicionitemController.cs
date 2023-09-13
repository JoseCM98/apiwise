using apiwise.Data;
using apiwise.Enum;
using apiwise.Helps;
using apiwise.Interface;
using apiwise.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Newtonsoft.Json;

namespace apiwise.Controllers
{
    /// <summary>
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SlctdreposicionitemController : ControllerBase
    {
        public readonly DataContext _datacontext;
        public readonly IMapper _mapper;
        public readonly ILoggerWise _logger;
        private readonly DataContextProcedures _ctxProcedure;
        /// <summary>
        /// </summary>
        /// <param name="dataContext"></param>
        /// <param name="mapper"></param>
        /// <param name="logger"></param>
        public SlctdreposicionitemController(DataContext dataContext, IMapper mapper, ILoggerWise logger, DataContextProcedures ctxProcedure)
        {
            _logger = logger;
            _datacontext = dataContext;
            _mapper = mapper;
            _ctxProcedure = ctxProcedure;
        }
        /// <summary>
        /// </summary>
        /// <param name="BodyRequest">{ "iddoc" : "220518161658412", "rucorigen" : "0103677456001", "rucproveedor" : "0190170322001" } </param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetResult([FromBody] SlcRItemFromBodyRequest BodyRequest)
        {
            try
            {
                if (BodyRequest == null)
                {
                    var MsjReuest = "ERROR: Con los parametros enviados.";
                    return BadRequest(new { Success = false, Message = MsjReuest });
                }
                else
                {
                    var IdDoc = BodyRequest.Iddoc;
                    List<Slctdreposicionitem> lstDatos;
                    if (IdDoc != null)
                    {
                        lstDatos = await _datacontext.Slctdreposicionitems.Include(e => e.Slctdreposicionitemdetalle).Where(e => e.Id == IdDoc).ToListAsync();
                        return Ok(new { Success = true, Message = "OK", ResponsesObject = lstDatos });
                    }
                    else
                    {
                        Empresa? empresas = _datacontext.Empresas.Where(x => x.RucEmpresa == BodyRequest.Rucorigen).FirstOrDefault();
                        if (empresas != null)
                        {
                            if (BodyRequest.Rucproveedor != null)
                            {
                                lstDatos = await _datacontext.Slctdreposicionitems.Include(e => e.Slctdreposicionitemdetalle).Where(e => e.Idempresa == empresas.CodigoEmpresa && e.Rucproveedor == BodyRequest.Rucproveedor).ToListAsync();
                                return Ok(new { Success = true, Message = "OK", ResponsesObject = lstDatos });
                            }
                            else
                            {
                                lstDatos = await _datacontext.Slctdreposicionitems.Include(e => e.Slctdreposicionitemdetalle).Where(e => e.Idempresa == empresas.CodigoEmpresa).ToListAsync();
                                return Ok(new { Success = true, Message = "OK", ResponsesObject = lstDatos });
                            }
                        }
                        else
                        {
                            return BadRequest(new { Success = false, Message = $"ERROR: Ruc de la empresa del Servicio es incorrecto." });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message + ": " + (ex.InnerException != null ? ex.InnerException.Message : "");
                _logger.LogError($"ERROR: Slctdreposicionitem {mensaje}");
                return BadRequest(new { Success = false, Message = mensaje });
            }
        }
        /// <summary>
        /// </summary>
        /// <param name="slctdreposicionitem"></param>
        /// <returns></returns>
        // POST api/<SlctdreposicionitemController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Slctdreposicionitem slctdreposicionitem)
        {
            _logger.LogInformation($"Iniciando el Slctdreposicionitem post:{JsonConvert.SerializeObject(slctdreposicionitem)}");
            string idDocumento = "";
            string rucProvedor = "";
            string rucOrigen = "";
            string Idtiposlct = "";
            try
            {
                rucOrigen = slctdreposicionitem.Rucorigenf;
                rucProvedor = slctdreposicionitem.Rucproveedor;
                idDocumento = slctdreposicionitem.Id;
                Idtiposlct = slctdreposicionitem.Idtiposlct;
                Empresa? empresas = await _datacontext.Empresas.Where(x => x.RucEmpresa == rucProvedor).FirstOrDefaultAsync();
                if (empresas == null)
                {
                    return BadRequest(new { Success = false, Message = $"ERROR: Ruc del Servicio de PROVEEDOR incorrecto." });
                }
                else
                {
                    Cliempresaapi? cliempresaapi = await _datacontext.Cliempresaapis.Where(a => a.Identificacion == rucOrigen).FirstOrDefaultAsync();
                    if (cliempresaapi == null)
                    {
                        return BadRequest(new { Success = false, Message = $"ERROR: El ruc de la empresa solicitante no esta registrado en PROVEEDOR:{empresas.NombreEmpresa}" });
                    }
                    else
                    {
                        Accionesperfilesslctreposicionitem? accione = await _datacontext.Accionesperfilesslctreposicionitems
                            .Where(x => x.Idempresa == empresas.CodigoEmpresa && x.Idcliempresa == cliempresaapi.Id && x.Idtiposlct == Idtiposlct).FirstOrDefaultAsync();
                        if (accione == null)
                        {
                            return BadRequest(new { Success = false, Message = $"ERROR: No existe un perfil que atienda la solicitud." });
                        }
                        else
                        {
                            //1002	NORMAL,1001	PUNTUAL
                            string TipoTramite = TipoDocPendientes.REPOSICION_ITEM_PR[0];
                            string TipoDoc = TipoDocPendientes.REPOSICION_ITEM_PR[1];
                            if (Idtiposlct.Equals("1001"))
                            {
                                TipoTramite = TipoDocPendientes.REPOSICION_ITEM_PR_ORP[0];
                                TipoDoc = TipoDocPendientes.REPOSICION_ITEM_PR_ORP[1];
                            }
                            slctdreposicionitem.Idempresa = empresas.CodigoEmpresa;
                            slctdreposicionitem.Estado = int.Parse(TipoEstadoFranquicia.FRAN_RECIBE_PROV[0]);
                            slctdreposicionitem.Fecharecibep = DateTime.Now;
                            await _datacontext.Slctdreposicionitems.AddAsync(slctdreposicionitem);
                            Docspendiente docs = new()
                            {
                                DocsCabeceraDocPendiente = idDocumento,
                                CodigoDocPendiente = $"{idDocumento}01",
                                TiposTramitesDocPendiente = TipoTramite,
                                PerfilesDocPendiente = accione.Idperfilatiende,
                                PerfilesMailBccdocPendiente = accione.Idperfilatiende,
                                CreacionDocPendiente = DateTime.Now,
                                AtencionDocPendiente = DateTime.Now,
                                EstadoDocPendiente = "PENDIENTE",
                                TipoDocumentoDocPendiente = TipoDoc
                            };
                            _datacontext.Docspendientes.Add(docs);
                            await _datacontext.SaveChangesAsync();
                            return Ok(new { Success = true, Message = "OK" });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message + ": " + (ex.InnerException != null ? ex.InnerException.Message : "");
                _logger.LogError($"ERROR: Slctdreposicionitem {mensaje}:{idDocumento}:{JsonConvert.SerializeObject(slctdreposicionitem)}");
                return BadRequest(new { Success = false, Message = mensaje });
            }
        }
        /// <summary>
        /// </summary>
        /// <param name="slctdreposicionitem"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> RetornoPut([FromBody] Slctdreposicionitem slctdreposicionitem)
        {
            _logger.LogInformation($"Iniciando el Slctdreposicionitem RetornoPut:{JsonConvert.SerializeObject(slctdreposicionitem)}");
            string idDocumento = "";
            string perfilDoc = "Admin";
            bool escorrecto = false;
            try
            {
                idDocumento = slctdreposicionitem.Id;
                var EstadoDoc = slctdreposicionitem.Estado;
                string IdDocDetalle = "";
                if (slctdreposicionitem.Slctdreposicionitemdetalle.Count > 0)
                {
                    Empresa? empresas = _datacontext.Empresas.Where(x => x.RucEmpresa == slctdreposicionitem.Rucorigenf).FirstOrDefault();
                    if (empresas != null)
                    {
                        Accionesperfilesslctreposicionitemfranquicium? accione = _datacontext.Accionesperfilesslctreposicionitemfranquicia
                            .Where(x => x.Idempresa == empresas.CodigoEmpresa && x.Idtiposlct == slctdreposicionitem.Idtiposlct).FirstOrDefault();
                        if (accione != null)
                            perfilDoc = accione.Idperfilatiende;
                    }
                    foreach (Slctdreposicionitemdetalle row in slctdreposicionitem.Slctdreposicionitemdetalle)
                    {
                        if (!_datacontext.Set<Slctdreposicionitemdetalle>().Any(e => e.Id == row.Id))
                        {
                            _datacontext.Slctdreposicionitemdetalles.Add(row);
                        }
                        else
                        {
                            int EstadoDocUpdate = EstadoDoc;
                            if (EstadoDoc == 5)
                            {
                                EstadoDocUpdate = 0;
                            }
                            var ResDetalle = await _datacontext.Database.ExecuteSqlInterpolatedAsync($"UPDATE slctdreposicionitemdetalle SET cantdespachada={row.Cantdespachada},precioproveedor={row.Precioproveedor},iva={row.Iva},solicitadop={EstadoDocUpdate} WHERE id={row.Id} AND _idcabecera={row._Idcabecera}");
                        }
                    }
                    slctdreposicionitem.Idempresa = empresas.CodigoEmpresa;
                    _datacontext.Slctdreposicionitems.Update(slctdreposicionitem);
                    switch (EstadoDoc)
                    {
                        case 5:
                            IdDocDetalle = $"{idDocumento}03";
                            Docspendiente? docspendiente = await _datacontext.Docspendientes.Where(e => e.DocsCabeceraDocPendiente == idDocumento && e.CodigoDocPendiente == IdDocDetalle).FirstOrDefaultAsync();
                            if (docspendiente == null)
                            {
                                Docspendiente? docsr = new()
                                {
                                    DocsCabeceraDocPendiente = idDocumento,
                                    CodigoDocPendiente = IdDocDetalle,
                                    TiposTramitesDocPendiente = TipoDocPendientes.REPOSICION_ITEM_RECHAZADA[0],
                                    PerfilesDocPendiente = perfilDoc,
                                    PerfilesMailBccdocPendiente = perfilDoc,
                                    CreacionDocPendiente = DateTime.Now,
                                    AtencionDocPendiente = DateTime.Now,
                                    EstadoDocPendiente = "PENDIENTE",
                                    TipoDocumentoDocPendiente = TipoDocPendientes.REPOSICION_ITEM_RECHAZADA[1]
                                };
                                _datacontext.Docspendientes.Add(docsr);
                                escorrecto = true;
                            }
                            else
                            {
                                escorrecto = true;
                            }
                            break;
                        case 3:
                            IdDocDetalle = $"{idDocumento}02";
                            Docspendiente? docspendientea = await _datacontext.Docspendientes.Where(e => e.DocsCabeceraDocPendiente == idDocumento && e.CodigoDocPendiente == IdDocDetalle).FirstOrDefaultAsync();
                            if (docspendientea == null)
                            {
                                Docspendiente? docs = new()
                                {
                                    DocsCabeceraDocPendiente = idDocumento,
                                    CodigoDocPendiente = IdDocDetalle,
                                    TiposTramitesDocPendiente = TipoDocPendientes.REPOSICION_ITEM_FF[0],
                                    PerfilesDocPendiente = perfilDoc,
                                    PerfilesMailBccdocPendiente = perfilDoc,
                                    CreacionDocPendiente = DateTime.Now,
                                    AtencionDocPendiente = DateTime.Now,
                                    EstadoDocPendiente = "PENDIENTE",
                                    TipoDocumentoDocPendiente = TipoDocPendientes.REPOSICION_ITEM_FF[1]
                                };
                                _datacontext.Docspendientes.Add(docs);
                                escorrecto = true;
                            }
                            else
                            {
                                escorrecto = true;
                            }
                            break;
                        case 2:
                            escorrecto = true;
                            break;
                    }
                    if (escorrecto)
                    {
                        await _datacontext.SaveChangesAsync();
                        return Ok(new { Success = true, Message = "OK" });
                    }
                    else
                    {
                        return BadRequest(new { Success = false, Message = $"ERROR: No se puede actualizar,por el estado:{EstadoDoc}" });
                    }
                }
                else
                {
                    return BadRequest(new { Success = false, Message = $"ERROR: No se puede actualizar, no tiene detalle." });
                }
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message + ": " + (ex.InnerException != null ? ex.InnerException.Message : "");
                _logger.LogError($"ERROR:Slctdreposicionitem RetornoPut {mensaje}:{idDocumento}:{JsonConvert.SerializeObject(slctdreposicionitem)}");
                return BadRequest(new { Success = false, Message = mensaje });
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="BodyRequest"></param>
        /// <returns></returns>
        [HttpPost("requests")]
        public async Task<ActionResult> GetResultSlct([FromBody] SlcRItemFromBodyRequest BodyRequest)
        {
            try
            {
                if (BodyRequest == null)
                {
                    var MsjReuest = "ERROR: Con los parametros enviados.";
                    return BadRequest(new { Success = false, Message = MsjReuest });
                }
                else
                {
                    string IdDoc = BodyRequest.Iddoc;
                    string IdEmpresa = "";
                    List<Slctdreposicionitem> lstDatos;
                    if (!IdDoc.Equals(""))
                    {
                        Empresa? empresas = _datacontext.Empresas.Where(x => x.RucEmpresa == BodyRequest.Rucproveedor).FirstOrDefault();
                        if (empresas != null)
                        {
                            IdEmpresa = empresas.CodigoEmpresa;
                        }
                        List<ResultSlctItems> DatoSlct = await _ctxProcedure.ResultSlctItems.FromSqlRaw($"CALL ObtenerSlctReposicionItemTransferencia('{IdEmpresa}','{IdDoc}',1)").ToListAsync();
                        if (DatoSlct.Count > 0)
                        {
                            var ResDetalle = await _datacontext.Database.ExecuteSqlInterpolatedAsync($"UPDATE slctdreposicionitem SET observacionp={DatoSlct[0].Observacion},numfacturaguiap={DatoSlct[0].Numero},fecharechazadap={DatoSlct[0].Fecha} WHERE id={IdDoc} AND idempresa={IdEmpresa}");
                        }
                        lstDatos = await _datacontext.Slctdreposicionitems.Include(e => e.Slctdreposicionitemdetalle).Where(e => e.Id == IdDoc || e.Iddocsorigen == IdDoc).ToListAsync();
                        if (lstDatos.Count > 0)
                        {
                            return Ok(new { Success = true, Message = "OK", ResponsesObject = lstDatos });
                        }
                        else
                        {
                            return BadRequest(new { Success = false, Message = "No existe inf. con el codigo solicitado" });
                        }
                    }
                    else
                    {
                        return BadRequest(new { Success = false, Message = "No existe el parametro del codigo del documento a consultar." });
                    }
                }
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message + ": " + (ex.InnerException != null ? ex.InnerException.Message : "");
                _logger.LogError($"ERROR: Slctdreposicionitem {mensaje}");
                return BadRequest(new { Success = false, Message = mensaje });
            }
        }
    }
}
