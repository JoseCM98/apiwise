using Models;

namespace apiwise.Interface
{
    public interface IUserService
    {
        Empleado AuthenticateEmpleado(string username, string password);
        Usuario AuthenticateUser(string username, string password);
        Usuarioapiwise AuthenticateApi(string username, string password);
    }
}
