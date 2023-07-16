namespace Models
{
    public partial class Usuarioapiwise
    {
        public string Id { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public byte[] Clave { get; set; } = null!;
        public string Token { get; set; } = null!;
        public int Estado { get; set; }
        public string Observacion { get; set; } = null!;
        public DateTime Fecharegistro { get; set; }
        public string Usuarioregistra { get; set; } = null!;
        public DateTime Fechaanula { get; set; }
        public string Usuarioanula { get; set; } = null!;
    }
}
