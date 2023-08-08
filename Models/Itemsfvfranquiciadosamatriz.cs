namespace apiwise.Models
{
    /// <summary>
    /// </summary>
    public class Itemsfvfranquiciadosamatriz
    {
        public string Iddetalle { get; set; } = null!;
        public string Identificacion { get; set; } = null!;
        public string Empresa { get; set; } = null!;
        public string Bodega { get; set; } = null!;
        public string Iditem { get; set; } = null!;
        public string Idmultiempresas { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }
        public string Fechafv { get; set; } = null!;
        public int Estado { get; set; }
    }
}
