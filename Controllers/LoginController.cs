using apiwise.Helps;
using apiwise.Interface;
using apiwise.Models.Login;
using apiwise.Models.Usuarios;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Models;
using MySqlConnector;

namespace apiwise.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly AppSettings _appSettings;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly ILoggerWise _logger;
        private readonly IProcedureSql _procedureMysql;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appSetting"></param>
        /// <param name="userService"></param>
        /// <param name="mapper"></param>
        /// <param name="logger"></param>
        /// <param name="procedureMysql"></param>
        public LoginController(IOptions<AppSettings> appSetting,
                                IUserService userService,
                                IMapper mapper,
                                ILoggerWise logger,
                                IProcedureSql procedureMysql)
        {
            _appSettings = appSetting.Value;
            _userService = userService;
            _mapper = mapper;
            _logger = logger;
            _procedureMysql = procedureMysql;
        }
        //http://localhost:122/api/login/user
        /// <summary>
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("user")]
        public IActionResult AuthenticateUser([FromBody] Login model)
        {
            _logger.LogInformation("Iniciando el loging");
            try
            {
                Usuario usuario = _userService.AuthenticateUser(model.username, model.password);
                if (usuario != null)
                {
                    var param = new MySqlParameter[]
                    {
                    new MySqlParameter() { ParameterName = "@ParIdUser", Value = usuario.Id},
                    new MySqlParameter() { ParameterName = "@ParIdEmpresa", Value = model.empresa}
                    };
                    Dictionary<string, dynamic> info = _procedureMysql.ExecuteProcedureSqlObj("LoginUserApiWise", param);
                    InfoUsuario infoUser = MapDictionaryToFoo(info);
                    if (infoUser != null)
                    {
                        if (infoUser.accesoweb == 1)
                        {
                            if (infoUser.fechacaduca >= DateTime.Now)
                            {
                                return Ok(infoUser);
                            }
                            else
                            {
                                return BadRequest(new { Success = false, Message = "Su contraseña ha caducado. Cambiela por favor", estado = 1 });
                            }

                        }
                        else
                        {
                            return BadRequest(new { Success = false, Message = $"El usuario {infoUser.nombre} está temporalmente inactivo para usar el Sistema Web.</p> Por favor contactese con el administrador del Sistema para activar al usuario.", estado = 0 });
                        }
                    }
                    else
                    {
                        return BadRequest(new { Success = false, Message = "El usuario no esta creado a la empresa que quiere ingresar.", estado = 0 });
                    }
                }
                else
                {
                    return BadRequest(new { Success = false, Message = "Username or password is incorrect.", estado = 0 });
                }
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message + ": " + (ex.InnerException != null ? ex.InnerException.Message : "");
                _logger.LogError($"ERROR: Authenticate {mensaje} {model}");
                return BadRequest(new { Success = false, Message = mensaje });
            }
        }

        //http://localhost:122/api/login
        //[AllowAnonymous]
        //[HttpPost]
        //public IActionResult Authenticate([FromBody] Login model)
        //{
        //    //var userAuthenticated = _userService.Authenticate(model.username, model.password);
        //    //if (userAuthenticated == null)
        //    //    return BadRequest(new {Success=false,  Message = "Username or password is incorrect" });
        //    Empleados EmpleadoPrueba = new Empleados
        //    {
        //        CodigoEmpleado = "123456",
        //        NombreUsuarioEmpleado = "wise",
        //        ClaveUsuarioEmpleado = "123456"
        //    };
        //    if (EmpleadoPrueba.ClaveUsuarioEmpleado != model.password || EmpleadoPrueba.NombreUsuarioEmpleado != model.username)
        //        return BadRequest(new { Success = false, Message = "Username or password is incorrect" });

        //    var userAuthenticated = EmpleadoPrueba;
        //    _logger.LogInformation("Iniciando la construccion del token");
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(_appSettings.JwtSettings.secret);
        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new Claim[]
        //        {
        //             new Claim(ClaimTypes.NameIdentifier, userAuthenticated.CodigoEmpleado.ToString()),
        //             new Claim(ClaimTypes.Name, userAuthenticated.NombreUsuarioEmpleado.ToString())

        //        }),
        //        Expires = DateTime.UtcNow.AddDays(7),
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //    };
        //    var token = tokenHandler.CreateToken(tokenDescriptor);

        //    // return basic user info (without password) and token to store client side
        //    authenticatedUser userDto = _mapper.Map<authenticatedUser>(userAuthenticated);
        //    userDto.token = tokenHandler.WriteToken(token);
        //    _logger.LogInformation("RETORNA: usuario Authenticate");
        //    return Ok(userDto);

        //}

        InfoUsuario MapDictionaryToFoo(IReadOnlyDictionary<string, dynamic> d)
        {
            return new InfoUsuario
            {
                id = d[nameof(InfoUsuario.id)],
                idempleados = d[nameof(InfoUsuario.idempleados)],
                nombre = d[nameof(InfoUsuario.nombre)],
                empleado = d[nameof(InfoUsuario.empleado)],
                selecempresa = d[nameof(InfoUsuario.selecempresa)],
                selecsucursal = d[nameof(InfoUsuario.selecsucursal)],
                marcar = d[nameof(InfoUsuario.marcar)],
                formulario = d[nameof(InfoUsuario.formulario)],
                vercosto = d[nameof(InfoUsuario.vercosto)],
                accesoweb = d[nameof(InfoUsuario.accesoweb)],
                habilitado = d[nameof(InfoUsuario.habilitado)],
                fechacaduca = d[nameof(InfoUsuario.fechacaduca)],
                imagen = d[nameof(InfoUsuario.imagen)],
                idperfil = d[nameof(InfoUsuario.idperfil)],
                perfil = d[nameof(InfoUsuario.perfil)],
                ruc = d[nameof(InfoUsuario.ruc)],
                nombreempresa = d[nameof(InfoUsuario.nombreempresa)],
                nombrecomercial = d[nameof(InfoUsuario.nombrecomercial)],
                logo = d[nameof(InfoUsuario.logo)]
            };
        }

    }
}
