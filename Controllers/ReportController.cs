﻿using apiwise.Data;
using apiwise.Interface;
using apiwise.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apiwise.Controllers
{
    /// <summary>
    /// </summary>
    [Route("api/")]
    [ApiController]
    public class ReportController : ControllerBase
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
        /// <param name="ctxProcedure"></param>
        public ReportController(DataContext dataContext, IMapper mapper, ILoggerWise logger, DataContextProcedures ctxProcedure)
        {
            _logger = logger;
            _datacontext = dataContext;
            _mapper = mapper;
            _ctxProcedure = ctxProcedure;
        }
        /// <summary>
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost("itemsfv")]
        public async Task<ActionResult> GetResultItemsFv([FromBody] FromBodyItemFvReport param)
        {
            try
            {
                if (param == null)
                {
                    var MsjReuest = "ERROR: Con los parametros enviados.";
                    return BadRequest(new { Success = false, Message = MsjReuest });
                }
                else
                {
                    List<Itemsfvfranquiciadosamatriz> ItemsFv = await _ctxProcedure.Itemsfvfranquiciadosamatrizs.FromSqlRaw($"CALL GenerarReporteItemsFacturadasFranquiciasParaMatriz('{param.fecha}')").ToListAsync();
                    if (ItemsFv.Count > 0)
                    {
                        _logger.LogInformation($"GetResultItemsFv:{ItemsFv}");
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
                _logger.LogError($"ERROR: GetResultItemsFv:{mensaje}");
                return BadRequest(new { Success = false, Message = mensaje });
            }

        }
    }
}
