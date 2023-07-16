namespace apiwise.Models.CProducto.Items.Categorizacion
{
    public partial class Tiposproducto
    {
        public Tiposproducto()
        {
            Productos = new HashSet<Producto>();
        }
        public string CodigoTipoProducto { get; set; } = null!;
        public string DescripcionTipoProducto { get; set; } = null!;
        public string PresentaciónTipoProducto { get; set; } = null!;
        public string UsuariosTipoProductos { get; set; } = null!;
        public virtual ICollection<Producto> Productos { get; set; }
    }
}
