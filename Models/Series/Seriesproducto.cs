namespace apiwise.Models.Series
{
    /// <summary>
    /// </summary>
    public class Seriesproducto
    {
        public string Id { get; set; } = null!;
        public string NumeroSerieProducto { get; set; } = null!;
        public string DocsCabeceraSerieProducto { get; set; } = null!;
        public string Iddocsdetalle { get; set; } = null!;
        public string ProductosSerieProducto { get; set; } = null!;
        public string EstadosProductoSerieProducto { get; set; } = null!;
        public string BodegasSerieProducto { get; set; } = null!;
        public string DocumentosSerieProducto { get; set; } = null!;
        public DateTime Fecharegistro { get; set; }
        public string UsuariosSerieProducto { get; set; } = null!;
    }
}
