namespace Models
{
    public partial class Pagoscabecera
    {
        public Pagoscabecera()
        {
            Pagosdetalles = new HashSet<Pagosdetalle>();
            Pagosmanejoscajas = new HashSet<Pagosmanejoscaja>();
            Pagosdetalle = new List<Pagosdetalle>();
            pagosmanejoscaja = new List<Pagosmanejoscaja>();
        }

        public string CodigoPagoCabecera { get; set; } = null!;
        public string EmpresasPagoCabecera { get; set; } = null!;
        public string SucursalesPagoCabecera { get; set; } = null!;
        public double NumeroPagosPagoCabecera { get; set; }
        public DateTime FechaPagoCabecera { get; set; }
        /// <summary>
        /// EFE Efectivo CHE Cheque DEP Deposito CRU Cruce Factura TAR Tarjeta ANT Anticipos
        /// </summary>
        public string FormaPagoPagoCabecera { get; set; } = null!;
        /// <summary>
        /// V Ventas C Compras/Gastos
        /// </summary>
        public string TipoPagoCabecera { get; set; } = null!;
        public string NumeroDocumentoPagoCabecera { get; set; } = null!;
        public double ValorPagoCabecera { get; set; }
        public double DiferenciaPagoCabecera { get; set; }
        public double ValorCruceEmpleadoPagoCabecera { get; set; }
        public string EmpleadoCrucePagoCabecera { get; set; } = null!;
        public string EmpleadosCobroPagoCabecera { get; set; } = null!;
        public string EstadoPagoCabecera { get; set; } = null!;
        public double AsientosCabeceraPagoCabecera { get; set; }
        public string NumeroReciboPagoCabecera { get; set; } = null!;
        public string CodigoMovilPagoCabecera { get; set; } = null!;
        public string ObservacionPagoCabecera { get; set; } = null!;
        public DateTime FechaRegistro { get; set; }
        public string UsuariosPagoCabecera { get; set; } = null!;
        public int EstadoSincronizado { get; set; }

        public virtual ICollection<Pagosdetalle> Pagosdetalles { get; set; }
        public virtual ICollection<Pagosmanejoscaja> Pagosmanejoscajas { get; set; }
        public List<Pagosmanejoscaja> pagosmanejoscaja { get; set; }
        public List<Pagosdetalle> Pagosdetalle { get; set; }
    }
}
