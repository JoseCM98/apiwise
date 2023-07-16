namespace apiwise.Models.Contratos
{
    public class DetalleContrato
    {
        public string? Id { get; set; }
        public string? Servicios { get; set; }
        public decimal Cantidad { get; set; }
        public Boolean Estado { get; set; }
        public decimal Valorsinimpuesto { get; set; }
        //public string? Img { get; set; }
    }
}
