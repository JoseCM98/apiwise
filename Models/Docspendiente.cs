namespace Models
{
    public partial class Docspendiente
    {
        public string DocsCabeceraDocPendiente { get; set; } = null!;
        public string CodigoDocPendiente { get; set; } = null!;
        public string TiposTramitesDocPendiente { get; set; } = null!;
        public string PerfilesDocPendiente { get; set; } = null!;
        public string PerfilesMailBccdocPendiente { get; set; } = null!;
        public DateTime CreacionDocPendiente { get; set; }
        public DateTime AtencionDocPendiente { get; set; }
        public string EstadoDocPendiente { get; set; } = null!;
        public string TipoDocumentoDocPendiente { get; set; } = null!;
    }
}
