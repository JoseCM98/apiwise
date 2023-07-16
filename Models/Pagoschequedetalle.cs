namespace Models
{
    public partial class Pagoschequedetalle
    {
        public string CodigoPagoChequeDetalle { get; set; } = null!;
        public string PagosCabeceraPagoDetalle { get; set; } = null!;
        public string PropietarioPagoChequeDetalle { get; set; } = null!;
        public string BancosPagoDetalle { get; set; } = null!;
        public string NumeroCuentaPagoDetalle { get; set; } = null!;
        public int NumeroChequePagoChequeDetalle { get; set; }
        public double ValorDocumentoPagoDetalle { get; set; }
        public DateTime FechaDocumentoPagoDetalle { get; set; }
        /// <summary>
        /// CAJ Caja DEP Depositado DEV Devuelto POS Posfechado
        /// </summary>
        public string EstadoDocumentoPagoDetalle { get; set; } = null!;
        public double AsientosCabeceraPagoDetalle { get; set; }
    }
}
