using apiwise.Data;
using apiwise.Helps;
using apiwise.Interface;
using apiwise.Models.Ecommerce;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace apiwise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EccomerController : ControllerBase
    {
        public readonly DataContext _datacontext;
        private readonly ILoggerWise _logger;
        private readonly IUriService uriService;
        public EccomerController(DataContext datacontext,
                                     ILoggerWise logger
            , IUriService uriService)
        {
            _logger = logger;
            _datacontext = datacontext;
            this.uriService = uriService;
        }
        //http://localhost:100/api/Eccomer/stock
        //{ "data" : [ "200214173444945", "200210184002451" ] }
        [HttpGet("stock")]
        public async Task<IActionResult> GetStock([FromBody] InterfazStockProducts filter)
        {
            try
            {
                if (filter.data == null)
                {
                    List<Stockproductsecommerce> listStok = await _datacontext.Stockproductsecommerces.ToListAsync();
                    if (listStok.Count > 0)
                    {
                        return Ok(listStok);
                    }
                    else
                    {
                        return BadRequest(new { Success = false, Message = "No existe datos de productos." });
                    }
                }
                else
                {
                    if (filter.data.Count > 0)
                    {
                        List<Stockproductsecommerce> listStok = await _datacontext.Stockproductsecommerces.Where(x => filter.data.Contains(x.Id)).ToListAsync();
                        if (listStok.Count > 0)
                        {
                            return Ok(listStok);
                        }
                        else
                        {
                            return BadRequest(new { Success = false, Message = "No existe datos de productos." });
                        }
                    }
                    else
                    {
                        return BadRequest(new { Success = false, Message = "Parametros de consultas incorrectas" });
                    }
                }
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message + ": " + (ex.InnerException != null ? ex.InnerException.Message : "");
                return BadRequest(new { Success = false, Message = mensaje });
            }
        }

        // GET api/<EccomerController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EccomerController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EccomerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EccomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
