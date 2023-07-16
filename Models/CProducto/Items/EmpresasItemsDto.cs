namespace apiwise.Models.CProducto.Items
{
    /// <summary>
    /// </summary>
    public class EmpresasItemsDto
    {
        public string idEmpresa { get; set; }
        public string idItem { get; set; }
        public decimal costo { get; set; } = 0;
        public decimal pvp { get; set; }
        public decimal buffer { get; set; } = 0;
        public string tipoem { get; set; } = "";
        public decimal costoIn { get; set; } = 0;
        public decimal descEmpPro { get; set; } = 0;
        public string visEmpPro { get; set; } = "0";
        public decimal pMarcadoEmpPro { get; set; } = 0;
        public decimal mUtilidadEmpPro { get; set; } = 0;
        public decimal compraminimamayoristaempresaproducto { get; set; } = 0;
        public decimal PorcentajeDescuentoMayoristaempresaproducto { get; set; } = 0;
        public int FacturaBajoCostoEmpresaProducto { get; set; } = 0;
        public int TieneRecetaXadis { get; set; } = 0;
        public decimal PorcentajeIncremento { get; set; } = 0;
        public decimal ValorIce { get; set; } = 0;
    }
}
