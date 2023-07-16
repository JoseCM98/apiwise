namespace Models
{
    public partial class Pagosmanejoscaja
    {
        public string CodigoPagoManejoCaja { get; set; } = null!;
        public string PagosCabeceraPagoManejoCaja { get; set; } = null!;
        public string ManejoCajasPagoManejoCaja { get; set; } = null!;
        public DateTime FechaRegistroPagoManejoaCaja { get; set; }
        public string UsuariosPagoManejoCaja { get; set; } = null!;

        public virtual Pagoscabecera PagosCabeceraPagoManejoCajaNavigation { get; set; } = null!;
    }
}
