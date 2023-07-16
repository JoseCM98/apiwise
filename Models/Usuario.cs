namespace Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Empresasusuarios = new HashSet<Empresasusuario>();
            Empresasusuario = new List<Empresasusuario>();
        }

        public string Id { get; set; } = null!;
        public string Idempleados { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public byte[] Clave { get; set; } = null!;
        public int Accesoweb { get; set; }
        public int Caducarclave { get; set; }
        public DateTime Fechacaduca { get; set; }
        public int Cambiadoclave { get; set; }
        public int Sincronizarmovil { get; set; }
        public string Imagen { get; set; } = null!;
        public DateTime Fecharegistra { get; set; }
        public string Usuarioregistra { get; set; } = null!;
        public DateTime Fechamodifica { get; set; }
        public string Usuariomodifica { get; set; } = null!;

        public virtual Empleado IdempleadosNavigation { get; set; } = null!;
        public virtual ICollection<Empresasusuario> Empresasusuarios { get; set; }
        public virtual List<Empresasusuario> Empresasusuario { get; set; }
    }
}
