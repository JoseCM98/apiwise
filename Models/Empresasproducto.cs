using Models;

namespace apiwise.Models
{
    /// <summary>
    /// </summary>
    public partial class Empresasproducto
    {
        public string EmpresasEmpresaProducto { get; set; } = null!;
        public string ProductosEmpresaProducto { get; set; } = null!;
        public decimal CostoProducto { get; set; }
        public decimal PrecioVentaProducto { get; set; }
        public decimal BufferEmpresaProducto { get; set; }
        public string TiposEstadoProductoEmpresaProducto { get; set; } = null!;
        public decimal CostoInicialProducto { get; set; }
        public decimal DescuentoProductoEmpresaProducto { get; set; }
        public int VisualizarDescuentoProductoEmpresaProducto { get; set; }
        public decimal PrecioMarcadoEmpresaProducto { get; set; }
        public decimal MargenUtilidadEmpresaProducto { get; set; }
        public decimal Compraminimamayoristaempresaproducto { get; set; }
        public decimal PorcentajeDescuentoMayoristaempresaproducto { get; set; }
        public int FacturaBajoCostoEmpresaProducto { get; set; }
        public int TieneRecetaXadis { get; set; }
        public int PorcentajeIncrementoEmpresaProducto { get; set; }
        public decimal ValorIce { get; set; }
        public virtual Empresa EmpresasEmpresaProductoNavigation { get; set; } = null!;
        public virtual Producto ProductosEmpresaProductoNavigation { get; set; } = null!;
    }
}
