namespace apiwise.Models.CProducto
{
    /// <summary>
    /// </summary>
    public class FromBodyItems
    {
        /// <summary>
        /// </summary>
        public string rucempresa { get; set; }
        /// <summary>
        /// </summary>
        public string iditem { get; set; }
        /// <summary>
        /// </summary>
        public List<string> data { get; set; }
        /// <summary>
        /// </summary>
        public string descripcion { get; set; } = "";
    }
}
