namespace Models
{
    public partial class Accionesperfilesslctreposicionitemfranquicium
    {
        /// <summary>
        /// Empresa a la que pertenece la sucursal;combo;true;true;Datos;180;left;Select CodigoEmpresa,NombreEmpresa from Empresas
        /// </summary>
        public string Idempresa { get; set; } = null!;
        /// <summary>
        /// Seleccione el perfil ;combo;true;true;Datos;180;left;SELECT perfiles.CodigoPerfil, perfiles.NombrePerfil FROM perfiles ORDER BY NombrePerfil
        /// </summary>
        public string Idperfilatiende { get; set; } = null!;
        /// <summary>
        /// </summary>
        public string Idtiposlct { get; set; } = null!;
    }
}
