namespace Models
{
    public partial class Perfile
    {
        public Perfile()
        {
            Empleados = new HashSet<Empleado>();
        }

        /// <summary>
        /// Codigo de Perfil;text;true;false;Datos;180;left
        /// </summary>
        public string CodigoPerfil { get; set; } = null!;
        /// <summary>
        /// Nombre de Perfil;text;true;true;Datos;180;left
        /// </summary>
        public string NombrePerfil { get; set; } = null!;

        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
