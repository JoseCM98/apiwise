using apiwise.Data;
using apiwise.Interface;
using apiwise.Models.Series;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apiwise.Controllers
{
    /// <summary>
    /// </summary>
    [Route("api/")]
    [ApiController]
    public class SeriesLotesProductController : ControllerBase
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
        public SeriesLotesProductController(DataContext dataContext, IMapper mapper, ILoggerWise logger, DataContextProcedures ctxProcedure)
        {
            _logger = logger;
            _datacontext = dataContext;
            _mapper = mapper;
            _ctxProcedure = ctxProcedure;
        }
        /// <summary>
        /// </summary>
        /// <param name="IdDocs"></param>
        /// <returns></returns>
        [HttpGet("seriesfranquicia")]
        public async Task<ActionResult> GetResultSerie([FromBody] string IdDocs)
        {
            try
            {
                if (IdDocs == null)
                {
                    var MsjReuest = "ERROR: Con los parametros enviados.";
                    return BadRequest(new { Success = false, Message = MsjReuest });
                }
                else
                {
                    List<Seriesproducto> seriesproductos = await _datacontext.Seriesproductos.Where(e => e.DocsCabeceraSerieProducto == IdDocs).ToListAsync();
                    return Ok(new { Success = true, Message = "OK", ResponsesObject = seriesproductos });
                }
            }
            catch (Exception ex)
            {
                string mensaje = $"{ex.Message}:{(ex.InnerException != null ? ex.InnerException.Message : "")}";
                _logger.LogError($"ERROR: Slctdreposicionitem {mensaje}");
                return BadRequest(new { Success = false, Message = mensaje });
            }
        }
        /// <summary>
        /// </summary>
        /// <param name="IdDocs"></param>
        /// <returns></returns>
        [HttpPost("seriesitems")]
        public async Task<ActionResult> GetResultSerieItems([FromBody] string IdDocs)
        {
            try
            {
                if (IdDocs == null)
                {
                    var MsjReuest = "ERROR: Con los parametros enviados.";
                    return BadRequest(new { Success = false, Message = MsjReuest });
                }
                else
                {
                    List<ResultSeriesProductos> seriesproductos = await _ctxProcedure.ResultSeriesProductos.FromSqlRaw($"CALL ObtenerSeriesProductosProveedor('{IdDocs}')").ToListAsync();
                    if (seriesproductos.Count > 0)
                    {
                        var esultado = await _datacontext.Database.ExecuteSqlInterpolatedAsync($"UPDATE slctdreposicionitem SET enviadoseriesp=1 WHERE id={IdDocs}");
                    }
                    return Ok(new { Success = true, Message = "OK", ResponsesObject = seriesproductos });
                }
            }
            catch (Exception ex)
            {
                string mensaje = $"{ex.Message}:{(ex.InnerException != null ? ex.InnerException.Message : "")}";
                _logger.LogError($"ERROR: Slctdreposicionitem {mensaje}");
                return BadRequest(new { Success = false, Message = mensaje });
            }
        }
        /// <summary>
        /// </summary>
        /// <param name="seriesproductos"></param>
        /// <returns></returns>
        [HttpPost("seriesfranquicia")]
        public async Task<ActionResult> PosResultSerie([FromBody] List<Seriesproducto> seriesproductos)
        {
            try
            {
                if (seriesproductos.Count > 0)
                {
                    var idDoc = seriesproductos[0].DocsCabeceraSerieProducto;
                    await _datacontext.AddRangeAsync(seriesproductos);
                    await _datacontext.SaveChangesAsync();
                    var esultado = await _datacontext.Database.ExecuteSqlInterpolatedAsync($"UPDATE slctdreposicionitem SET enviadoseriesp=1 WHERE id={idDoc}");
                    return Ok(new { Success = true, Message = "OK" });
                }
                else
                {
                    return BadRequest(new { Success = false, Message = "No tiene datos" });
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
