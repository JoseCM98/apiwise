using Models;

namespace apiwise.Models.Usuarios
{
    public class UsuarioEnviar
    {
        public Usuario usuarios { get; set; }
        public Empresasusuario empresasusuario { get; set; }
        public List<Usuariossucursal> usuariossucursal { get; set; }
    }
}
