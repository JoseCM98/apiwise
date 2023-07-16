namespace Models
{
    /// <summary>
    /// Sucursal;NombreSucursal
    /// </summary>
    public partial class Sucursale
    {
        public Sucursale()
        {
            Empleados = new HashSet<Empleado>();
            Usuariossucursals = new HashSet<Usuariossucursal>();
        }

        /// <summary>
        /// Codigo WISE de la sucursal;text;true;false;Datos;180;left
        /// </summary>
        public string CodigoSucursal { get; set; } = null!;
        /// <summary>
        /// Empresa a la que pertenece la sucursal;combo;true;true;Datos;180;left;Select CodigoEmpresa,NombreEmpresa from Empresas
        /// </summary>
        public string EmpresasSucursal { get; set; } = null!;
        /// <summary>
        /// Nombre Sucursal;text;true;true;Datos;180;left
        /// </summary>
        public string NombreSucursal { get; set; } = null!;
        /// <summary>
        /// Direccion Sucursal;text;true;true;Datos;300;left
        /// </summary>
        public string DireccionSucursal { get; set; } = null!;
        /// <summary>
        /// Telefono Uno Sucursal;text;true;true;Datos;180;left
        /// </summary>
        public string TelefonoUnoSucursal { get; set; } = null!;
        /// <summary>
        /// Telefono Dos Sucursal;text;true;true;Datos;180;left
        /// </summary>
        public string TelefonoDosSucursal { get; set; } = null!;
        /// <summary>
        /// Fax Sucursal;text;true;true;Datos;180;left
        /// </summary>
        public string FaxSucursal { get; set; } = null!;
        /// <summary>
        /// Desactivada Sucursal;checkbox;true;true;Datos;180;left
        /// </summary>
        public string ActivaSucursal { get; set; } = null!;
        public string MatrizSucursal { get; set; } = null!;
        public string PaisSucursal { get; set; } = null!;
        public string ProvinciaSucursal { get; set; } = null!;
        /// <summary>
        /// Ciudad a la que pertenece la sucursal;combo;true;true;Datos;180;left;Select CodigoCiudad,NombreCiudad from ciudades ORDER BY NombreCiudad
        /// </summary>
        public string CiudadesSucursal { get; set; } = null!;
        public string ParroquiaSucursal { get; set; } = null!;
        public string LatitudSucursal { get; set; } = null!;
        public string LongitudSucursal { get; set; } = null!;
        public int ZoomUbicacionMapaSucursal { get; set; }
        public string MidRecargasSucursal { get; set; } = null!;
        public string EstablecimientoRdepsucursal { get; set; } = null!;
        public int ActivaAgendamientoSucursal { get; set; }
        public int EsOfflineSucursal { get; set; }
        /// <summary>
        /// Codigo secuencial para identificacion
        /// </summary>
        public int SecuenciaSucursal { get; set; }
        public DateTime FechaRegistroSucursal { get; set; }
        public DateTime FechaModificacionSucursal { get; set; }
        public string UsuariosRegistraSucursal { get; set; } = null!;
        public string UsuarioModificaSucursal { get; set; } = null!;

        public virtual Empresa EmpresasSucursalNavigation { get; set; } = null!;
        public virtual ICollection<Empleado> Empleados { get; set; }
        public virtual ICollection<Usuariossucursal> Usuariossucursals { get; set; }
    }
}
