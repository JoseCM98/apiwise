namespace Models
{
    public partial class Usuariossucursal
    {
        public string Idusuarioempresa { get; set; } = null!;
        public string Idsucursal { get; set; } = null!;
        public int Habilitado { get; set; }
        public DateTime Fecharegistro { get; set; }
        public string Usuarioregisro { get; set; } = null!;

        public virtual Sucursale IdsucursalNavigation { get; set; } = null!;
        public virtual Empresasusuario IdusuarioempresaNavigation { get; set; } = null!;
    }
}
