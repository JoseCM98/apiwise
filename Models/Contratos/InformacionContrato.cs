namespace apiwise.Models.Contratos
{
    public class InformacionContrato
    {
        public string? Idcontrato { get; set; }
        public string? Numerocontrato { get; set; }
        public decimal Valormensual { get; set; }
        public string? Aprobado { get; set; }
        public string? Ipcliente { get; set; }
        public string? Ipmaestro { get; set; }
        public string? Idlocal { get; set; }
        public string? Nombrelocal { get; set; }
        public string? Direccionlocal { get; set; }
        public string? Telefonolocal { get; set; }
        public string? Nombrezona { get; set; }
        public decimal CantidadDeuda { get; set; } = 0;
        public decimal Deudatotal { get; set; } = 0;
        public List<DetalleContrato>? Detalles { get; set; }
        public List<CreditoXCobrar>? Deudaspendiente { get; set; }
        public List<OrdenesServicioTecnico>? ordenesServiciosTecnico { get; set; }
    }
}
