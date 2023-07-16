namespace apiwise.Models.CProducto.Items.Categorizacion
{
    /// <summary>
    /// Marca;NombreMarca,AbreviadoMarca
    /// </summary>
    public partial class Marca
    {
        public Marca()
        {
            Productos = new HashSet<Producto>();
        }
        public string CodigoMarca { get; set; } = null!;
        public string NombreMarca { get; set; } = null!;
        public string AbreviadoMarca { get; set; } = null!;
        public string PresupuestoMarca { get; set; } = null!;
        public string JefeMarca { get; set; } = null!;
        public string GestionadaRemotamenteMarca { get; set; } = null!;
        public string IconoMarca { get; set; } = null!;
        public string TiposTecnologiaMarca { get; set; } = null!;
        public DateTime FechaRegistroMarca { get; set; }
        public DateTime FechaModificacionMarca { get; set; }
        public int SincronizarEcommerceMarca { get; set; }
        public string EcommerceIdMarca { get; set; } = null!;
        public string UsuariosMarca { get; set; } = null!;
        public string UsuariosModificaMarca { get; set; } = null!;

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
