using apiwise.Data;
using apiwise.Interface;
using Models;

namespace apiwise.Service
{
    public class ServicesUsuario : IUserService
    {
        private readonly DataContext _datacontext;
        public ServicesUsuario(DataContext dataContext)
        {
            _datacontext = dataContext;
        }
        public Usuarioapiwise AuthenticateApi(string username, string password)
        {
            if (!string.IsNullOrEmpty(username) || !string.IsNullOrEmpty(password))
            {
                Usuarioapiwise usuarioapiwise = _datacontext.Usuarioapiwises.Where(us => us.Nombre == username && us.Clave.ToString() == password).FirstOrDefault();
                if (usuarioapiwise != null)
                {
                    return usuarioapiwise;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;

            }
        }

        public Empleado AuthenticateEmpleado(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;
            Empleado empleado = _datacontext.Empleados.Where(us => us.NombreUsuarioEmpleado == username && us.ClaveUsuarioEmpleado.ToString() == password).FirstOrDefault();
            if (empleado == null)
                return null;
            return empleado;
        }

        public Usuario AuthenticateUser(string username, string password)
        {
            if (!string.IsNullOrEmpty(username) || !string.IsNullOrEmpty(password))
            {
                Usuario user = _datacontext.Usuarios.Where(us => us.Nombre == username && us.Clave.ToString() == password).FirstOrDefault();
                if (user != null)
                {
                    return user;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;

            }
        }
    }
}
