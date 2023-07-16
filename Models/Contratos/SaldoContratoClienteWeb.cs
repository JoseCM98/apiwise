namespace apiwise.Models.Contratos
{
    public class SaldoContratoClienteWeb
    {
        public string? Id { get; set; }
        public string? Nombres { get; set; }
        public string? Cedula { get; set; }
        public List<InformacionContrato>? Infocontratos { get; set; }
    }
}
