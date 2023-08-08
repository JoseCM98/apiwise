using apiwise.Models;
using apiwise.Models.Contratos;
using apiwise.Models.Pagos.PagosDto;
using apiwise.Models.Series;
using Microsoft.EntityFrameworkCore;

namespace apiwise.Data
{
    public class DataContextProcedures : DbContext
    {
        public DataContextProcedures() { }
        public DataContextProcedures(DbContextOptions<DataContextProcedures> options)
           : base(options) { }
        public virtual DbSet<SaldoContratoClienteWeb> SaldoContratoClientes { get; set; } = null!;
        public virtual DbSet<InformacionContrato> InformacionContratos { get; set; } = null!;
        public virtual DbSet<DetalleContrato> DetalleContratos { get; set; } = null!;
        public virtual DbSet<CreditoXCobrar> CreditoXCobrars { get; set; } = null!;
        public virtual DbSet<OrdenesServicioTecnico> OrdenesServicioTecnicos { get; set; } = null!;
        public virtual DbSet<ResultPay> ResultPays { get; set; } = null!;
        public virtual DbSet<ResultSlctItems> ResultSlctItems { get; set; } = null!;
        public virtual DbSet<ResultSeriesProductos> ResultSeriesProductos { get; set; } = null!;
        public virtual DbSet<Itemsfvfranquiciadosamatriz> Itemsfvfranquiciadosamatrizs { get; set; } = null!;

        /// <summary>
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SaldoContratoClienteWeb>(entity =>
            {
                entity.HasNoKey();
                entity.Property(e => e.Id);
                entity.Property(e => e.Nombres);
                entity.Property(e => e.Cedula);
            });
            modelBuilder.Entity<InformacionContrato>(entity =>
            {
                entity.HasNoKey();
                entity.Property(e => e.Idcontrato);
                entity.Property(e => e.Numerocontrato);
                entity.Property(e => e.Valormensual);
                entity.Property(e => e.Aprobado);
                entity.Property(e => e.Ipcliente);
                entity.Property(e => e.Ipmaestro);
                entity.Property(e => e.Idlocal);
                entity.Property(e => e.Nombrelocal);
                entity.Property(e => e.Direccionlocal);
                entity.Property(e => e.Telefonolocal);
                entity.Property(e => e.Nombrezona);
                entity.Property(e => e.CantidadDeuda);
            });
            modelBuilder.Entity<DetalleContrato>(entity =>
            {
                entity.HasNoKey();
                entity.Property(e => e.Id);
                entity.Property(e => e.Servicios);
                entity.Property(e => e.Cantidad);
                entity.Property(e => e.Estado);
                entity.Property(e => e.Valorsinimpuesto);
            });
            modelBuilder.Entity<CreditoXCobrar>(entity =>
            {
                entity.HasNoKey();
                entity.Property(e => e.NumFactura);
                entity.Property(e => e.Fecha);
                entity.Property(e => e.Valor);
                entity.Property(e => e.Pago);
                entity.Property(e => e.Deuda);
                entity.Property(e => e.Observacion);
            });
            modelBuilder.Entity<OrdenesServicioTecnico>(entity =>
            {
                entity.HasNoKey();
                entity.Property(e => e.Numeroorden);
                entity.Property(e => e.Nombreasignado);
                entity.Property(e => e.Fechaasignado);
                entity.Property(e => e.Tipodocumento);
                entity.Property(e => e.Estadofinalizado);
                entity.Property(e => e.Fechacreada);
            });
            modelBuilder.Entity<ResultPay>(entity =>
            {
                entity.HasNoKey();
                entity.Property(e => e.Idpago);
                entity.Property(e => e.Numeropago);
            });
            modelBuilder.Entity<ResultSlctItems>(entity =>
            {
                entity.HasNoKey();
                entity.Property(e => e.Numero);
                entity.Property(e => e.IdDocs);
                entity.Property(e => e.Observacion);
                entity.Property(e => e.Fecha);
            });
            modelBuilder.Entity<ResultSeriesProductos>(entity =>
            {
                entity.HasNoKey();
                entity.Property(e => e.Id);
                entity.Property(e => e.NumeroSerieProducto);
                entity.Property(e => e.DocsCabeceraSerieProducto);
                entity.Property(e => e.Iddocsdetalle);
                entity.Property(e => e.ProductosSerieProducto);
                entity.Property(e => e.EstadosProductoSerieProducto);
                entity.Property(e => e.BodegasSerieProducto);
                entity.Property(e => e.DocumentosSerieProducto);
                entity.Property(e => e.Fecharegistro);
                entity.Property(e => e.UsuariosSerieProducto);
            });

            modelBuilder.Entity<Itemsfvfranquiciadosamatriz>(entity =>
            {
                entity.HasNoKey();
                entity.Property(e => e.Iddetalle);
                entity.Property(e => e.Identificacion);
                entity.Property(e => e.Empresa);
                entity.Property(e => e.Bodega);
                entity.Property(e => e.Iditem);
                entity.Property(e => e.Idmultiempresas);
                entity.Property(e => e.Descripcion);
                entity.Property(e => e.Cantidad);
                entity.Property(e => e.Precio);
                entity.Property(e => e.Fechafv);
                entity.Property(e => e.Estado);
            });
        }
    }
}
