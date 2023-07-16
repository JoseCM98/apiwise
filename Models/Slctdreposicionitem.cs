namespace Models
{
    /// <summary>
    /// </summary>
    public partial class Slctdreposicionitem
    {
        /// <summary>
        /// </summary>
        public Slctdreposicionitem()
        {
            Slctdreposicionitemdetalle = new List<Slctdreposicionitemdetalle>();
        }
        /// <summary>
        /// </summary>
        public string Id { get; set; } = null!;
        /// <summary>
        /// </summary>
        public string Idempresa { get; set; } = null!;
        /// <summary>
        /// </summary>
        public string Idtiposlct { get; set; } = null!;
        /// <summary>
        /// </summary>
        public string Rucproveedor { get; set; } = null!;
        /// <summary>
        /// </summary>
        public string Rucorigenf { get; set; } = null!;
        /// <summary>
        /// </summary>
        public long Numero { get; set; }
        /// <summary>
        /// </summary>
        public DateTime Fecha { get; set; }
        /// <summary>
        /// </summary>
        public long Numitems { get; set; }
        /// <summary>
        /// </summary>
        public int Mailenviado { get; set; }
        /// <summary>
        /// </summary>
        public string Numfacturaguiap { get; set; } = null!;
        /// <summary>
        /// </summary>
        public string Observaciof { get; set; } = null!;
        /// <summary>
        /// </summary>
        public string Observacionp { get; set; } = null!;
        /// <summary>
        /// </summary>
        public string Usuariosolicitaf { get; set; } = null!;
        /// <summary>
        /// </summary>
        public DateTime Fechasolicitaf { get; set; }
        /// <summary>
        /// </summary>
        public DateTime Fecharecibep { get; set; }
        /// <summary>
        /// </summary>
        public string Usuarioprocesap { get; set; } = null!;
        /// <summary>
        /// </summary>
        public DateTime Fechaprocesadap { get; set; }
        /// <summary>
        /// </summary>
        public string Usuariodespachap { get; set; } = null!;
        /// <summary>
        /// </summary>
        public DateTime Fechadespachap { get; set; }
        /// <summary>
        /// </summary>
        public string Usuariorecibef { get; set; } = null!;
        /// <summary>
        /// </summary>
        public DateTime Fecharecibef { get; set; }
        /// <summary>
        /// </summary>
        public string Usuariorechazadap { get; set; } = null!;
        /// <summary>
        /// </summary>
        public DateTime Fecharechazadap { get; set; }
        /// <summary>
        /// </summary>
        public int Estado { get; set; }
        /// <summary>
        /// </summary>
        public int Reenviardocs { get; set; } = 0;
        /// <summary>
        /// </summary>
        public int Enviadoseriesp { get; set; } = 0;
        /// <summary>
        /// </summary>
        public int Enviadolotesp { get; set; } = 0;
        /// <summary>
        /// </summary>
        public string Iddocsproveedor { get; set; } = "";
        /// <summary>
        /// </summary>
        public decimal Descuentototal { get; set; } = 0;
        /// <summary>
        /// </summary>
        public decimal Descuentototal0 { get; set; } = 0;
        /// <summary>
        /// </summary>
        public decimal Subtotal { get; set; } = 0;
        /// <summary>
        /// </summary>
        public decimal Subtotal0 { get; set; } = 0;
        /// <summary>
        /// </summary>
        public decimal Iva { get; set; } = 0;
        /// <summary>
        /// </summary>
        public string Documento { get; set; } = "N";
        /// <summary>
        /// </summary>
        public string Iddocsorigen { get; set; } = "";
        /// <summary>
        /// </summary>
        public List<Slctdreposicionitemdetalle> Slctdreposicionitemdetalle { get; set; }
    }
}
