namespace Models
{
    public partial class Empresasusuario
    {
        public Empresasusuario()
        {
            Usuariossucursals = new HashSet<Usuariossucursal>();
        }

        public string Id { get; set; } = null!;
        public string Idusuario { get; set; } = null!;
        public string Idempresas { get; set; } = null!;
        public string Idperfil { get; set; } = null!;
        public int Habilitado { get; set; }
        public DateTime Fecharegistra { get; set; }
        public string Usuarioregistra { get; set; } = null!;

        public virtual Empresa IdempresasNavigation { get; set; } = null!;
        public virtual Usuario IdusuarioNavigation { get; set; } = null!;
        public virtual ICollection<Usuariossucursal> Usuariossucursals { get; set; }
    }
}
