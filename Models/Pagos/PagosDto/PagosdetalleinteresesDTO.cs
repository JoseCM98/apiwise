namespace apiwise.Models.Pagos.PagosDto
{
    public class PagosdetalleinteresesDTO
    {
        public string id { get; set; }
        public string pagocab { get; set; }
        public string pagodeta { get; set; }
        public string creditodeta { get; set; }
        public decimal baseinte { get; set; }
        public decimal intecuota { get; set; }
        public decimal mora { get; set; }
        public decimal porcenmora { get; set; }
    }
}
