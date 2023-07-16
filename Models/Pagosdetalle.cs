namespace Models
{
    public partial class Pagosdetalle
    {
        public string CodigoPagoDetalle { get; set; } = null!;
        public string PagosCabeceraPagoDetalle { get; set; } = null!;
        public string CreditosDetallePagoDetalle { get; set; } = null!;
        public double ValorPagoDetalle { get; set; }
        /// <summary>
        /// EFE Efectivo CHE Cheque DEP Deposito CRU Cruce Factura TAR Tarjeta
        /// </summary>
        public string FormaPagoPagoCabecera { get; set; } = null!;
        public string NumeroDocumentoPagoDetalle { get; set; } = null!;
        public DateTime FechaDocumentoPagoDetalle { get; set; }
        public string PropietarioPagoDetalle { get; set; } = null!;
        public string BancosPagoDetalle { get; set; } = null!;
        public string NumeroCuentaPagoDetalle { get; set; } = null!;
        public string NumeroChequePagoDetalle { get; set; } = null!;
        public double ValorDocumentoPagoDetalle { get; set; }
        /// <summary>
        /// CAJ Caja DEP Depositado DEV Devuelto POS Posfechado A Anulado
        /// </summary>
        public string EstadoDocumentoPagoDetalle { get; set; } = null!;
        public string ObservacionPagoDetalle { get; set; } = null!;
        public virtual Pagoscabecera PagosCabeceraPagoDetalleNavigation { get; set; } = null!;
    }
}
