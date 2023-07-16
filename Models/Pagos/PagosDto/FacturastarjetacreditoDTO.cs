namespace apiwise.Models.Pagos.PagosDto
{
    public class FacturastarjetacreditoDTO
    {
        public ushort id { get; set; }
        public string facturasCab { get; set; }
        public string tarjetacredi { get; set; }
        public string tiposfinan { get; set; }
        public string numtarjeta { get; set; }
        public double valortarjeta { get; set; }
        public string referencia { get; set; }
        public string lote { get; set; }
        public string pagada { get; set; }
        public string depositotarjetacred { get; set; }
        public string anulado { get; set; }
        public string tipocuentaban { get; set; }
        public string codmovimiento { get; set; }
    }
}
