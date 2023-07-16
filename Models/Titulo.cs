namespace Models
{
    /// <summary>
    /// Titulo;NombreTitulo
    /// </summary>
    public partial class Titulo
    {
        public Titulo()
        {
            Empleados = new HashSet<Empleado>();
        }

        /// <summary>
        /// Codigo Titulo;text;true;false;datos;120;left
        /// </summary>
        public string CodigoTitulo { get; set; } = null!;
        /// <summary>
        /// Nombre Titulo;text;true;true;datos;200;left
        /// </summary>
        public string NombreTitulo { get; set; } = null!;
        public string UsuariosTitulo { get; set; } = null!;

        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
