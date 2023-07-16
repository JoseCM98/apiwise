namespace apiwise.Models.CProducto.Items.Categorizacion
{
    /// <summary>
    /// Categoria;NombreCategoria,AbreviadoC
    /// </summary>
    public partial class Categoria
    {
        public Categoria()
        {
            Productos = new HashSet<Producto>();
        }
        public string CodigoCategoria { get; set; } = null!;
        public string NombreCategoria { get; set; } = null!;
        public string AbreviadoCategoria { get; set; } = null!;
        public string LineasCategorias { get; set; } = null!;
        public string ActivaCategoria { get; set; } = null!;
        public string PresupuestoCategoria { get; set; } = null!;
        public string UsuariosCategoria { get; set; } = null!;
        public virtual ICollection<Producto> Productos { get; set; }
    }
}
