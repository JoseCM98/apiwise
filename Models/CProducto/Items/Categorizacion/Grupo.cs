namespace apiwise.Models.CProducto.Items.Categorizacion
{
    /// <summary>
    /// Grupo;NombreGrupo,AbreviadoGrupo
    /// </summary>
    public partial class Grupo
    {
        public Grupo()
        {
            Productos = new HashSet<Producto>();
        }
        public string CodigoGrupo { get; set; } = null!;
        public string NombreGrupo { get; set; } = null!;
        public string AbreviadoGrupo { get; set; } = null!;
        public string CategoriasGrupos { get; set; } = null!;
        public string IdMarca { get; set; } = null!;
        public string ActivoGrupo { get; set; } = null!;
        public string PresupuestoGrupo { get; set; } = null!;
        public string UsuariosGrupo { get; set; } = null!;
        public virtual ICollection<Producto> Productos { get; set; }
    }
}
