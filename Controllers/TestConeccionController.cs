using apiwise.Data;
using apiwise.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace apiwise.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TestConeccionController : ControllerBase
    {
        readonly DataContext _datacontext;
        private readonly ILoggerWise _logger;
        /// <summary>
        /// </summary>
        /// <param name="dataContext"></param>
        /// <param name="logger"></param>
        public TestConeccionController(DataContext dataContext,
                                        ILoggerWise logger)
        {
            _datacontext = dataContext;
            _logger = logger;
        }
        //http://localhost:122/api/TestConeccion
        /// <summary>
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult> Test_ConeccionAsync()
        {
            try
            {
                _logger.LogInformation("INI: Test_ConeccionAsync.");
                List<Empresa> ListEmpresa = await _datacontext.Empresas.ToListAsync();
                if (ListEmpresa.Count > 0)
                {
                    _logger.LogInformation("CORRECTO: Test_ConeccionAsync!");
                    return Ok(new { Success = true, Message = $"OK", ResponsesObject = ListEmpresa });
                }
                else
                {
                    _logger.LogWarning("ERROR: No se pudo realizar la conexion Test_ConeccionAsync!");
                    string mensaje = "ERROR: AL CONSULTAR DATOS";
                    return BadRequest(new { Success = false, Message = mensaje });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR: Test_ConeccionAsync {ex.Message}");
                string mensaje = ex.Message + ": " + (ex.InnerException != null ? ex.InnerException.Message : "");
                return BadRequest(new { Success = false, Message = mensaje });
            }
        }
    }
}
