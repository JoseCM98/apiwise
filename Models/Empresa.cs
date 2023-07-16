using apiwise.Models;

namespace Models
{
    /// <summary>
    /// Empresa;NombreEmpresa
    /// </summary>
    public partial class Empresa
    {
        /// <summary>
        /// </summary>
        public Empresa()
        {
            Cliempresaapis = new HashSet<Cliempresaapi>();
            Empresasusuarios = new HashSet<Empresasusuario>();
            Sucursales = new HashSet<Sucursale>();
            Empresasproductos = new HashSet<Empresasproducto>();
        }

        /// <summary>
        /// Codigo de Empresa;text;true;false;Datos;120;left
        /// </summary>
        public string CodigoEmpresa { get; set; } = null!;
        /// <summary>
        /// Ruc Empresa;text;true;true;Datos;180;left
        /// </summary>
        public string RucEmpresa { get; set; } = null!;
        /// <summary>
        /// Nombre Empresa;text;true;True;Datos;200;left
        /// </summary>
        public string NombreEmpresa { get; set; } = null!;
        public string NombreEmpresaImpresion { get; set; } = null!;
        /// <summary>
        /// Nombre Comercial Empresa;text;true;True;Datos;200;left
        /// </summary>
        public string NombreComercialEmpresa { get; set; } = null!;
        /// <summary>
        /// Codigo DINARDAP Empresa;text;true;True;Datos;200;left
        /// </summary>
        public string CodigoDinardapEmpresa { get; set; } = null!;
        /// <summary>
        /// Logotipo Empresa;text;true;True;Datos;200;left
        /// </summary>
        public string LogoEmpresa { get; set; } = null!;
        /// <summary>
        /// Orden a presentar empresa;text;true;True;Datos;200;left
        /// </summary>
        public int OrdenIncialEmpresa { get; set; }
        /// <summary>
        /// Si está en 0 se visualiza la razón social de la empresa
        /// </summary>
        public int VisualizarNombreComercialEmpresa { get; set; }
        public string UsuariosEmpresa { get; set; } = null!;

        public virtual ICollection<Cliempresaapi> Cliempresaapis { get; set; }
        public virtual ICollection<Empresasusuario> Empresasusuarios { get; set; }
        public virtual ICollection<Sucursale> Sucursales { get; set; }
        public virtual ICollection<Empresasproducto> Empresasproductos { get; set; }
    }
}
