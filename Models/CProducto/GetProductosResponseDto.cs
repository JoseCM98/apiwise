namespace apiwise.Models.CProducto
{
    /// <summary>
    /// </summary>
    public class GetProductosResponseDto
    {
        public string id { get; set; }
        public string idVenta { get; set; }
        public string idCompra { get; set; }
        public string idBarra { get; set; }
        public string idCatalogo { get; set; } = "";
        public string idmultiempresa { get; set; } = "";
        public string descripcion { get; set; }
        public string descAd { get; set; } = "";
        public string descCorta { get; set; } = "";
        public string unidad { get; set; } = "";
        public string linea { get; set; } = "";
        public string categoria { get; set; } = "";
        public string grupo { get; set; } = "";
        public string marca { get; set; } = "";
        public string color { get; set; } = "";
        public string fecha { get; set; } = "1900-01-01";
        public string cuentasCompra { get; set; } = "";
        public string cuentasVenta { get; set; } = "";
        public string cuentasCosto { get; set; } = "";
        public string cuentasDevolu { get; set; } = "";
        public string CuentasContabilidadCuponProducto { get; set; } = "";
        public string CuentasContabilidadDescuentoProducto { get; set; } = "";
        public string cuentasActivo { get; set; } = "";
        public string arancel { get; set; } = "0";
        public string servicio { get; set; } = "0";
        public string pagaIva { get; set; } = "0";
        public string pagaIce { get; set; } = "0";
        public string receta { get; set; } = "0";
        public string venta { get; set; } = "1";
        public string activo { get; set; } = "0";
        public string serie { get; set; } = "0";
        public string lote { get; set; } = "0";
        public decimal unidadCaja { get; set; }
        public decimal peso { get; set; }
        public decimal alto { get; set; }
        public decimal ancho { get; set; }
        public decimal profondidad { get; set; }
        public decimal precioFof { get; set; }
        public string materiaPrima { get; set; } = "0";
        public string ctrlPeso { get; set; } = "0";
        public string repuesto { get; set; } = "0";
        public string sustituto { get; set; } = "0";
        public string accesorio { get; set; } = "0";
        public string favorito { get; set; } = "0";
        public string promo { get; set; } = "0";
        public string percha { get; set; } = "";
        public string cultivo { get; set; } = "";
        public string ctrl { get; set; } = "";
        public string dosis { get; set; } = "";
        public string frecuencia { get; set; } = "";
        public string combo { get; set; } = "0";
        public string descuentoCom { get; set; } = "0";
        public string facturaCombo { get; set; } = "0";
        public string lista { get; set; } = "";
        public string facDecimal { get; set; } = "0";
        public string selecc { get; set; } = "0";
        public string observa { get; set; } = "";
        public string general { get; set; } = "";
        public string ventaja { get; set; } = "";
        public string desventaja { get; set; } = "";
        public string adicional { get; set; } = "";
        public string tipos { get; set; } = "";
        public string proveedor { get; set; } = "";
        public decimal precioProvee { get; set; }
        public decimal variacion { get; set; }
        public decimal metraje { get; set; }
        public decimal porBoni { get; set; }
        public decimal porDescuento { get; set; }
        public decimal cantSumar { get; set; }
        public decimal filasSum { get; set; }
        public decimal recargo { get; set; }
        public string califi { get; set; } = "0";
        public string ctrlFuffer { get; set; } = "0";
        public string tipoIce { get; set; } = "0";
        public string plan { get; set; } = "0";
        public string CompresionServicio { get; set; } = "0";
        public string veriPlazo { get; set; } = "0";
        public string motorChasis { get; set; } = "0";
        public string catServicio { get; set; } = "";
        public string tiempoServicio { get; set; } = "0";
        public decimal cantLitro { get; set; }
        public decimal gradoAlcohol { get; set; }
        public decimal valorPorLitro { get; set; }
        public decimal valorIce { get; set; }
        public string especial { get; set; } = "0";
        public string generaOrden { get; set; } = "0";
        public string sincroApp { get; set; } = "0";
        public string sincroWeb { get; set; } = "0";
        public string tipoExtra { get; set; } = "";
        public decimal descuento { get; set; } = 0;
        public string visuaDesc { get; set; } = "0";
        public string esRecargas { get; set; } = "0";
        public string EcommerceIdProducto { get; set; } = "0";
        public string LineasEcommerceProducto { get; set; } = "0";
        public string CategoriasEcommerceProducto { get; set; } = "0";
        public string GruposEcommerceProducto { get; set; } = "0";
        public string MigarEcommerceProducto { get; set; } = "0";
        public string GruposCaracteristicasProducto { get; set; } = "NULL";
        public string DeshabilitadoProducto { get; set; } = "0";
        public string DeclaraArcsaProducto { get; set; } = "0";
        public string NumeroRegistroSanitarioProducto { get; set; } = "";
        public string NombreComercialProducto { get; set; } = "";
        public string CondicionesAlmacenamientoArcsaProducto { get; set; } = "NULL";
        public string FechaVigenciaRegistroSanitarioProducto { get; set; } = "1900-01-01";
        public string Anio { get; set; }
        public string Tonelaje { get; set; }
        public string PaisOrigen { get; set; }
        public string Combustible { get; set; }
        public string Cilindraje { get; set; }
        public string Capacidad { get; set; }
        public string NumeroEjes { get; set; }
        public string NumeroRuedas { get; set; }
        public string usuario { get; set; } = "wise";

    }
}
