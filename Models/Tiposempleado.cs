namespace Models
{
    /// <summary>
    /// TipoEmpleado;NombreTipoEmpleado
    /// </summary>
    public partial class Tiposempleado
    {
        public Tiposempleado()
        {
            Empleados = new HashSet<Empleado>();
        }

        /// <summary>
        /// Codigo Tipo Empleado;text;true;false;Datos;180;left
        /// </summary>
        public string CodigoTipoEmpleado { get; set; } = null!;
        /// <summary>
        /// Nombre Tipo Empleado;text;true;true;Datos;180;left
        /// </summary>
        public string NombreTipoEmpleado { get; set; } = null!;
        /// <summary>
        /// Visualiza en listado de vendedores;checkbox;true;true;Datos;180;left
        /// </summary>
        public string EsVendedorTipoEmpleado { get; set; } = null!;
        public string UsuariosTipoEmpleado { get; set; } = null!;

        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
