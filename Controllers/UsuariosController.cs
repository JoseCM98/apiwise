namespace apiwise.Controllers
{
    //[Route("[controller]")]
    //[ApiController]
    //[TypeFilter(typeof(ManagerException))]
    //public class UsuariosController : ControllerBase
    //{
    //    public readonly DataContext _datacontext;
    //    private IMapper _mapper;
    //    public readonly ILoggerWise _logger;
    //    public UsuariosController(DataContext dataContext,
    //                              ILoggerWise logger,
    //                              IMapper mapper)
    //    {
    //        _logger = logger;
    //        _mapper = mapper;
    //        _datacontext = dataContext;
    //    }

    //    [HttpGet("{username}/{password}/{empresas}")]
    //    public ActionResult LoginUser(string username, string password, string empresas)
    //    {
    //        _logger.LogInformation("Inicio: LoginUser");
    //        UsuarioEnviar userenviar = new();
    //        ServerRespuesta respuesta = new();
    //        Usuario? usuarioLogin = _datacontext.Usuarios.Include(x => x.Empresasusuarios.Where(e => e.Idempresas == empresas))
    //                                                    .ThenInclude(e => e.IdempresasNavigation)
    //                                                    .Include(em => em.IdempleadosNavigation)
    //                                                    .Where(u => u.Id == username && u.Clave.ToString() == password && u.Empresasusuarios.Any(e => e.Idempresas == empresas))
    //                                                    .FirstOrDefault();
    //        if (usuarioLogin != null)
    //        {
    //            List<string> listaempre = usuarioLogin.Empresasusuarios.Select(s => s.Id).ToList();
    //            List<Usuariossucursal> sucuUsuario = _datacontext.Usuariossucursals.Include(s => s.IdsucursalNavigation)
    //                                                                                .Where(x => listaempre.Contains(x.Idusuarioempresa)).ToList();
    //            EmpleadosDto empresaDto = _mapper.Map<EmpleadosDto>(usuarioLogin.IdempleadosNavigation);
    //            List<Usuariossucursal> sucuUsuarioDto = _mapper.Map<List<Usuariossucursal>>(sucuUsuario);

    //            Usuario usuarioDto = _mapper.Map<Usuario>(usuarioLogin);
    //            userenviar.empleado = empresaDto;
    //            userenviar.empresasusuario = usuarioDto.Empresasusuarios.FirstOrDefault();
    //            usuarioDto.Empresasusuarios = null;
    //            userenviar.usuarios = usuarioDto;
    //            userenviar.usuariossucursal = sucuUsuarioDto;
    //            respuesta.Success = true;
    //            respuesta.Message = "Login Exitoso";
    //            respuesta.ResponsesObject = userenviar;
    //            _logger.LogInformation("Retorna: Usuario Login LoginUser");
    //            return Ok(respuesta);
    //        }
    //        else
    //        {
    //            _logger.LogError($"Error: no existe usuario: {username} con password {password} y empresa {empresas}");
    //            respuesta.Success = false;
    //            respuesta.Message = $"No existe usuario {username} con empresa {empresas}";
    //            return BadRequest(respuesta);
    //        }
    //    }
    //}
}
