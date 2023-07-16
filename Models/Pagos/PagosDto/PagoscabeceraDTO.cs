namespace apiwise.Models.Pagos.PagosDto
{
    public class PagoscabeceraDTO
    {
        public string id { get; set; }
        public string empresa { get; set; }
        public string sucursal { get; set; }
        public double numpago { get; set; }
        public DateTime fecha { get; set; }
        public string formapago { get; set; }
        public string tipopago { get; set; }
        public string numerodoc { get; set; }
        public double valorpago { get; set; }
        public double diferencia { get; set; }
        public double valoremplecruze { get; set; }
        public string emplecruze { get; set; }
        public string emplecobro { get; set; }
        public string estado { get; set; }
        public double asientoCab { get; set; } //asiento Cabecera
        public string numrecibo { get; set; }
        public string codmovil { get; set; }
        public string observacion { get; set; }
        public DateTime fecharegistro { get; set; }
        public string usuario { get; set; }
        public int sincronizacion { get; set; }

    }
}
