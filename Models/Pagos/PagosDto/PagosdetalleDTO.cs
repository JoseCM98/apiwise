
namespace apiwise.Models.Pagos.PagosDto
{
    public class PagosdetalleDTO
    {
        public string id { get; set; }
        public string pagocab { get; set; }
        public string creditodeta { get; set; }
        public double valor { get; set; }
        public string formpago { get; set; }
        public string numdoc { get; set; }
        public DateTime fechadoc { get; set; }
        public string propietario { get; set; }
        public string banco { get; set; }
        public string numcuenta { get; set; }
        public string numcheque { get; set; }
        public double valordoc { get; set; }
        public string estadodoc { get; set; }
        public string observacion { get; set; }
    }
}
