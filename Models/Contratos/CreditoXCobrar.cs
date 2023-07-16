namespace apiwise.Models.Contratos
{
    public class CreditoXCobrar
    {
        public string? NumFactura { get; set; }
        public string? Fecha { get; set; }
        public decimal Valor { get; set; }
        public decimal Pago { get; set; }
        public decimal Deuda { get; set; }
        public string? Observacion { get; set; }
    }
}
