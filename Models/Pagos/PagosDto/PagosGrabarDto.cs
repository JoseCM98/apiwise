using Models;

namespace apiwise.Models.Pagos.PagosDto
{
    public class PagosGrabarDto
    {
        public List<Pagoscabecera>? pagoscabecera { get; set; }
        public List<Pagosdetalle>? pagosdetalle { get; set; }
        public List<Pagosmanejoscaja>? pagosmanejoscajas { get; set; }
        public List<Pagosdetalleinterese>? pagosdetalleintereses { get; set; }
        public List<Pagoschequedetalle>? pagoschequedetalle { get; set; }
    }
}
