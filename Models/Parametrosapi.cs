namespace Models
{
    public partial class Parametrosapi
    {
        public string Idapi { get; set; } = null!;
        public string Empresasapi { get; set; } = null!;
        public string Nombreapi { get; set; } = null!;
        public int Ambienteapi { get; set; }
        public string Usuariopruebaapi { get; set; } = null!;
        public string Contraseniapruebaapi { get; set; } = null!;
        public string Urlpruebaapi { get; set; } = null!;
        public string Usuarioprodapi { get; set; } = null!;
        public string Contraseniaprodapi { get; set; } = null!;
        public string Urlprodapi { get; set; } = null!;
        public string Tokenapi { get; set; } = null!;
        public string Bearertokenapi { get; set; } = null!;
        public int Habilitado { get; set; }
        public int Esservidor { get; set; }
        public int Esexterno { get; set; }
        public string Idempresadestino { get; set; } = null!;
    }
}
