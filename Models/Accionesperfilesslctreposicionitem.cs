namespace Models
{
    /// <summary>
    /// </summary>
    public partial class Accionesperfilesslctreposicionitem
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
        /// Seleccione la Franquicia ;combo;true;true;Datos;180;left;SELECT cliempresaapi.id, cliempresaapi.nombre FROM cliempresaapi ORDER BY nombre
        /// </summary>
        public string Idcliempresa { get; set; } = null!;
        /// <summary>
        /// </summary>
        public string Idperfilfactura { get; set; } = null!;
        /// <summary>
        /// </summary>
        public string Idtiposlct { get; set; } = null!;
    }
}
