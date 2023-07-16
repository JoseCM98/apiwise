using System.ComponentModel;

namespace apiwise.Enum
{
    /// <summary>
    /// </summary>
    public enum ProductosEnum
    {
        /// <summary>
        /// </summary>
        activo = 1,
        /// <summary>
        /// </summary>
        inactivo = 0
    }
    /// <summary>
    /// </summary>
    public enum TypeEnum
    {
        /// <summary>
        /// </summary>
        [Description("Informacion")]
        Infor = 1,
        /// <summary>
        /// </summary>
        [Description("Error")]
        Error = 2,
        /// <summary>
        /// </summary>
        [Description("Warning")]
        Warng = 3
    }
    /// <summary>
    /// </summary>
    public static class TipoDocPendientes
    {
        /// <summary>
        /// </summary>
        public static readonly string[] REPOSICION_ITEM_PR = { "SOLICITUD FRANQUICIAS REPOSICION ITEMS", "FRAREI" };
        /// <summary>
        /// </summary>
        public static readonly string[] REPOSICION_ITEM_PR_ORP = { "SOLICITUD FRANQUICIAS REPOSICION ITEMS PUNTUAL", "FRAREIORP" };
        /// <summary>
        /// </summary>
        public static readonly string[] REPOSICION_ITEM_FF = { "REPOSICION ITEMS", "FRAREIR" };
        /// <summary>
        /// </summary>
        public static readonly string[] REPOSICION_ITEM_RECHAZADA = { "RECHAZADA REPOSICION ITEMS", "FREITREC" };
        /// <summary>
        /// </summary>
        public static readonly string ORDEN_PARCIAL = "Pedido Parcial";
    }
    /// <summary>
    /// </summary>
    public static class TipoEstadoFranquicia
    {
        /// <summary>
        /// </summary>
        public static readonly string[] FRAN_INGRESO = { "0", "INGRESO" };
        /// <summary>
        /// </summary>
        public static readonly string[] FRAN_RECIBE_PROV = { "1", "RECIBE PROVEEDOR" };
        /// <summary>
        /// </summary>
        public static readonly string[] FRAN_PROCESADA = { "2", "PROCESADA" };
        /// <summary>
        /// </summary>
        public static readonly string[] FRAN_DESPACHADA = { "3", "DESPACHADA" };
        /// <summary>
        /// </summary>
        public static readonly string[] FRAN_ENTREGADA = { "4", "ENTREGADO" };
        /// <summary>
        /// </summary>
        public static readonly string[] FRAN_RECHAZADA = { "5", "RECHAZADA" };
    }
}
