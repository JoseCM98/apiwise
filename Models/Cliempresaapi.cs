namespace Models
{
    public partial class Cliempresaapi
    {
        public string Id { get; set; } = null!;
        public string Idempresa { get; set; } = null!;
        public string Pais { get; set; } = null!;
        public string Provincia { get; set; } = null!;
        public string Canton { get; set; } = null!;
        public string Parroquia { get; set; } = null!;
        public string Idbodega { get; set; } = null!;
        public string Identificacion { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Nombrecomercial { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int Habilitado { get; set; }
        public string Usuarioregistro { get; set; } = null!;
        public DateTime Fecharegistro { get; set; }
        public string Usuariomodifica { get; set; } = null!;
        public DateTime Fechamodifica { get; set; }

        public virtual Empresa IdempresaNavigation { get; set; } = null!;
    }
}
