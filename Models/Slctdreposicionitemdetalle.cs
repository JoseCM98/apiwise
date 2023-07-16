namespace Models
{
    /// <summary>
    /// </summary>
    public partial class Slctdreposicionitemdetalle
    {
        /// <summary>
        /// </summary>
        public string Id { get; set; } = null!;
        /// <summary>
        /// </summary>
        public string _Idcabecera { get; set; } = null!;
        /// <summary>
        /// </summary>
        public string _Iditem { get; set; } = null!;
        /// <summary>
        /// </summary>
        public string _Idservicioapi { get; set; } = null!;
        /// <summary>
        /// </summary>
        public string Iditemproveedor { get; set; } = null!;
        /// <summary>
        /// </summary>
        public string Descripcion { get; set; } = null!;
        /// <summary>
        /// </summary>
        public decimal Cantidad { get; set; }
        /// <summary>
        /// </summary>
        public decimal Cantdespachada { get; set; }
        /// <summary>
        /// </summary>
        public decimal Cantrequerido { get; set; } = 0;
        /// <summary>
        /// </summary>
        public decimal Costo { get; set; }
        /// <summary>
        /// </summary>
        public int Iva { get; set; }
        /// <summary>
        /// </summary>
        public decimal Precioproveedor { get; set; } = 0;
        /// <summary>
        /// </summary>
        public decimal Descuento { get; set; } = 0;
        /// <summary>
        /// </summary>
        public int Solicitadop { get; set; } = 0;
        /// <summary>
        /// </summary>
        public Slctdreposicionitem? SlctdreposicionitemNavigation { get; set; }
    }
}
