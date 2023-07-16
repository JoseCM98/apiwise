namespace apiwise.Models.Pagos.PagosDto
{
    public class PagoschequedetalleDTO
    {
        public string id { get; set; }
        public string pagocab { get; set; }
        public string propietario { get; set; }
        public string banco { get; set; }
        public string numcuenta { get; set; }
        public int numcheque { get; set; }
        public double valordoc { get; set; }
        public DateTime fechadoc { get; set; }
        public string estadodoc { get; set; }
        public double asientocab { get; set; }
    }
}
