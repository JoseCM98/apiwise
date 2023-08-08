using apiwise.Data;
using apiwise.Enum;
using apiwise.Interface;
using apiwise.Models;
using apiwise.Models.CProducto;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace apiwise.Controllers
{
    /// <summary>
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductosController : ControllerBase
    {
        private readonly DataContext _datacontex;
        private readonly IMapper _mapper;
        private readonly ILoggerWise _logger;
        /// <summary>
        /// </summary>
        /// <param name="dataContext"></param>
        /// <param name="mapper"></param>
        /// <param name="logger"></param>
        public ProductosController(DataContext dataContext,
                                    IMapper mapper,
                                    ILoggerWise logger)
        {
            _datacontex = dataContext;
            _mapper = mapper;
            _logger = logger;
        }
        //http://192.168.0.250:122/api/Productos/itemexist  http://localhost:122/api/Productos/itemexist
        //entrada { "rucempresa" : "0190170322001", "iditem" : "", "data" : [ "10000000002", "1803291156248254", "180327133123242" ] }
        //entrada FE { "rucempresa" : "0190492281001", "iditem" : "", "data" : [ "10000000002", "1803291156248254", "180327133123242","77777777","111111111" ] }
        //salida [ { "id" : "10000000002" }, { "id" : "180327133123242" } ]
        /// <summary>
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("itemexist")]
        public async Task<ActionResult> GetProductoAsync([FromBody] FromBodyItems filter)
        {
            try
            {
                _logger.LogInformation("INICIO: GetProductoAsync.");
                Empresa? empresas = _datacontex.Empresas.Where(ruc => ruc.RucEmpresa == filter.rucempresa).FirstOrDefault();
                var idempresa = "";
                if (empresas == null)
                {
                    return BadRequest(new { Success = false, Message = "No existe datos de productos." });
                }
                else
                {
                    idempresa = empresas.CodigoEmpresa;
                    List<Producto> producto = await _datacontex.Productos.Where(x => filter.data.Contains(x.Idmultiempresas)
                                                                && x.VentaProducto == ((int)ProductosEnum.activo).ToString()
                                                                && x.Idmultiempresas != ""
                                                                && x.Empresasproductos.Any(x => x.EmpresasEmpresaProducto == idempresa)).ToListAsync();

                    if (producto.Count > 0)
                    {
                        List<ResponseItemFranquicias> responseItems = _mapper.Map<List<ResponseItemFranquicias>>(producto);
                        _logger.LogInformation("RETORNA: lista GetProductoAsync.");
                        return Ok(responseItems);

                    }
                    else
                    {
                        _logger.LogError($"ERROR: no existe GetProductoAsync");
                        return BadRequest(new { Success = false, Message = "No existe registro." });
                    }
                }
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message + ": " + (ex.InnerException != null ? ex.InnerException.Message : "");
                _logger.LogError($"ERROR: GetProductoAsync {mensaje}");
                return BadRequest(new { Success = false, Message = $"ERROR:{mensaje}" });
            }
        }
        /// <summary>
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("items")]
        public async Task<ActionResult> GetProducto([FromBody] FromBodyItems filter)
        {
            try
            {
                _logger.LogInformation("INICIO: GetProductoAsync.");
                Empresa? empresas = _datacontex.Empresas.Where(ruc => ruc.RucEmpresa == filter.rucempresa).FirstOrDefault();
                var idempresa = "";
                if (empresas == null)
                {
                    return BadRequest(new { Success = false, Message = "No existe datos de productos." });
                }
                else
                {
                    idempresa = empresas.CodigoEmpresa;
                    string searchTerm = filter.descripcion;
                    List<Producto> producto;
                    if (searchTerm.Trim().Equals(""))
                    {
                        producto = await _datacontex.Productos
                               .Where(p => p.VentaProducto == ((int)ProductosEnum.activo).ToString()
                               && p.Empresasproductos.Any(x => x.EmpresasEmpresaProducto == idempresa))
                               .Include(ep => ep.Empresasproductos)
                               .Include(l => l.LineasProductoNavigation)
                               .Include(c => c.CategoriasProductoNavigation)
                               .Include(g => g.GruposProductoNavigation)
                               .Include(m => m.MarcasProductoNavigation)
                               .Include(t => t.TiposProductoNavigation)
                               .Skip(500).ToListAsync();
                    }
                    else
                    {
                        producto = await _datacontex.Productos
                         .Where(p => p.CodigoProducto.Contains(searchTerm)
                         || p.CodigoVentaProducto.Contains(searchTerm)
                         || p.DescripcionProducto.Contains(searchTerm)
                         || p.Idmultiempresas.Contains(searchTerm)
                         && p.VentaProducto == ((int)ProductosEnum.activo).ToString()
                         && p.Empresasproductos.Any(x => x.EmpresasEmpresaProducto == idempresa))
                         .Include(ep => ep.Empresasproductos)
                         .Include(l => l.LineasProductoNavigation)
                         .Include(c => c.CategoriasProductoNavigation)
                         .Include(g => g.GruposProductoNavigation)
                         .Include(m => m.MarcasProductoNavigation)
                         .Include(t => t.TiposProductoNavigation)
                         .Skip(2).ToListAsync();
                    }
                    if (producto.Count > 0)
                    {
                        List<GetItems> responseItems = _mapper.Map<List<GetItems>>(producto);
                        _logger.LogInformation("RETORNA: lista GetProductoAsync.");
                        return Ok(new { Success = true, Message = "OK", ResponsesObject = responseItems });
                    }
                    else
                    {
                        _logger.LogError($"ERROR: no existe GetProductoAsync");
                        return BadRequest(new { Success = false, Message = "No existe registro." });
                    }
                }
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message + ": " + (ex.InnerException != null ? ex.InnerException.Message : "");
                _logger.LogError($"ERROR: GetProductoAsync {mensaje}");
                return BadRequest(new { Success = false, Message = $"ERROR:{mensaje}" });
            }
        }

    }
}
