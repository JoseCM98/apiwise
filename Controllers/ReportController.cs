using apiwise.Data;
using apiwise.Interface;
using apiwise.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apiwise.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        public readonly DataContext _datacontext;
        public readonly IMapper _mapper;
        public readonly ILoggerWise _logger;
        private readonly DataContextProcedures _ctxProcedure;
        public ReportController(DataContext dataContext, IMapper mapper, ILoggerWise logger, DataContextProcedures ctxProcedure)
        {
            _logger = logger;
            _datacontext = dataContext;
            _mapper = mapper;
            _ctxProcedure = ctxProcedure;
        }
        [HttpPost("itemsfv")]
        public async Task<ActionResult> GetResultItemsFv([FromBody] string DateInfo)
        {
            try
            {
                if (DateInfo == null)
                {
                    var MsjReuest = "ERROR: Con los parametros enviados.";
                    return BadRequest(new { Success = false, Message = MsjReuest });
                }
                else
                {
                    List<Itemsfvfranquiciadosamatriz> ItemsFv = await _ctxProcedure.Itemsfvfranquiciadosamatrizs.FromSqlRaw($"CALL GenerarReporteItemsFacturadasFranquiciasParaMatriz('{DateInfo}')").ToListAsync();
                    if (ItemsFv.Count > 0)
                    {
                        return Ok(new { Success = true, Message = "OK", ResponsesObject = ItemsFv });
                    }
                    else
                    {
                        return BadRequest(new { Success = false, Message = "OK", ResponsesObject = "No existe info." });
                    }

                }
            }
            catch (Exception ex)
            {
                string mensaje = $"{ex.Message}:{(ex.InnerException != null ? ex.InnerException.Message : "")}";
                _logger.LogError($"ERROR: Slctdreposicionitem {mensaje}");
                return BadRequest(new { Success = false, Message = mensaje });
            }

        }
    }
}
