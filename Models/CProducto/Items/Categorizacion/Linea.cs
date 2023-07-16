namespace apiwise.Models.CProducto.Items.Categorizacion
{
    public class Linea
    {
        public Linea()
        {
            Productos = new HashSet<Producto>();
        }
        public string CodigoLinea { get; set; }
        public string NombreLinea { get; set; }
        public string AbreviadoLinea { get; set; }
        public string PresupuestoLinea { get; set; }
        public string ActivaLinea { get; set; }
        public string VentaLinea { get; set; }
        public string UsuariosLinea { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }

    }
}
