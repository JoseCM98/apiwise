using apiwise.Models;
using apiwise.Models.CProducto.Items.Categorizacion;
using apiwise.Models.Series;
using Microsoft.EntityFrameworkCore;
using Models;

namespace apiwise.Data
{
    /// <summary>
    /// </summary>
    public partial class DataContext : DbContext
    {
        /// <summary>
        /// </summary>
        public DataContext()
        {
        }
        /// <summary>
        /// </summary>
        /// <param name="options"></param>
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
        /// <summary>
        /// </summary>
        public virtual DbSet<Accionesperfilesslctreposicionitem> Accionesperfilesslctreposicionitems { get; set; } = null!;
        /// <summary>
        /// </summary>
        public virtual DbSet<Accionesperfilesslctreposicionitemfranquicium> Accionesperfilesslctreposicionitemfranquicia { get; set; } = null!;
        /// <summary>
        /// </summary>
        public virtual DbSet<Docspendiente> Docspendientes { get; set; } = null!;
        /// <summary>
        /// </summary>
        public virtual DbSet<Empleado> Empleados { get; set; } = null!;
        /// <summary>
        /// </summary>
        public virtual DbSet<Empresa> Empresas { get; set; } = null!;
        /// <summary>
        /// </summary>
        public virtual DbSet<Empresasusuario> Empresasusuarios { get; set; } = null!;
        /// <summary>
        /// </summary>
        public virtual DbSet<Pagoscabecera> Pagoscabeceras { get; set; } = null!;
        /// <summary>
        /// </summary>
        public virtual DbSet<Pagoscheque> Pagoscheques { get; set; } = null!;
        /// <summary>
        /// </summary>
        public virtual DbSet<Pagoschequedetalle> Pagoschequedetalles { get; set; } = null!;
        /// <summary>
        /// </summary>
        public virtual DbSet<Pagosdetalle> Pagosdetalles { get; set; } = null!;
        /// <summary>
        /// </summary>
        public virtual DbSet<Pagosdetalleinterese> Pagosdetalleintereses { get; set; } = null!;
        /// <summary>
        /// </summary>
        public virtual DbSet<Pagosmanejoscaja> Pagosmanejoscajas { get; set; } = null!;
        /// <summary>
        /// </summary>
        public virtual DbSet<Parametrosapi> Parametrosapis { get; set; } = null!;
        /// <summary>
        /// </summary>
        public virtual DbSet<Perfile> Perfiles { get; set; } = null!;
        /// <summary>
        /// </summary>
        public virtual DbSet<Slctdreposicionitem> Slctdreposicionitems { get; set; } = null!;
        /// <summary>
        /// </summary>
        public virtual DbSet<Slctdreposicionitemdetalle> Slctdreposicionitemdetalles { get; set; } = null!;
        /// <summary>
        /// </summary>
        public virtual DbSet<Stockproductsecommerce> Stockproductsecommerces { get; set; } = null!;
        /// <summary>
        /// </summary>
        public virtual DbSet<Seriesproducto> Seriesproductos { get; set; } = null!;
        /// <summary>
        /// </summary>
        public virtual DbSet<Sucursale> Sucursales { get; set; } = null!;
        /// <summary>
        /// </summary>
        public virtual DbSet<Tiposempleado> Tiposempleados { get; set; } = null!;
        /// <summary>
        /// </summary>
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        /// <summary>
        /// </summary>
        public virtual DbSet<Usuarioapiwise> Usuarioapiwises { get; set; } = null!;
        /// <summary>
        /// </summary>
        public virtual DbSet<Usuariossucursal> Usuariossucursals { get; set; } = null!;
        /// <summary>
        /// </summary>
        public virtual DbSet<Cliempresaapi> Cliempresaapis { get; set; } = null!;
        /// <summary>
        /// </summary>
        public virtual DbSet<Titulo> Titulos { get; set; } = null!;
        /// <summary>
        /// </summary>
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        /// <summary>
        /// </summary>
        public virtual DbSet<Empresasproducto> Empresasproductos { get; set; } = null!;
        /// <summary>
        /// </summary>
        public virtual DbSet<Linea> Lineas { get; set; } = null!;
        public virtual DbSet<Categoria> Categorias { get; set; } = null!;
        public virtual DbSet<Grupo> Grupos { get; set; } = null!;
        public virtual DbSet<Marca> Marcas { get; set; } = null!;
        public virtual DbSet<Tiposproducto> Tiposproductos { get; set; } = null!;
        /// <summary>
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("latin1_swedish_ci").HasCharSet("latin1");

            modelBuilder.Entity<Accionesperfilesslctreposicionitem>(entity =>
            {
                entity.HasKey(e => new { e.Idempresa, e.Idperfilatiende, e.Idcliempresa }).HasName("PRIMARY").HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });
                entity.ToTable("accionesperfilesslctreposicionitem");
                entity.HasIndex(e => e.Idcliempresa, "_idcliempresa");
                entity.HasIndex(e => e.Idperfilatiende, "_idperfilatiende");
                entity.HasIndex(e => e.Idtiposlct, "_idtiposlct");
                entity.HasIndex(e => e.Idempresa, "idempresa");
                entity.Property(e => e.Idempresa).HasMaxLength(20).HasColumnName("idempresa").HasComment("Empresa a la que pertenece la sucursal;combo;true;true;Datos;180;left;Select CodigoEmpresa,NombreEmpresa from Empresas");
                entity.Property(e => e.Idperfilatiende).HasMaxLength(20).HasColumnName("_idperfilatiende").HasComment("Seleccione el perfil ;combo;true;true;Datos;180;left;SELECT perfiles.CodigoPerfil, perfiles.NombrePerfil FROM perfiles ORDER BY NombrePerfil");
                entity.Property(e => e.Idcliempresa).HasMaxLength(36).HasColumnName("_idcliempresa").HasComment("Seleccione la Franquicia ;combo;true;true;Datos;180;left;SELECT cliempresaapi.id, cliempresaapi.nombre FROM cliempresaapi ORDER BY nombre");
                entity.Property(e => e.Idperfilfactura).HasMaxLength(36).HasColumnName("_idperfilfactura");
                entity.Property(e => e.Idtiposlct).HasMaxLength(36).HasColumnName("_idtiposlct");
            });

            modelBuilder.Entity<Accionesperfilesslctreposicionitemfranquicium>(entity =>
            {
                entity.HasKey(e => new { e.Idempresa, e.Idperfilatiende }).HasName("PRIMARY").HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                entity.ToTable("accionesperfilesslctreposicionitemfranquicia");
                entity.HasIndex(e => e.Idperfilatiende, "_idperfilatiende");
                entity.HasIndex(e => e.Idempresa, "idempresa");
                entity.HasIndex(e => e.Idtiposlct, "_idtiposlct");
                entity.Property(e => e.Idempresa).HasMaxLength(20).HasColumnName("idempresa").HasComment("Empresa a la que pertenece la sucursal;combo;true;true;Datos;180;left;Select CodigoEmpresa,NombreEmpresa from Empresas");
                entity.Property(e => e.Idperfilatiende).HasMaxLength(20).HasColumnName("_idperfilatiende").HasComment("Seleccione el perfil ;combo;true;true;Datos;180;left;SELECT perfiles.CodigoPerfil, perfiles.NombrePerfil FROM perfiles ORDER BY NombrePerfil");
                entity.Property(e => e.Idtiposlct).HasMaxLength(36).HasColumnName("_idtiposlct");
            });

            modelBuilder.Entity<Docspendiente>(entity =>
            {
                entity.HasKey(e => e.CodigoDocPendiente).HasName("PRIMARY");
                entity.ToTable("docspendientes");
                entity.HasIndex(e => e.AtencionDocPendiente, "AtencionDocPendiente");
                entity.HasIndex(e => e.DocsCabeceraDocPendiente, "Codigo");
                entity.HasIndex(e => e.CreacionDocPendiente, "CreacionDocPendiente");
                entity.HasIndex(e => e.CodigoDocPendiente, "DocsPendientes").IsUnique();
                entity.HasIndex(e => e.EstadoDocPendiente, "EstadoDocPendiente");
                entity.HasIndex(e => new { e.TiposTramitesDocPendiente, e.EstadoDocPendiente, e.TipoDocumentoDocPendiente }, "PENDIENTE X BODEGA");
                entity.HasIndex(e => e.PerfilesDocPendiente, "PerfilesDocPendiente");
                entity.HasIndex(e => e.TipoDocumentoDocPendiente, "TipoDocumentoDocPendiente");
                entity.HasIndex(e => e.TiposTramitesDocPendiente, "TiposTramitesDocPendiente");
                entity.Property(e => e.CodigoDocPendiente).HasMaxLength(20).HasDefaultValueSql("''");
                entity.Property(e => e.AtencionDocPendiente).HasColumnType("datetime");
                entity.Property(e => e.CreacionDocPendiente).HasColumnType("datetime");
                entity.Property(e => e.DocsCabeceraDocPendiente).HasMaxLength(36).HasDefaultValueSql("''");
                entity.Property(e => e.EstadoDocPendiente).HasMaxLength(20).HasDefaultValueSql("''");
                entity.Property(e => e.PerfilesDocPendiente).HasMaxLength(20).HasDefaultValueSql("''");
                entity.Property(e => e.PerfilesMailBccdocPendiente).HasMaxLength(255).HasColumnName("PerfilesMailBCCDocPendiente").HasDefaultValueSql("''");
                entity.Property(e => e.TipoDocumentoDocPendiente).HasMaxLength(20).HasDefaultValueSql("''");
                entity.Property(e => e.TiposTramitesDocPendiente).HasDefaultValueSql("''");
            });
            modelBuilder.Entity<Cliempresaapi>(entity =>
            {
                entity.HasKey(e => new { e.Identificacion, e.Idempresa }).HasName("PRIMARY").HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                entity.ToTable("cliempresaapi");
                entity.HasIndex(e => e.Idempresa, "_idempresa");
                entity.HasIndex(e => e.Id, "id").IsUnique();
                entity.HasIndex(e => e.Identificacion, "identificacion");
                entity.Property(e => e.Identificacion).HasMaxLength(15).HasColumnName("identificacion");
                entity.Property(e => e.Idempresa).HasMaxLength(20).HasColumnName("_idempresa");
                entity.Property(e => e.Canton).HasMaxLength(20).HasColumnName("_canton");
                entity.Property(e => e.Email).HasMaxLength(200).HasColumnName("email");
                entity.Property(e => e.Fechamodifica).HasColumnType("datetime").HasColumnName("fechamodifica");
                entity.Property(e => e.Fecharegistro).HasColumnType("datetime").HasColumnName("fecharegistro");
                entity.Property(e => e.Habilitado).HasColumnType("int(1)").HasColumnName("habilitado");
                entity.Property(e => e.Id).HasMaxLength(36).HasColumnName("id");
                entity.Property(e => e.Idbodega).HasMaxLength(20).HasColumnName("_idbodega");
                entity.Property(e => e.Nombre).HasMaxLength(100).HasColumnName("nombre");
                entity.Property(e => e.Nombrecomercial).HasMaxLength(100).HasColumnName("nombrecomercial");
                entity.Property(e => e.Pais).HasMaxLength(20).HasColumnName("_pais");
                entity.Property(e => e.Parroquia).HasMaxLength(20).HasColumnName("_parroquia");
                entity.Property(e => e.Provincia).HasMaxLength(20).HasColumnName("_provincia");
                entity.Property(e => e.Usuariomodifica).HasMaxLength(20).HasColumnName("usuariomodifica");
                entity.Property(e => e.Usuarioregistro).HasMaxLength(20).HasColumnName("usuarioregistro");
                entity.HasOne(d => d.IdempresaNavigation).WithMany(p => p.Cliempresaapis).HasForeignKey(d => d.Idempresa).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_idempresa_api");
            });
            modelBuilder.Entity<Titulo>(entity =>
            {
                entity.HasKey(e => e.CodigoTitulo).HasName("PRIMARY");
                entity.ToTable("titulos");
                entity.HasComment("Titulo;NombreTitulo");
                entity.HasIndex(e => e.NombreTitulo, "Index_Nombre").IsUnique();
                entity.Property(e => e.CodigoTitulo).HasMaxLength(20).HasComment("Codigo Titulo;text;true;false;datos;120;left");
                entity.Property(e => e.NombreTitulo).HasMaxLength(60).HasComment("Nombre Titulo;text;true;true;datos;200;left");
                entity.Property(e => e.UsuariosTitulo).HasMaxLength(20);
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.CodigoEmpleado).HasName("PRIMARY");

                entity.ToTable("empleados");

                entity.HasComment("Empleado;NombreEmpleado,ApellidoEmpleado");

                entity.HasIndex(e => e.CodigoEmpleado, "CodigoEmpleado");

                entity.HasIndex(e => e.TipoIdentificacionReemplazaEmpleado, "FK_TipoIdentificacionReemplaza_Empleado");

                entity.HasIndex(e => e.TiposIdentificacionEmpleado, "FK_TipoIdentificacion_Empleado");

                entity.HasIndex(e => e.TiposEmpleadosEmpleado, "FK_empleados_TipoEmpleado");

                entity.HasIndex(e => e.TitulosEmpleado, "FK_empleados_Titulos");

                entity.HasIndex(e => e.ApellidoEmpleado, "Index_Apellido");

                entity.HasIndex(e => e.CedulaEmpleado, "Index_Cedula");

                entity.HasIndex(e => e.NombreEmpleado, "Index_Nombre");

                entity.HasIndex(e => new { e.NombreEmpleado, e.ApellidoEmpleado }, "NombreApellido").IsUnique();

                entity.HasIndex(e => e.PerfilesEmpleado, "PerfilesEmpleado");

                entity.HasIndex(e => e.NombreUsuarioEmpleado, "Usuario").IsUnique();

                entity.HasIndex(e => e.SucursalesEmpleado, "sucursales_fk");

                entity.Property(e => e.CodigoEmpleado).HasMaxLength(20).HasDefaultValueSql("''").HasComment("Codigo;text;true;false;Administracion;180;left");

                entity.Property(e => e.AdelantoQuincenalEmpleado).HasColumnType("double(16,4)").HasDefaultValueSql("'0.0000'");

                entity.Property(e => e.ApellidoEmpleado).HasMaxLength(100).HasDefaultValueSql("''").HasComment("Apellidos;text;true;true;Administracion;180;left");

                entity.Property(e => e.BonoAlimentacionEmpleado).HasColumnType("double(16,4)");

                entity.Property(e => e.BonoFijoEmpleado).HasColumnType("double(16,4)");

                entity.Property(e => e.BonoVariableEmpleado).HasColumnType("double(16,4)");

                entity.Property(e => e.CalcularFondosReservaEmpleado).HasMaxLength(1).HasDefaultValueSql("''");

                entity.Property(e => e.CambiadoClaveEmpleado).HasMaxLength(1).HasDefaultValueSql("''").HasComment("0 No ha cambiado 1 Cambio clave");

                entity.Property(e => e.CambiarPrimeraVezEmpleado).HasMaxLength(1).HasDefaultValueSql("''").HasComment("1 Cambiar 0 No Cambiar");

                entity.Property(e => e.CargaFamiliarEmpleado).HasColumnType("int(11)").HasComment("Numero de Cargas Familiares;text;true;true;Datos Personales;180;left");

                entity.Property(e => e.CedulaEmpleado).HasMaxLength(10).HasDefaultValueSql("''").HasComment("Número de Cédula;text;true;true;Datos Personales;180;left");

                entity.Property(e => e.CedulaRemplazoDiscapacidadEmplead).HasMaxLength(10).HasDefaultValueSql("''");

                entity.Property(e => e.ClaveCaducaEmpleado).HasMaxLength(1).HasDefaultValueSql("''").HasComment("0 No Caduca 1 Si Caduca");

                entity.Property(e => e.ClaveUsuarioEmpleado).HasColumnType("blob").HasComment("Clave Personal;txt;true;true;Administracion;180;left");

                entity.Property(e => e.ConvenioEvitarDobleImposicionEmpleado).HasMaxLength(2).HasDefaultValueSql("'NA'");

                entity.Property(e => e.CostaEmpleado).HasMaxLength(1).HasDefaultValueSql("''").HasComment("Determina si un empleado trabaja en la costa");

                entity.Property(e => e.CuentaBancariaEmpleado).HasMaxLength(30).HasComment("numero de cta bancaria del empleado");

                entity.Property(e => e.CuentasBancariasOrigenEmpleado).HasMaxLength(20).HasDefaultValueSql("'0'");

                entity.Property(e => e.CuentasContabilidadAnticipoEmpleado).HasMaxLength(20).HasDefaultValueSql("''");

                entity.Property(e => e.CuentasContabilidadAtrazoEmpleado).HasMaxLength(20).HasDefaultValueSql("''");

                entity.Property(e => e.CuentasContabilidadBonoAlimenticio).HasMaxLength(20).HasDefaultValueSql("'0.00.00.000.000'");

                entity.Property(e => e.CuentasContabilidadBonoFijo).HasMaxLength(20).HasDefaultValueSql("'0.00.00.000.000'");

                entity.Property(e => e.CuentasContabilidadBonoVariable).HasMaxLength(20).HasDefaultValueSql("'0.00.00.000.000'");

                entity.Property(e => e.CuentasContabilidadComisionesEmpleado).HasMaxLength(20).HasDefaultValueSql("'5.01.02.005.001'");

                entity.Property(e => e.CuentasContabilidadDesahucioEmpleado).HasMaxLength(20);

                entity.Property(e => e.CuentasContabilidadDespidoEmpleado).HasMaxLength(20);

                entity.Property(e => e.CuentasContabilidadEmpleado).HasMaxLength(18).HasDefaultValueSql("''").HasComment("Cuenta Contable Asignada;cmd;true;true;Contabilidad;180;left;Select CodigoCuentaContable, NombreCuentaContable from cuentascontabilidad");

                entity.Property(e => e.CuentasContabilidadFondoReservaEmpleado).HasMaxLength(20).HasDefaultValueSql("''");

                entity.Property(e => e.CuentasContabilidadGastoDesahucioEmpleado).HasMaxLength(20);

                entity.Property(e => e.CuentasContabilidadGastoEmpleado).HasMaxLength(20).HasDefaultValueSql("''");

                entity.Property(e => e.CuentasContabilidadHoraExtraordinariaEmpleado).HasMaxLength(20).HasDefaultValueSql("''");

                entity.Property(e => e.CuentasContabilidadHoraJornadaNocturna).HasMaxLength(20);

                entity.Property(e => e.CuentasContabilidadHoraSuplementariaEmpleado).HasMaxLength(20).HasDefaultValueSql("''");

                entity.Property(e => e.CuentasContabilidadIessEmpleado).HasMaxLength(20).HasDefaultValueSql("''");

                entity.Property(e => e.CuentasContabilidadIessGastoPatronalEmpleado).HasMaxLength(20).HasDefaultValueSql("'5.01.02.002.002'");

                entity.Property(e => e.CuentasContabilidadIessPatronalEmpleado).HasMaxLength(20).HasDefaultValueSql("''");

                entity.Property(e => e.CuentasContabilidadMultaEmpleado).HasMaxLength(20).HasDefaultValueSql("''");

                entity.Property(e => e.CuentasContabilidadNominasEmpleado).HasMaxLength(20).HasDefaultValueSql("'2.01.07.003.001'");

                entity.Property(e => e.CuentasContabilidadOtrosEgresosEmpleado).HasMaxLength(20);

                entity.Property(e => e.CuentasContabilidadOtrosIngresosEmpleado).HasMaxLength(20);

                entity.Property(e => e.CuentasContabilidadPrestamoEmpleado).HasMaxLength(20).HasDefaultValueSql("''");

                entity.Property(e => e.CuentasContabilidadPrestamosIess).HasMaxLength(20).HasDefaultValueSql("'2.01.07.001.003'");

                entity.Property(e => e.CuentasContabilidadProvisionDecimoXiiiempleado).HasMaxLength(20).HasColumnName("CuentasContabilidadProvisionDecimoXIIIEmpleado").HasDefaultValueSql("'2.01.07.001.001'");

                entity.Property(e => e.CuentasContabilidadProvisionDecimoXivempleado).HasMaxLength(20).HasColumnName("CuentasContabilidadProvisionDecimoXIVEmpleado").HasDefaultValueSql("'2.01.07.001.002'");

                entity.Property(e => e.CuentasContabilidadProvisionFondoReservaEmpleado).HasMaxLength(20).HasDefaultValueSql("'2.01.07.001.004'");

                entity.Property(e => e.CuentasContabilidadProvisionVacacionesEmpleado).HasMaxLength(20).HasDefaultValueSql("'2.01.07.001.003'");

                entity.Property(e => e.CuentasContabilidadQuincena).HasMaxLength(20).HasDefaultValueSql("'1.01.02.010.160'");

                entity.Property(e => e.CuentasContabilidadRubrosEmpleado).HasMaxLength(20).HasDefaultValueSql("''");

                entity.Property(e => e.CuentasContabilidadSaldoEmpleado).HasMaxLength(20).HasDefaultValueSql("''");

                entity.Property(e => e.CuentasContabilidadVacacionEmpleado).HasMaxLength(20).HasDefaultValueSql("''");

                entity.Property(e => e.CuentasContabilidadViaticoEmpleado).HasMaxLength(20).HasDefaultValueSql("''");

                entity.Property(e => e.CuentasContabilidadXiiiEmpleado).HasMaxLength(20).HasDefaultValueSql("''");

                entity.Property(e => e.CuentasContabilidadXivEmpleado).HasMaxLength(20).HasDefaultValueSql("''");

                entity.Property(e => e.DiasLaboraTiempoParcialEmpleado).HasMaxLength(3).HasDefaultValueSql("'0'").HasComment("indica los dias que el empleado labora si trabaja a tiempo parcial.");

                entity.Property(e => e.DireccionDosEmpleado).HasMaxLength(255).HasDefaultValueSql("''").HasComment("Direccion Adicional;text;true;true;Datos Personales;180;left");

                entity.Property(e => e.DireccionUnoEmpleado).HasMaxLength(255).HasDefaultValueSql("''").HasComment("Domicilio;text;true;true;Datos Personales;180;left");

                entity.Property(e => e.DiscapacidadEmpleado).HasMaxLength(20).HasDefaultValueSql("''");

                entity.Property(e => e.DuracionContratoEmpleado).HasMaxLength(3).HasComment("numero de meses que dura el contrato del empleado con la empresa");

                entity.Property(e => e.EmailEmpleado).HasMaxLength(255).HasDefaultValueSql("''").HasComment("Email Oficina;text;true;true;Administracion;180;left");

                entity.Property(e => e.EmailEmpleadoPersonal).HasMaxLength(255).HasDefaultValueSql("'NA'").HasComment("Email Personal;text;true;true;Datos Personales;180;left");

                entity.Property(e => e.EmpresasEmpleado).HasMaxLength(20).HasDefaultValueSql("''");

                entity.Property(e => e.EntregarDecimoEmpleado).HasMaxLength(1).HasDefaultValueSql("'0'").HasComment("indica si el empleado quiere recibir el decimo en el salario mensual. 1 mensual, 0 no mensual.");

                entity.Property(e => e.EntregarDecimoIvempleado).HasMaxLength(1).HasColumnName("EntregarDecimoIVEmpleado").HasDefaultValueSql("'0'");

                entity.Property(e => e.EspecialidadesMedicasEmpleado).HasMaxLength(20).HasDefaultValueSql("'0'");

                entity.Property(e => e.EstadosCivilesPersonasEmpleados).HasMaxLength(20);

                entity.Property(e => e.FechaCaducaClaveEmpleado).HasDefaultValueSql("'1900-01-01'");

                entity.Property(e => e.FechaCaducaUsuarioEmpleado).HasDefaultValueSql("'1900-01-01'");

                entity.Property(e => e.FechaCalculoVacacionesEmpleado).HasDefaultValueSql("'1900-01-01'");

                entity.Property(e => e.FechaNacimientoEmpleado).HasDefaultValueSql("'1900-01-01'").HasComment("Fecha de Nacimiento;cal;true;true;Datos Personales;180;left");

                entity.Property(e => e.FondosReservaEmpleado).HasMaxLength(1).HasDefaultValueSql("''").HasComment("Determina si a un empleado se le entrega directamente los fondo de reserva");

                entity.Property(e => e.FormularioInicialEmpleado).HasMaxLength(255).HasDefaultValueSql("'frmmarcacion.aspx'");

                entity.Property(e => e.GeneroEmpleado).HasMaxLength(1);

                entity.Property(e => e.HoraExtraEmpleado).HasMaxLength(1).HasDefaultValueSql("''");

                entity.Property(e => e.HoraIngresoEmpleado).HasColumnType("time").HasDefaultValueSql("'08:30:00'").HasComment("Almacena la hora de ingreso en la mañana");

                entity.Property(e => e.HoraSalidaEmpleado).HasColumnType("time").HasDefaultValueSql("'18:00:00'").HasComment("Almacena la hora de la salida en la tarde");

                entity.Property(e => e.IesscodigosSectorialesEmpleado).HasMaxLength(20).HasColumnName("IESSCodigosSectorialesEmpleado");

                entity.Property(e => e.ImagenEmpleado).HasMaxLength(100).HasDefaultValueSql("'General/Avatar.svg'");

                entity.Property(e => e.Ip).HasMaxLength(52).HasColumnName("IP").HasDefaultValueSql("''");

                entity.Property(e => e.LetraCambioEmpleado).HasColumnType("double(16,2)");

                entity.Property(e => e.MarcarEmpleado).HasMaxLength(1).HasDefaultValueSql("''");

                entity.Property(e => e.NoCalculaBeneficiosEmpleado).HasMaxLength(1).HasDefaultValueSql("'0'").HasComment("indica si el empleado calculo beneficios sociales");

                entity.Property(e => e.NombreEmpleado).HasMaxLength(150).HasDefaultValueSql("''").HasComment("Nombres;text;true;true;Administracion;180;left");

                entity.Property(e => e.NombreUsuarioEmpleado).HasMaxLength(20).HasDefaultValueSql("''").HasComment("Nombre de Usuario;text;true;true;Administracion;180;left");

                entity.Property(e => e.NumeroCarnetConadisEmpleado).HasMaxLength(20);

                entity.Property(e => e.NumeroDiasFinSemanaVacacionTomadosEmpleado).HasColumnType("int(3)");

                entity.Property(e => e.NumeroDiasHabilesVacacionTomadosEmpleado).HasColumnType("int(3)");

                entity.Property(e => e.PaisResidenciaEmpleado).HasMaxLength(20).HasDefaultValueSql("'593'");

                entity.Property(e => e.PerfilesEmpleado).HasMaxLength(20).HasDefaultValueSql("''").HasComment("Perfil de Usuario;cmb;true;true;Administracion;180;left;select CodigoPerfil, NombrePerfil from perfiles");

                entity.Property(e => e.PermiteAgendamientoEmpleados).HasColumnType("int(1)").HasComment("Parámetro que sirve para filtrar los empleados en el módulo de agendamiento");

                entity.Property(e => e.PlantillaCuentasEmpleados).HasMaxLength(36).HasDefaultValueSql("''");

                entity.Property(e => e.PorcentajeAnticipoEmpleado).HasColumnType("double(16,4)").HasDefaultValueSql("'70.0000'");

                entity.Property(e => e.PorcentajeDiscapacidadEmpleado).HasPrecision(10, 2);

                entity.Property(e => e.PorcentajeIessEmpleados).HasPrecision(8, 2).HasDefaultValueSql("'9.45'");

                entity.Property(e => e.PorcentajeIessPatronoEmpleados).HasPrecision(16, 2).HasDefaultValueSql("'12.15'");

                entity.Property(e => e.PresupuestarEmpleado).HasMaxLength(1).HasDefaultValueSql("'0'").HasComment("indica si al empleado se le debe crear un presupuesto de ventas.");

                entity.Property(e => e.RepresentanteLegalEmpleado).HasMaxLength(1).HasDefaultValueSql("'0'").HasComment("indica si el empleado es el representante legal de la empresa");

                entity.Property(e => e.RolPagoEmpleado).HasMaxLength(1).HasDefaultValueSql("''");

                entity.Property(e => e.SeleccionaEmpresaEmpleado).HasColumnType("int(5)").HasDefaultValueSql("'1'").HasComment("Debe Elegir Empresa?;chk;true;true;Administracion;180;left");

                entity.Property(e => e.SeleccionaSucursalEmpleado).HasColumnType("int(5)").HasDefaultValueSql("'1'").HasComment("Debe elegir Sucursal?;chk;true;true;Administracion;180;left");

                entity.Property(e => e.SistemaSalarioNetoEmpleado).HasMaxLength(1).HasDefaultValueSql("'1'");

                entity.Property(e => e.SucursalesEmpleado).HasMaxLength(20).HasDefaultValueSql("''").HasComment("Sucursal de Pertenencia;cmb;true;true;Administracion;180;left;select CodigoSucursal, NombreSucursal from sucursales");

                entity.Property(e => e.SueldoNominalEmpleado).HasColumnType("double(16,4)").HasComment("Sueldo Nominal;text;true;true;Contabilidad;180;left");

                entity.Property(e => e.SustitutoEmpleado).HasMaxLength(1).HasDefaultValueSql("'0'").HasComment("indii el empleado es empleado sustituto de un miembro de la familia discapacitado");

                entity.Property(e => e.TelefonoDosEmpleado).HasMaxLength(12).HasDefaultValueSql("''").HasComment("Teléfono Adicional;text;true;true;Datos Personales;180;left");

                entity.Property(e => e.TelefonoTresEmpleado).HasMaxLength(12).HasDefaultValueSql("''").HasComment("Celular;text;true;true;Datos Personales;180;left");

                entity.Property(e => e.TelefonoUnoEmpleado).HasMaxLength(12).HasDefaultValueSql("''").HasComment("Teléfono;text;true;true;Datos Personales;180;left");

                entity.Property(e => e.TiempoAlmuerzoEmpleado).HasColumnType("int(3)").HasDefaultValueSql("'90'").HasComment("Almacena el numero de minutos de tiempo de almuerzo del empleado");

                entity.Property(e => e.TipoCuentaBancariaEmpleado).HasMaxLength(2).HasComment("indica el tipo de cta bancaria del empleado");

                entity.Property(e => e.TipoIdentificacionReemplazaEmpleado).HasMaxLength(20);

                entity.Property(e => e.TipoResidenciaEmpleado).HasMaxLength(45).HasDefaultValueSql("'01'");

                entity.Property(e => e.TipoSincronizacionEmpleado).HasMaxLength(1).HasDefaultValueSql("'0'").IsFixedLength();

                entity.Property(e => e.TiposEmpleadosEmpleado).HasMaxLength(20).HasDefaultValueSql("''").HasComment("Cargo de Empleado;cmb;true;true;Administracion;180;left;select CodigoTipoEmpleado, NombreTipoEmpleado from tiposempleados");

                entity.Property(e => e.TiposIdentificacionEmpleado).HasMaxLength(20).HasDefaultValueSql("'1'");

                entity.Property(e => e.TiposRubroEmpleados).HasMaxLength(20).HasDefaultValueSql("''");

                entity.Property(e => e.TiposSangrePersonasEmpleados).HasMaxLength(20);

                entity.Property(e => e.TitulosEmpleado).HasMaxLength(20).HasDefaultValueSql("''").HasComment("Titulo - Profesion;cmb;true;true;Administracion;180;left;select CodigoTitulo, NombreTitulo from titulos");

                entity.Property(e => e.TrabajaConstruccionEmpleado).HasMaxLength(1).HasDefaultValueSql("'0'");

                entity.Property(e => e.TrabajaTiempoParcialEmpleado).HasMaxLength(1).HasDefaultValueSql("'0'").HasComment("indica si el empleado trabaja a tiempo parcial, 1 parcial, 0 completo");

                entity.Property(e => e.UsuarioCaducaEmpleado).HasMaxLength(1).HasDefaultValueSql("'0'").HasComment("0 No Caduca 1 Caduca");

                entity.Property(e => e.UsuariosEmpleado).HasMaxLength(20).HasDefaultValueSql("'fmaldonado'");

                entity.Property(e => e.ValorFondoReservaEmpleado).HasColumnType("double(16,4)");

                entity.Property(e => e.VerCostoEmpleado).HasMaxLength(1).HasDefaultValueSql("'1'");

                entity.Property(e => e.WebUsuarioEmpleado).HasMaxLength(1).HasDefaultValueSql("'0'");

                entity.HasOne(d => d.PerfilesEmpleadoNavigation).WithMany(p => p.Empleados).HasForeignKey(d => d.PerfilesEmpleado).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("empleados_ibfk_1");

                entity.HasOne(d => d.SucursalesEmpleadoNavigation).WithMany(p => p.Empleados).HasForeignKey(d => d.SucursalesEmpleado).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("sucursales_fk");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.CodigoEmpresa).HasName("PRIMARY");
                entity.ToTable("empresas");
                entity.HasComment("Empresa;NombreEmpresa");
                entity.HasIndex(e => e.CodigoEmpresa, "CodigoEmpresa");
                entity.HasIndex(e => e.NombreEmpresa, "Index_Nombre").IsUnique();
                entity.HasIndex(e => e.RucEmpresa, "Index_Ruc").IsUnique();
                entity.HasIndex(e => e.NombreComercialEmpresa, "NombreComercialEmpresa_UNIQUE").IsUnique();
                entity.HasIndex(e => e.OrdenIncialEmpresa, "OrdenIncialEmpresa").IsUnique();
                entity.Property(e => e.CodigoEmpresa).HasMaxLength(20).HasComment("Codigo de Empresa;text;true;false;Datos;120;left");
                entity.Property(e => e.CodigoDinardapEmpresa).HasMaxLength(7).HasDefaultValueSql("'0000000'").HasComment("Codigo DINARDAP Empresa;text;true;True;Datos;200;left");
                entity.Property(e => e.LogoEmpresa).HasMaxLength(50).HasDefaultValueSql("'wise.png'").HasComment("Logotipo Empresa;text;true;True;Datos;200;left");
                entity.Property(e => e.NombreComercialEmpresa).HasMaxLength(100).HasDefaultValueSql("''").HasComment("Nombre Comercial Empresa;text;true;True;Datos;200;left");
                entity.Property(e => e.NombreEmpresa).HasMaxLength(100).HasComment("Nombre Empresa;text;true;True;Datos;200;left");
                entity.Property(e => e.NombreEmpresaImpresion).HasMaxLength(100);
                entity.Property(e => e.OrdenIncialEmpresa).HasColumnType("int(1)").HasDefaultValueSql("'1'").HasComment("Orden a presentar empresa;text;true;True;Datos;200;left");
                entity.Property(e => e.RucEmpresa).HasMaxLength(13).HasComment("Ruc Empresa;text;true;true;Datos;180;left");
                entity.Property(e => e.UsuariosEmpresa).HasMaxLength(20);
                entity.Property(e => e.VisualizarNombreComercialEmpresa).HasColumnType("int(1)").HasComment("Si está en 0 se visualiza la razón social de la empresa");
            });
            modelBuilder.Entity<Empresasusuario>(entity =>
            {
                entity.HasKey(e => new { e.Idusuario, e.Idempresas, e.Id }).HasName("PRIMARY").HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });
                entity.ToTable("empresasusuario");
                entity.HasIndex(e => e.Id, "index_id").IsUnique();
                entity.HasIndex(e => e.Idempresas, "index_idempresas");
                entity.HasIndex(e => e.Idusuario, "index_idusuario");
                entity.Property(e => e.Idusuario).HasMaxLength(36).HasColumnName("_idusuario");
                entity.Property(e => e.Idempresas).HasMaxLength(30).HasColumnName("_idempresas");
                entity.Property(e => e.Id).HasMaxLength(36).HasColumnName("id");
                entity.Property(e => e.Fecharegistra).HasColumnType("datetime").HasColumnName("fecharegistra");
                entity.Property(e => e.Habilitado).HasColumnType("int(1)").HasColumnName("habilitado");
                entity.Property(e => e.Idperfil).HasMaxLength(20).HasColumnName("_idperfil");
                entity.Property(e => e.Usuarioregistra).HasMaxLength(25).HasColumnName("usuarioregistra");
                entity.HasOne(d => d.IdempresasNavigation).WithMany(p => p.Empresasusuarios).HasForeignKey(d => d.Idempresas).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_idempresas_usempr");
                entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Empresasusuarios).HasPrincipalKey(p => p.Id).HasForeignKey(d => d.Idusuario).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_idusuario_usempr");
            });

            modelBuilder.Entity<Pagoscabecera>(entity =>
            {
                entity.HasKey(e => e.CodigoPagoCabecera)
                    .HasName("PRIMARY");

                entity.ToTable("pagoscabecera");

                entity.HasIndex(e => e.AsientosCabeceraPagoCabecera, "AsientosCabeceraPagoCabecera");

                entity.HasIndex(e => e.CodigoMovilPagoCabecera, "CodigoMovilPago");

                entity.HasIndex(e => e.CodigoPagoCabecera, "CodigoPago")
                    .IsUnique();

                entity.HasIndex(e => e.EmpresasPagoCabecera, "EmpresasPagoCabecera");

                entity.HasIndex(e => e.EstadoPagoCabecera, "EstadoPagoCabecera");

                entity.HasIndex(e => e.FormaPagoPagoCabecera, "FormaPagoPagoCabecera");

                entity.HasIndex(e => e.UsuariosPagoCabecera, "Index_Usuario");

                entity.Property(e => e.CodigoPagoCabecera)
                    .HasMaxLength(36)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CodigoMovilPagoCabecera).HasMaxLength(30);

                entity.Property(e => e.DiferenciaPagoCabecera).HasColumnType("double(16,4)");

                entity.Property(e => e.EmpleadoCrucePagoCabecera)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.EmpleadosCobroPagoCabecera).HasMaxLength(20);

                entity.Property(e => e.EmpresasPagoCabecera)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.EstadoPagoCabecera)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.EstadoSincronizado).HasColumnType("int(1)");

                entity.Property(e => e.FechaPagoCabecera).HasDefaultValueSql("'1900-01-01'");

                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.Property(e => e.FormaPagoPagoCabecera)
                    .HasMaxLength(3)
                    .HasDefaultValueSql("'EFE'")
                    .HasComment("EFE Efectivo CHE Cheque DEP Deposito CRU Cruce Factura TAR Tarjeta ANT Anticipos");

                entity.Property(e => e.NumeroDocumentoPagoCabecera)
                    .HasMaxLength(36)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.NumeroPagosPagoCabecera).HasColumnType("double(16,0)");

                entity.Property(e => e.NumeroReciboPagoCabecera)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ObservacionPagoCabecera).HasColumnType("text");

                entity.Property(e => e.SucursalesPagoCabecera)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.TipoPagoCabecera)
                    .HasMaxLength(5)
                    .HasDefaultValueSql("'V'")
                    .HasComment("V Ventas C Compras/Gastos");

                entity.Property(e => e.UsuariosPagoCabecera)
                    .HasMaxLength(254)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ValorCruceEmpleadoPagoCabecera).HasColumnType("double(16,4)");

                entity.Property(e => e.ValorPagoCabecera).HasColumnType("double(16,4)");
            });

            modelBuilder.Entity<Pagoscheque>(entity =>
            {
                entity.HasKey(e => e.CodigoPagoDetalle)
                    .HasName("PRIMARY");

                entity.ToTable("pagoscheques");

                entity.HasIndex(e => e.BancosPagoDetalle, "Index_Banco");

                entity.Property(e => e.CodigoPagoDetalle)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.BancosPagoDetalle)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CreditosDetallePagoDetalle)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.EstadoDocumentoPagoDetalle)
                    .HasMaxLength(5)
                    .HasDefaultValueSql("'CAJ'")
                    .HasComment("CAJ Caja DEP Depositado DEV Devuelto POS Posfechado");

                entity.Property(e => e.FechaDocumentoPagoDetalle).HasDefaultValueSql("'1900-01-01'");

                entity.Property(e => e.FormaPagoPagoCabecera)
                    .HasMaxLength(3)
                    .HasDefaultValueSql("'EFE'")
                    .HasComment("EFE Efectivo CHE Cheque DEP Deposito CRU Cruce Factura TAR Tarjeta");

                entity.Property(e => e.NumeroCuentaPagoDetalle)
                    .HasMaxLength(30)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.NumeroDocumentoPagoDetalle)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ObservacionPagoDetalle)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.PagosCabeceraPagoDetalle)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.PropietarioPagoDetalle)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ValorDocumentoPagoDetalle).HasColumnType("double(16,4)");

                entity.Property(e => e.ValorPagoDetalle).HasColumnType("double(16,4)");
            });

            modelBuilder.Entity<Pagoschequedetalle>(entity =>
            {
                entity.HasKey(e => e.CodigoPagoChequeDetalle).HasName("PRIMARY");
                entity.ToTable("pagoschequedetalle");
                entity.HasIndex(e => e.AsientosCabeceraPagoDetalle, "AsientosCabeceraPagoDetalle");
                entity.HasIndex(e => e.CodigoPagoChequeDetalle, "CodigoPagoChequeDetalle").IsUnique();
                entity.HasIndex(e => e.BancosPagoDetalle, "Index_Banco");
                entity.HasIndex(e => e.NumeroChequePagoChequeDetalle, "NumeroChequePagoChequeDetalle");
                entity.HasIndex(e => e.NumeroCuentaPagoDetalle, "NumeroCuentaPagoDetalle");
                entity.HasIndex(e => e.PagosCabeceraPagoDetalle, "PagosCabeceraPagoDetalle");
                entity.Property(e => e.CodigoPagoChequeDetalle).HasMaxLength(20).HasDefaultValueSql("''");
                entity.Property(e => e.AsientosCabeceraPagoDetalle).HasColumnType("double(16,0)");
                entity.Property(e => e.BancosPagoDetalle).HasMaxLength(20).HasDefaultValueSql("''");
                entity.Property(e => e.EstadoDocumentoPagoDetalle).HasMaxLength(5).HasDefaultValueSql("'CAJ'").HasComment("CAJ Caja DEP Depositado DEV Devuelto POS Posfechado");
                entity.Property(e => e.FechaDocumentoPagoDetalle).HasDefaultValueSql("'1900-01-01'");
                entity.Property(e => e.NumeroChequePagoChequeDetalle).HasColumnType("int(11)");
                entity.Property(e => e.NumeroCuentaPagoDetalle).HasMaxLength(30).HasDefaultValueSql("''");
                entity.Property(e => e.PagosCabeceraPagoDetalle).HasMaxLength(20).HasDefaultValueSql("''");
                entity.Property(e => e.PropietarioPagoChequeDetalle).HasMaxLength(255).HasDefaultValueSql("''");
                entity.Property(e => e.ValorDocumentoPagoDetalle).HasColumnType("double(16,4)");
            });

            modelBuilder.Entity<Pagosdetalle>(entity =>
            {
                entity.HasKey(e => e.CodigoPagoDetalle).HasName("PRIMARY");
                entity.ToTable("pagosdetalle");
                entity.HasIndex(e => e.CodigoPagoDetalle, "CodigoPagoDetalle").IsUnique();
                entity.HasIndex(e => e.CreditosDetallePagoDetalle, "CreditosDetallePagoDetalle");
                entity.HasIndex(e => e.BancosPagoDetalle, "Index_Banco");
                entity.HasIndex(e => e.NumeroChequePagoDetalle, "NumeroChequePagoDetalle");
                entity.HasIndex(e => e.NumeroCuentaPagoDetalle, "NumeroCuentaPagoDetalle");
                entity.HasIndex(e => e.PagosCabeceraPagoDetalle, "PagosCabeceraPagoDetalle");
                entity.Property(e => e.CodigoPagoDetalle).HasMaxLength(36).HasDefaultValueSql("''");
                entity.Property(e => e.BancosPagoDetalle).HasMaxLength(20).HasDefaultValueSql("''");
                entity.Property(e => e.CreditosDetallePagoDetalle).HasMaxLength(36).HasDefaultValueSql("''");
                entity.Property(e => e.EstadoDocumentoPagoDetalle).HasMaxLength(20).HasDefaultValueSql("'CAJ'").HasComment("CAJ Caja DEP Depositado DEV Devuelto POS Posfechado A Anulado");
                entity.Property(e => e.FechaDocumentoPagoDetalle).HasDefaultValueSql("'1900-01-01'");
                entity.Property(e => e.FormaPagoPagoCabecera).HasMaxLength(3).HasDefaultValueSql("'EFE'").HasComment("EFE Efectivo CHE Cheque DEP Deposito CRU Cruce Factura TAR Tarjeta");
                entity.Property(e => e.NumeroChequePagoDetalle).HasMaxLength(30).HasDefaultValueSql("'0'");
                entity.Property(e => e.NumeroCuentaPagoDetalle).HasMaxLength(30).HasDefaultValueSql("''");
                entity.Property(e => e.NumeroDocumentoPagoDetalle).HasMaxLength(40).HasDefaultValueSql("''");
                entity.Property(e => e.ObservacionPagoDetalle).HasColumnType("text");
                entity.Property(e => e.PagosCabeceraPagoDetalle).HasMaxLength(36).HasDefaultValueSql("''");
                entity.Property(e => e.PropietarioPagoDetalle).HasMaxLength(255).HasDefaultValueSql("''");
                entity.Property(e => e.ValorDocumentoPagoDetalle).HasColumnType("double(16,4)");
                entity.Property(e => e.ValorPagoDetalle).HasColumnType("double(16,4)");
                entity.HasOne(d => d.PagosCabeceraPagoDetalleNavigation).WithMany(p => p.Pagosdetalles).HasForeignKey(d => d.PagosCabeceraPagoDetalle).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_PagosCabeceraPagoDetalle");
            });

            modelBuilder.Entity<Pagosdetalleinterese>(entity =>
            {
                entity.HasKey(e => e.CodigoPagoDetalleInteres).HasName("PRIMARY");
                entity.ToTable("pagosdetalleintereses");
                entity.HasIndex(e => e.CreditosDetallePagoDetalleInteres, "CreditoDetalle");
                entity.HasIndex(e => e.PagosCabeceraPagoDetalleInteres, "PagosCabeceraPagoDetalle");
                entity.HasIndex(e => e.PagosdetallepagosdetalleIntereses, "pagosdetallepagosdetalleIntereses");
                entity.Property(e => e.CodigoPagoDetalleInteres).HasMaxLength(36).HasDefaultValueSql("''");
                entity.Property(e => e.BaseInterespagodetalleinteres).HasPrecision(16, 4);
                entity.Property(e => e.CreditosDetallePagoDetalleInteres).HasMaxLength(36).HasDefaultValueSql("''");
                entity.Property(e => e.InterescuotapagodetalleInteres).HasPrecision(16, 4).HasColumnName("interescuotapagodetalleInteres");
                entity.Property(e => e.MorapagodetalleInteres).HasPrecision(16, 4).HasColumnName("morapagodetalleInteres");
                entity.Property(e => e.PagosCabeceraPagoDetalleInteres).HasMaxLength(36).HasDefaultValueSql("''");
                entity.Property(e => e.PagosdetallepagosdetalleIntereses).HasMaxLength(36).HasColumnName("pagosdetallepagosdetalleIntereses").HasDefaultValueSql("''");
                entity.Property(e => e.PorcentajemorapagodetalleInteres).HasPrecision(16, 4).HasColumnName("porcentajemorapagodetalleInteres");
            });

            modelBuilder.Entity<Pagosmanejoscaja>(entity =>
            {
                entity.HasKey(e => e.CodigoPagoManejoCaja).HasName("PRIMARY");
                entity.ToTable("pagosmanejoscajas");
                entity.HasIndex(e => e.CodigoPagoManejoCaja, "CodigoPagoManejoCaja").IsUnique();
                entity.HasIndex(e => e.ManejoCajasPagoManejoCaja, "ManejoCajasPagoManejoCaja");
                entity.HasIndex(e => e.PagosCabeceraPagoManejoCaja, "PagosCabeceraPagoManejoCaja");
                entity.Property(e => e.CodigoPagoManejoCaja).HasMaxLength(36);
                entity.Property(e => e.FechaRegistroPagoManejoaCaja).HasColumnType("datetime");
                entity.Property(e => e.ManejoCajasPagoManejoCaja).HasMaxLength(36);
                entity.Property(e => e.PagosCabeceraPagoManejoCaja).HasMaxLength(36);
                entity.Property(e => e.UsuariosPagoManejoCaja).HasMaxLength(20);
                entity.HasOne(d => d.PagosCabeceraPagoManejoCajaNavigation)
                    .WithMany(p => p.Pagosmanejoscajas)
                    .HasForeignKey(d => d.PagosCabeceraPagoManejoCaja)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pagocabecera");
            });

            modelBuilder.Entity<Parametrosapi>(entity =>
            {
                entity.HasKey(e => new { e.Empresasapi, e.Idapi }).HasName("PRIMARY").HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                entity.ToTable("parametrosapi");
                entity.HasIndex(e => e.Empresasapi, "empresasapi");
                entity.HasIndex(e => e.Idapi, "idapi");
                entity.Property(e => e.Empresasapi).HasMaxLength(20).HasColumnName("empresasapi");
                entity.Property(e => e.Idapi).HasMaxLength(25).HasColumnName("idapi");
                entity.Property(e => e.Ambienteapi).HasColumnType("int(1)").HasColumnName("ambienteapi").HasDefaultValueSql("'1'");
                entity.Property(e => e.Bearertokenapi).HasMaxLength(20).HasColumnName("bearertokenapi");
                entity.Property(e => e.Contraseniaprodapi).HasMaxLength(20).HasColumnName("contraseniaprodapi");
                entity.Property(e => e.Contraseniapruebaapi).HasMaxLength(20).HasColumnName("contraseniapruebaapi");
                entity.Property(e => e.Esexterno).HasColumnType("int(1)").HasColumnName("esexterno");
                entity.Property(e => e.Esservidor).HasColumnType("int(1)").HasColumnName("esservidor");
                entity.Property(e => e.Habilitado).HasColumnType("int(1)").HasColumnName("habilitado");
                entity.Property(e => e.Idempresadestino).HasMaxLength(20).HasColumnName("idempresadestino");
                entity.Property(e => e.Nombreapi).HasMaxLength(100).HasColumnName("nombreapi");
                entity.Property(e => e.Tokenapi).HasColumnType("text").HasColumnName("tokenapi");
                entity.Property(e => e.Urlprodapi).HasMaxLength(100).HasColumnName("urlprodapi");
                entity.Property(e => e.Urlpruebaapi).HasMaxLength(100).HasColumnName("urlpruebaapi");
                entity.Property(e => e.Usuarioprodapi).HasMaxLength(40).HasColumnName("usuarioprodapi");
                entity.Property(e => e.Usuariopruebaapi).HasMaxLength(40).HasColumnName("usuariopruebaapi");
            });

            modelBuilder.Entity<Perfile>(entity =>
            {
                entity.HasKey(e => e.CodigoPerfil).HasName("PRIMARY");
                entity.ToTable("perfiles");
                entity.Property(e => e.CodigoPerfil).HasMaxLength(20).HasDefaultValueSql("''").HasComment("Codigo de Perfil;text;true;false;Datos;180;left");
                entity.Property(e => e.NombrePerfil).HasMaxLength(60).HasDefaultValueSql("''").HasComment("Nombre de Perfil;text;true;true;Datos;180;left");
            });

            modelBuilder.Entity<Slctdreposicionitem>(entity =>
            {
                entity.ToTable("slctdreposicionitem");
                entity.HasIndex(e => e.Id, "id").IsUnique();
                entity.HasIndex(e => e.Idempresa, "idempresa");
                entity.HasIndex(e => e.Idtiposlct, "idtiposlct");
                entity.Property(e => e.Id).HasMaxLength(36).HasColumnName("id");
                entity.Property(e => e.Estado).HasColumnType("int(1)").HasColumnName("estado");
                entity.Property(e => e.Reenviardocs).HasColumnType("int(1)").HasColumnName("reenviardocs");
                entity.Property(e => e.Enviadoseriesp).HasColumnType("int(1)").HasColumnName("enviadoseriesp");
                entity.Property(e => e.Enviadolotesp).HasColumnType("int(1)").HasColumnName("enviadolotesp");
                entity.Property(e => e.Fecha).HasColumnType("datetime").HasColumnName("fecha");
                entity.Property(e => e.Fechadespachap).HasColumnType("datetime").HasColumnName("fechadespachap");
                entity.Property(e => e.Fechaprocesadap).HasColumnType("datetime").HasColumnName("fechaprocesadap");
                entity.Property(e => e.Fecharecibef).HasColumnType("datetime").HasColumnName("fecharecibef");
                entity.Property(e => e.Fecharecibep).HasColumnType("datetime").HasColumnName("fecharecibep");
                entity.Property(e => e.Fechasolicitaf).HasColumnType("datetime").HasColumnName("fechasolicitaf");
                entity.Property(e => e.Fecharechazadap).HasColumnType("datetime").HasColumnName("fecharechazadap");
                entity.Property(e => e.Idempresa).HasMaxLength(20).HasColumnName("idempresa");
                entity.Property(e => e.Idtiposlct).HasMaxLength(20).HasColumnName("idtiposlct");
                entity.Property(e => e.Mailenviado).HasColumnType("int(1)").HasColumnName("mailenviado");
                entity.Property(e => e.Numero).HasColumnType("bigint(10)").HasColumnName("numero");
                entity.Property(e => e.Numfacturaguiap).HasMaxLength(150).HasColumnName("numfacturaguiap");
                entity.Property(e => e.Numitems).HasColumnType("bigint(10)").HasColumnName("numitems");
                entity.Property(e => e.Observaciof).HasColumnType("text").HasColumnName("observaciof");
                entity.Property(e => e.Observacionp).HasColumnType("text").HasColumnName("observacionp");
                entity.Property(e => e.Rucorigenf).HasMaxLength(13).HasColumnName("rucorigenf");
                entity.Property(e => e.Rucproveedor).HasMaxLength(13).HasColumnName("rucproveedor");
                entity.Property(e => e.Usuariodespachap).HasMaxLength(30).HasColumnName("usuariodespachap");
                entity.Property(e => e.Usuarioprocesap).HasMaxLength(30).HasColumnName("usuarioprocesap");
                entity.Property(e => e.Usuariorecibef).HasMaxLength(30).HasColumnName("usuariorecibef");
                entity.Property(e => e.Usuariosolicitaf).HasMaxLength(30).HasColumnName("usuariosolicitaf");
                entity.Property(e => e.Usuariorechazadap).HasMaxLength(30).HasColumnName("usuariorechazadap");
                entity.Property(e => e.Iddocsproveedor).HasMaxLength(36).HasColumnName("iddocsproveedor");
                entity.Property(e => e.Descuentototal).HasPrecision(16, 4).HasColumnName("descuentototal");
                entity.Property(e => e.Descuentototal0).HasPrecision(16, 4).HasColumnName("descuentototal0");
                entity.Property(e => e.Subtotal).HasPrecision(16, 4).HasColumnName("subtotal");
                entity.Property(e => e.Subtotal0).HasPrecision(16, 4).HasColumnName("subtotal0");
                entity.Property(e => e.Iva).HasPrecision(16, 4).HasColumnName("iva");
                entity.Property(e => e.Documento).HasMaxLength(2).HasColumnName("documento");
                entity.Property(e => e.Iddocsorigen).HasMaxLength(2).HasColumnName("iddocsorigen");
            });

            modelBuilder.Entity<Slctdreposicionitemdetalle>(entity =>
            {
                entity.ToTable("slctdreposicionitemdetalle");
                entity.HasIndex(e => e._Idcabecera, "_idcabecera");
                entity.HasIndex(e => e._Iditem, "_iditem");
                entity.HasIndex(e => e.Id, "id").IsUnique();
                entity.Property(e => e.Id).HasMaxLength(36).HasColumnName("id");
                entity.Property(e => e.Iditemproveedor).HasMaxLength(36).HasColumnName("iditemproveedor");
                entity.Property(e => e.Cantdespachada).HasPrecision(16, 4).HasColumnName("cantdespachada");
                entity.Property(e => e.Cantrequerido).HasPrecision(16, 4).HasColumnName("cantrequerido");
                entity.Property(e => e.Cantidad).HasPrecision(16, 4).HasColumnName("cantidad");
                entity.Property(e => e.Costo).HasPrecision(16, 4).HasColumnName("costo");
                entity.Property(e => e.Descripcion).HasMaxLength(255).HasColumnName("descripcion");
                entity.Property(e => e._Idcabecera).HasMaxLength(36).HasColumnName("_idcabecera");
                entity.Property(e => e._Iditem).HasMaxLength(20).HasColumnName("_iditem");
                entity.Property(e => e._Idservicioapi).HasMaxLength(30).HasColumnName("_idservicioapi");
                entity.Property(e => e.Iva).HasColumnType("int(1)").HasColumnName("iva");
                entity.Property(e => e.Precioproveedor).HasPrecision(16, 4).HasColumnName("precioproveedor");
                entity.Property(e => e.Descuento).HasPrecision(16, 4).HasColumnName("descuento");
                entity.Property(e => e.Solicitadop).HasColumnType("int(1)").HasColumnName("solicitadop");
                entity.HasOne(d => d.SlctdreposicionitemNavigation).WithMany(p => p.Slctdreposicionitemdetalle).HasForeignKey(d => d._Idcabecera);//.OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_idcab_doc");
            });

            modelBuilder.Entity<Stockproductsecommerce>(entity =>
            {
                entity.ToTable("stockproductsecommerce");
                entity.Property(e => e.Id).HasMaxLength(20).HasColumnName("id");
                entity.Property(e => e.Price).HasPrecision(16, 4).HasColumnName("price");
                entity.Property(e => e.Stock).HasPrecision(16, 4).HasColumnName("stock");
            });

            modelBuilder.Entity<Sucursale>(entity =>
            {
                entity.HasKey(e => e.CodigoSucursal).HasName("PRIMARY");
                entity.ToTable("sucursales");
                entity.HasComment("Sucursal;NombreSucursal");
                entity.HasIndex(e => e.CiudadesSucursal, "CiudadFK");
                entity.HasIndex(e => e.CodigoSucursal, "CodigoSucursal").IsUnique();
                entity.HasIndex(e => e.PaisSucursal, "FK_Pais_Sucursales");
                entity.HasIndex(e => e.ParroquiaSucursal, "FK_Parroquias_Sucursal");
                entity.HasIndex(e => e.ProvinciaSucursal, "FK_Provincia_Sucursal");
                entity.HasIndex(e => new { e.EmpresasSucursal, e.NombreSucursal }, "Index_NombreSucursal").IsUnique();
                entity.Property(e => e.CodigoSucursal).HasMaxLength(20).HasDefaultValueSql("''").HasComment("Codigo WISE de la sucursal;text;true;false;Datos;180;left");
                entity.Property(e => e.ActivaAgendamientoSucursal).HasColumnType("int(1)");
                entity.Property(e => e.ActivaSucursal).HasMaxLength(1).HasDefaultValueSql("'0'").HasComment("Desactivada Sucursal;checkbox;true;true;Datos;180;left");
                entity.Property(e => e.CiudadesSucursal).HasMaxLength(20).HasDefaultValueSql("'091029152528233'").HasComment("Ciudad a la que pertenece la sucursal;combo;true;true;Datos;180;left;Select CodigoCiudad,NombreCiudad from ciudades ORDER BY NombreCiudad");
                entity.Property(e => e.DireccionSucursal).HasMaxLength(100).HasDefaultValueSql("''").HasComment("Direccion Sucursal;text;true;true;Datos;300;left");
                entity.Property(e => e.EmpresasSucursal).HasMaxLength(20).HasDefaultValueSql("''").HasComment("Empresa a la que pertenece la sucursal;combo;true;true;Datos;180;left;Select CodigoEmpresa,NombreEmpresa from Empresas");
                entity.Property(e => e.EsOfflineSucursal).HasColumnType("int(1)");
                entity.Property(e => e.EstablecimientoRdepsucursal).HasMaxLength(3).HasColumnName("EstablecimientoRDEPSucursal").HasDefaultValueSql("'001'");
                entity.Property(e => e.FaxSucursal).HasMaxLength(14).HasDefaultValueSql("''").HasComment("Fax Sucursal;text;true;true;Datos;180;left");
                entity.Property(e => e.FechaModificacionSucursal).HasColumnType("datetime").HasDefaultValueSql("'1990-01-01 00:00:00'");
                entity.Property(e => e.FechaRegistroSucursal).HasColumnType("datetime").HasDefaultValueSql("'1990-01-01 00:00:00'");
                entity.Property(e => e.LatitudSucursal).HasMaxLength(25).HasDefaultValueSql("'0'");
                entity.Property(e => e.LongitudSucursal).HasMaxLength(25).HasDefaultValueSql("'0'");
                entity.Property(e => e.MatrizSucursal).HasMaxLength(1).HasDefaultValueSql("''");
                entity.Property(e => e.MidRecargasSucursal).HasMaxLength(20).HasDefaultValueSql("'015912000100004'");
                entity.Property(e => e.NombreSucursal).HasMaxLength(100).HasDefaultValueSql("''").HasComment("Nombre Sucursal;text;true;true;Datos;180;left");
                entity.Property(e => e.PaisSucursal).HasMaxLength(20).HasDefaultValueSql("''");
                entity.Property(e => e.ParroquiaSucursal).HasMaxLength(20).HasDefaultValueSql("''");
                entity.Property(e => e.ProvinciaSucursal).HasMaxLength(20).HasDefaultValueSql("''");
                entity.Property(e => e.SecuenciaSucursal).HasColumnType("int(4)").HasComment("Codigo secuencial para identificacion");
                entity.Property(e => e.TelefonoDosSucursal).HasMaxLength(14).HasDefaultValueSql("''").HasComment("Telefono Dos Sucursal;text;true;true;Datos;180;left");
                entity.Property(e => e.TelefonoUnoSucursal).HasMaxLength(14).HasDefaultValueSql("''").HasComment("Telefono Uno Sucursal;text;true;true;Datos;180;left");
                entity.Property(e => e.UsuarioModificaSucursal).HasMaxLength(20);
                entity.Property(e => e.UsuariosRegistraSucursal).HasMaxLength(20);
                entity.Property(e => e.ZoomUbicacionMapaSucursal).HasColumnType("int(5)");
                entity.HasOne(d => d.EmpresasSucursalNavigation).WithMany(p => p.Sucursales).HasForeignKey(d => d.EmpresasSucursal).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("EmpresaFK");
            });

            modelBuilder.Entity<Tiposempleado>(entity =>
            {
                entity.HasKey(e => new { e.CodigoTipoEmpleado, e.NombreTipoEmpleado }).HasName("PRIMARY").HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                entity.ToTable("tiposempleados");
                entity.HasComment("TipoEmpleado;NombreTipoEmpleado");
                entity.HasIndex(e => e.CodigoTipoEmpleado, "Index_CodigoTipoEmpleado").IsUnique();
                entity.HasIndex(e => e.NombreTipoEmpleado, "Index_Nombres");
                entity.Property(e => e.CodigoTipoEmpleado).HasMaxLength(20).HasDefaultValueSql("''").HasComment("Codigo Tipo Empleado;text;true;false;Datos;180;left");
                entity.Property(e => e.NombreTipoEmpleado).HasMaxLength(100).HasDefaultValueSql("''").HasComment("Nombre Tipo Empleado;text;true;true;Datos;180;left");
                entity.Property(e => e.EsVendedorTipoEmpleado).HasMaxLength(1).HasDefaultValueSql("'1'").HasComment("Visualiza en listado de vendedores;checkbox;true;true;Datos;180;left");
                entity.Property(e => e.UsuariosTipoEmpleado).HasMaxLength(20).HasDefaultValueSql("''");
            });
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Nombre, e.Idempleados }).HasName("PRIMARY").HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });
                entity.ToTable("usuario");
                entity.HasIndex(e => e.Idempleados, "_idempleados");
                entity.HasIndex(e => e.Id, "id").IsUnique();
                entity.HasIndex(e => e.Nombre, "nombre");
                entity.Property(e => e.Id).HasMaxLength(36).HasColumnName("id");
                entity.Property(e => e.Nombre).HasMaxLength(50).HasColumnName("nombre");
                entity.Property(e => e.Idempleados).HasMaxLength(36).HasColumnName("_idempleados");
                entity.Property(e => e.Accesoweb).HasColumnType("int(1)").HasColumnName("accesoweb").HasDefaultValueSql("'1'");
                entity.Property(e => e.Caducarclave).HasColumnType("int(1)").HasColumnName("caducarclave").HasDefaultValueSql("'1'");
                entity.Property(e => e.Cambiadoclave).HasColumnType("int(1)").HasColumnName("cambiadoclave").HasDefaultValueSql("'1'");
                entity.Property(e => e.Clave).HasColumnType("blob").HasColumnName("clave");
                entity.Property(e => e.Fechacaduca).HasColumnName("fechacaduca").HasDefaultValueSql("'1900-01-01'");
                entity.Property(e => e.Fechamodifica).HasColumnType("datetime").HasColumnName("fechamodifica");
                entity.Property(e => e.Fecharegistra).HasColumnType("datetime").HasColumnName("fecharegistra");
                entity.Property(e => e.Imagen).HasMaxLength(250).HasColumnName("imagen").HasDefaultValueSql("'Avatar.svg'");
                entity.Property(e => e.Sincronizarmovil).HasColumnType("int(1)").HasColumnName("sincronizarmovil");
                entity.Property(e => e.Usuariomodifica).HasMaxLength(20).HasColumnName("usuariomodifica");
                entity.Property(e => e.Usuarioregistra).HasMaxLength(20).HasColumnName("usuarioregistra");
                entity.HasOne(d => d.IdempleadosNavigation).WithMany(p => p.Usuarios).HasForeignKey(d => d.Idempleados).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_idempleados_user");
            });

            modelBuilder.Entity<Usuarioapiwise>(entity =>
            {
                entity.ToTable("usuarioapiwise");
                entity.HasIndex(e => e.Id, "id").IsUnique();
                entity.Property(e => e.Id).HasMaxLength(13).HasColumnName("id");
                entity.Property(e => e.Clave).HasColumnType("blob").HasColumnName("clave");
                entity.Property(e => e.Estado).HasColumnType("int(1)").HasColumnName("estado");
                entity.Property(e => e.Fechaanula).HasColumnType("datetime").HasColumnName("fechaanula");
                entity.Property(e => e.Fecharegistro).HasColumnType("datetime").HasColumnName("fecharegistro");
                entity.Property(e => e.Nombre).HasMaxLength(30).HasColumnName("nombre");
                entity.Property(e => e.Observacion).HasColumnType("text").HasColumnName("observacion");
                entity.Property(e => e.Token).HasColumnType("text").HasColumnName("token");
                entity.Property(e => e.Usuarioanula).HasMaxLength(30).HasColumnName("usuarioanula");
                entity.Property(e => e.Usuarioregistra).HasMaxLength(30).HasColumnName("usuarioregistra");
            });

            modelBuilder.Entity<Usuariossucursal>(entity =>
            {
                entity.HasKey(e => new { e.Idusuarioempresa, e.Idsucursal }).HasName("PRIMARY").HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                entity.ToTable("usuariossucursal");
                entity.HasIndex(e => e.Idsucursal, "index_idsucursal_usucur");
                entity.HasIndex(e => e.Idusuarioempresa, "index_idusuarioempresa_usucur");
                entity.Property(e => e.Idusuarioempresa).HasMaxLength(36).HasColumnName("_idusuarioempresa");
                entity.Property(e => e.Idsucursal).HasMaxLength(36).HasColumnName("_idsucursal");
                entity.Property(e => e.Fecharegistro).HasColumnType("datetime").HasColumnName("fecharegistro");
                entity.Property(e => e.Habilitado).HasColumnType("int(1)").HasColumnName("habilitado");
                entity.Property(e => e.Usuarioregisro).HasMaxLength(25).HasColumnName("usuarioregisro");
                entity.HasOne(d => d.IdsucursalNavigation).WithMany(p => p.Usuariossucursals).HasForeignKey(d => d.Idsucursal).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_idsucursal_usucur");
                entity.HasOne(d => d.IdusuarioempresaNavigation).WithMany(p => p.Usuariossucursals).HasPrincipalKey(p => p.Id).HasForeignKey(d => d.Idusuarioempresa).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_idusuarioempresa_usucur");
            });
            modelBuilder.Entity<Seriesproducto>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.NumeroSerieProducto }).HasName("PRIMARY").HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                entity.ToTable("seriesproductos");
                entity.HasIndex(e => e.DocsCabeceraSerieProducto, "DocsCabecera");
                entity.HasIndex(e => e.NumeroSerieProducto, "NumeroSerieProducto");
                entity.HasIndex(e => e.ProductosSerieProducto, "ProductosSerieProducto");
                entity.HasIndex(e => e.Id, "id").IsUnique();
                entity.HasIndex(e => e.Iddocsdetalle, "iddocsdetalle");
                entity.Property(e => e.Id).HasMaxLength(36).HasColumnName("id");
                entity.Property(e => e.NumeroSerieProducto).HasMaxLength(100);
                entity.Property(e => e.BodegasSerieProducto).HasMaxLength(20).HasDefaultValueSql("''");
                entity.Property(e => e.DocsCabeceraSerieProducto).HasMaxLength(36).HasDefaultValueSql("''");
                entity.Property(e => e.DocumentosSerieProducto).HasMaxLength(20).HasDefaultValueSql("'II'");
                entity.Property(e => e.EstadosProductoSerieProducto).HasMaxLength(20).HasDefaultValueSql("''");
                entity.Property(e => e.Fecharegistro).HasColumnType("datetime").HasColumnName("fecharegistro");
                entity.Property(e => e.Iddocsdetalle).HasMaxLength(36).HasColumnName("iddocsdetalle");
                entity.Property(e => e.ProductosSerieProducto).HasMaxLength(20).HasDefaultValueSql("''");
                entity.Property(e => e.UsuariosSerieProducto).HasMaxLength(20).HasDefaultValueSql("''");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.CodigoProducto).HasName("PRIMARY");
                entity.ToTable("productos");
                entity.HasComment("Producto;DescripcionProducto,Abrevia");
                entity.HasIndex(e => e.ArancelesProducto, "Aranceles");
                entity.HasIndex(e => e.CategoriasServicioTecnicoProducto, "CategoriasServicioTecnicoProducto");
                entity.HasIndex(e => e.CodigoBarraProducto, "CodigoBarraProducto").IsUnique();
                entity.HasIndex(e => e.CodigoCatalogoProducto, "CodigoCatalogoProducto");
                entity.HasIndex(e => e.CodigoCompraProducto, "CodigoCompraProducto");
                entity.HasIndex(e => e.CodigoProducto, "CodigoProducto").IsUnique();
                entity.HasIndex(e => e.CodigoTipoPorcentajeIce, "CodigoTipoPorcentajeICE");
                entity.HasIndex(e => e.ColoresProducto, "Colores");
                entity.HasIndex(e => e.CondicionesAlmacenamientoArcsaProducto, "CondicionesAlmacenamientoArcsaProducto");
                entity.HasIndex(e => e.CuentasContabilidadDevolucionProducto, "CuentaDevoluciones");
                entity.HasIndex(e => e.CuentasContabilidadActivoProducto, "CuentasAcitvo");
                entity.HasIndex(e => e.CuentasContabilidadCompraProducto, "CuentasContabilidadCompraProducto");
                entity.HasIndex(e => e.CuentasContabilidadCostoProducto, "CuentasCosto");
                entity.HasIndex(e => e.CuentasContabilidadVentaProducto, "CuentasVentas");
                entity.HasIndex(e => e.DescripcionAdicionalProducto, "DescripcionAdicionalProducto");
                entity.HasIndex(e => e.DescripcionCortaProducto, "DescripcionCortaProducto");
                entity.HasIndex(e => e.DescripcionProducto, "DescripcionProducto");
                entity.HasIndex(e => e.CuentasContabilidadCuponProducto, "FK_CuentasContabilidadCuponProducto");
                entity.HasIndex(e => e.GruposProducto, "Grupos");
                entity.HasIndex(e => e.ServicioProducto, "Ind_ServicioProducto");
                entity.HasIndex(e => e.CodigoVentaProducto, "Index_CodigoVenta").IsUnique();
                entity.HasIndex(e => e.LineasProducto, "Lineas");
                entity.HasIndex(e => e.ListasPrecioProducto, "ListasPrecioProducto");
                entity.HasIndex(e => e.MarcasProducto, "Marcas");
                entity.HasIndex(e => e.VentaProducto, "VentaProducto");
                entity.HasIndex(e => e.CategoriasProducto, "categorias");
                entity.HasIndex(e => e.CategoriasEspecialesProducto, "productos_ibfk_1");
                entity.HasIndex(e => e.ProductosTipoProducto, "tiposproducto");
                entity.HasIndex(e => e.UnidadesProducto, "unidades");
                entity.Property(e => e.CodigoProducto).HasMaxLength(20).HasDefaultValueSql("''").HasComment("Codigo;text;true;false;Administracion;180;left");
                entity.Property(e => e.AccesorioProducto).HasMaxLength(1).HasDefaultValueSql("'0'").HasComment("Es un Accesorio;chk;true;true;Otras Consideraciones;180;left");
                entity.Property(e => e.ActivoProducto).HasMaxLength(1).HasDefaultValueSql("'0'").HasComment("Es parte del Activo;chk;true;true;Administracion;180;left");
                entity.Property(e => e.AltoProducto).HasPrecision(19, 12).HasComment("Alto;text;true;true;Otras Consideraciones;180;left");
                entity.Property(e => e.AnchoProducto).HasPrecision(19, 12).HasComment("Ancho;text;true;true;Otras Consideraciones;180;left");
                entity.Property(e => e.Anio).HasMaxLength(36).HasColumnName("_Anio");
                entity.Property(e => e.ArancelesProducto).HasMaxLength(20).HasDefaultValueSql("'0'");
                entity.Property(e => e.CalificacionProducto).HasMaxLength(1).HasDefaultValueSql("'D'");
                entity.Property(e => e.CantidadLitrosProducto).HasPrecision(16, 4);
                entity.Property(e => e.CantidadSumaBonificacionProducto).HasPrecision(16, 4);
                entity.Property(e => e.Capacidad).HasMaxLength(36).HasColumnName("_Capacidad");
                entity.Property(e => e.CategoriasEcommerceProducto).HasMaxLength(20).HasDefaultValueSql("'0'");
                entity.Property(e => e.CategoriasEspecialesProducto).HasMaxLength(20).HasDefaultValueSql("'0'");
                entity.Property(e => e.CategoriasProducto).HasMaxLength(20).HasDefaultValueSql("'0'");
                entity.Property(e => e.CategoriasServicioTecnicoProducto).HasMaxLength(20).HasDefaultValueSql("''");
                entity.Property(e => e.Cilindraje).HasMaxLength(36).HasColumnName("_Cilindraje");
                entity.Property(e => e.CodigoBarraProducto).HasMaxLength(100).HasDefaultValueSql("''").HasComment("Codigo de Barras;text;true;true;Administracion;180;left");
                entity.Property(e => e.CodigoCatalogoProducto).HasMaxLength(40).HasDefaultValueSql("''").HasComment("Codigo en Catalogo;text;true;true;Administracion;180;left");
                entity.Property(e => e.CodigoCompraProducto).HasMaxLength(40).HasDefaultValueSql("''").HasComment("Codigo en Compra;text;true;true;Administracion;180;left");
                entity.Property(e => e.CodigoTipoPorcentajeIce).HasMaxLength(30).HasColumnName("CodigoTipoPorcentajeICE").HasDefaultValueSql("'0'");
                entity.Property(e => e.CodigoVentaProducto).HasMaxLength(40).HasDefaultValueSql("''").HasComment("Codigo de Item;text;true;true;Administracion;180;left");
                entity.Property(e => e.ColoresProducto).HasMaxLength(20).HasDefaultValueSql("'0'");
                entity.Property(e => e.ComboProducto).HasMaxLength(1).HasDefaultValueSql("'0'").HasComment("Verifica si el producto es un combo");
                entity.Property(e => e.Combustible).HasMaxLength(36).HasColumnName("_Combustible");
                entity.Property(e => e.CompresionServicio).HasMaxLength(20).HasDefaultValueSql("'0'");
                entity.Property(e => e.CondicionesAlmacenamientoArcsaProducto).HasMaxLength(20);
                entity.Property(e => e.ControlarBufferProducto).HasMaxLength(1).HasDefaultValueSql("'0'");
                entity.Property(e => e.ControlarPesoProducto).HasMaxLength(1).HasDefaultValueSql("'0'").HasComment("Se debe controlar su Peso;chk;true;true;Otras Consideraciones;180;left");
                entity.Property(e => e.ControlesProducto).HasColumnType("text").HasComment("Almacena el tipo de control en el caso de ser agroquimico");
                entity.Property(e => e.CuentasContabilidadActivoProducto).HasMaxLength(20).HasDefaultValueSql("''");
                entity.Property(e => e.CuentasContabilidadCompraProducto).HasMaxLength(20).HasDefaultValueSql("''");
                entity.Property(e => e.CuentasContabilidadCostoProducto).HasMaxLength(20).HasDefaultValueSql("''");
                entity.Property(e => e.CuentasContabilidadCuponProducto).HasMaxLength(20).HasDefaultValueSql("''");
                entity.Property(e => e.CuentasContabilidadDescuentoProducto).HasMaxLength(20).HasDefaultValueSql("'41010001001'");
                entity.Property(e => e.CuentasContabilidadDevolucionProducto).HasMaxLength(20).HasDefaultValueSql("''");
                entity.Property(e => e.CuentasContabilidadVentaProducto).HasMaxLength(20).HasDefaultValueSql("''");
                entity.Property(e => e.CultivoProucto).HasColumnType("text").HasComment("Permite saber si el producto se aplica a algun tipo de cultivo en caso de ser agroquimio");
                entity.Property(e => e.DatoAdicionalProducto).HasColumnType("text");
                entity.Property(e => e.DatosGeneralesProducto).HasColumnType("text");
                entity.Property(e => e.DeclaraArcsaProducto).HasColumnType("int(1)");
                entity.Property(e => e.DescripcionAdicionalProducto).HasDefaultValueSql("''").HasComment("Descripcion Adicional;text;true;true;Administracion;180;left");
                entity.Property(e => e.DescripcionCortaProducto).HasMaxLength(20).HasDefaultValueSql("''").HasComment("Descripcion Corta;text;true;true;Administracion;180;left");
                entity.Property(e => e.DescripcionProducto).HasDefaultValueSql("''").HasComment("Nombre-Descripcion;text;true;true;Administracion;180;left");
                entity.Property(e => e.DescuentoComboProducto).HasColumnType("double(16,4)").HasComment("Establece el porcentaje de descuento en los productos del combo");
                entity.Property(e => e.DescuentoProducto).HasPrecision(16, 4);
                entity.Property(e => e.DeshabilitadoProducto).HasColumnType("int(1)");
                entity.Property(e => e.DesventajasProducto).HasColumnType("text");
                entity.Property(e => e.DosisProducto).HasColumnType("text").HasComment("Almacena la dosis del producto en el caso de ser agroquimico");
                entity.Property(e => e.EcommerceIdProducto).HasMaxLength(20).HasDefaultValueSql("'0'");
                entity.Property(e => e.EsServicioRecargasProducto).HasMaxLength(1).HasDefaultValueSql("'0'");
                entity.Property(e => e.FacturaComboProducto).HasMaxLength(1).HasDefaultValueSql("'0'").HasComment("Verifica si se factura el combo o cada uno de los productos");
                entity.Property(e => e.FacturarDecimalesProducto).HasMaxLength(1).HasDefaultValueSql("'0'");
                entity.Property(e => e.FavoritoProducto).HasMaxLength(1).HasDefaultValueSql("'0'");
                entity.Property(e => e.FechaCreacionProducto).HasDefaultValueSql("'2000-01-01'");
                entity.Property(e => e.FechaVigenciaRegistroSanitarioProducto).HasDefaultValueSql("'1900-01-01'");
                entity.Property(e => e.FrecuenciasProducto).HasColumnType("text").HasComment("Almacena la frecuencia de administracion del produto en caso de ser agroquimico");
                entity.Property(e => e.GeneraOrdenServicioTecnicoProducto).HasColumnType("int(1)");
                entity.Property(e => e.GradoAlcoholicoProducto).HasPrecision(16, 4);
                entity.Property(e => e.GruposCaracteristicasProducto).HasMaxLength(20);
                entity.Property(e => e.GruposEcommerceProducto).HasMaxLength(20).HasDefaultValueSql("'0'");
                entity.Property(e => e.GruposProducto).HasMaxLength(20).HasDefaultValueSql("'0'");
                entity.Property(e => e.Idmultiempresas).HasMaxLength(36).HasColumnName("idmultiempresas");
                entity.Property(e => e.IngresaMotorChasisProducto).HasColumnType("int(1)");
                entity.Property(e => e.LineasEcommerceProducto).HasMaxLength(20).HasDefaultValueSql("'0'");
                entity.Property(e => e.LineasProducto).HasMaxLength(20).HasDefaultValueSql("'0'");
                entity.Property(e => e.ListasPrecioProducto).HasMaxLength(20).HasDefaultValueSql("''");
                entity.Property(e => e.LoteProducto).HasMaxLength(1).HasDefaultValueSql("''");
                entity.Property(e => e.MarcasProducto).HasMaxLength(20).HasDefaultValueSql("'0'");
                entity.Property(e => e.MateriaPrimaProducto).HasMaxLength(1).HasDefaultValueSql("'0'").HasComment("Item de Materia Prima;chk;true;true;Otras Consideraciones;180;left");
                entity.Property(e => e.MetrajeProducto).HasPrecision(16, 4);
                entity.Property(e => e.MigarEcommerceProducto).HasColumnType("int(1)");
                entity.Property(e => e.NombreComercialProducto).HasMaxLength(300).HasDefaultValueSql("''");
                entity.Property(e => e.NumeroEjes).HasMaxLength(36).HasColumnName("_NumeroEjes");
                entity.Property(e => e.NumeroRegistroSanitarioProducto).HasMaxLength(50).HasDefaultValueSql("''");
                entity.Property(e => e.NumeroRuedas).HasMaxLength(36).HasColumnName("_NumeroRuedas");
                entity.Property(e => e.ObservacionProducto).HasColumnType("text").HasComment("Observaciones;text;true;true;Observaciones;180;left");
                entity.Property(e => e.PagaIceProducto).HasMaxLength(1).HasDefaultValueSql("'0'");
                entity.Property(e => e.PagaIvaProducto).HasMaxLength(1).HasDefaultValueSql("'0'").HasComment("Item con I.V.A.;chk;true;true;Administracion;180;left");
                entity.Property(e => e.PaisOrigen).HasMaxLength(36).HasColumnName("_PaisOrigen");
                entity.Property(e => e.PerchaProducto).HasMaxLength(20).HasDefaultValueSql("''").HasComment("Percha en Bodega;text;true;true;Otras Consideraciones;180;left");
                entity.Property(e => e.PesoProducto).HasPrecision(16, 4).HasComment("Peso;text;true;true;Otras Consideraciones;180;left");
                entity.Property(e => e.PlanAnchoBanda).HasMaxLength(20).HasDefaultValueSql("'0'");
                entity.Property(e => e.PorcentajeBonificacionProducto).HasPrecision(16, 4);
                entity.Property(e => e.PorcentajeDescuentoProducto).HasPrecision(16, 4);
                entity.Property(e => e.PrecioFofproducto).HasPrecision(16, 4).HasColumnName("PrecioFOFProducto");
                entity.Property(e => e.PrecioProveedorLocalProducto).HasPrecision(16, 4);
                entity.Property(e => e.ProductosTipoProducto).HasMaxLength(20).HasDefaultValueSql("'0'");
                entity.Property(e => e.ProfundidadProducto).HasPrecision(19, 12).HasComment("Ancho;text;true;true;Otras Consideraciones;180;left");
                entity.Property(e => e.PromocionProducto).HasMaxLength(1).HasDefaultValueSql("'0'");
                entity.Property(e => e.ProveedoresProducto).HasMaxLength(20).HasDefaultValueSql("''");
                entity.Property(e => e.RecargoProducto).HasPrecision(16, 4);
                entity.Property(e => e.RecetaProducto).HasMaxLength(1).HasDefaultValueSql("'0'").HasComment("Item posee Receta?;chk;true;true;Administracion;180;left");
                entity.Property(e => e.RepuestoProducto).HasMaxLength(1).HasDefaultValueSql("'0'").HasComment("Es un Repuesto;chk;true;true;Otras Consideraciones;180;left");
                entity.Property(e => e.SeleccionarPorcionesProducto).HasColumnType("int(1)");
                entity.Property(e => e.SerieLoteProducto).HasMaxLength(1).HasDefaultValueSql("'0'").HasComment("Requiere Ingresar Numeros de Serie;chk;true;true;Administracion;180;left");
                entity.Property(e => e.ServicioProducto).HasMaxLength(1).HasDefaultValueSql("'0'").HasComment("Establecer como Servicio;chk;true;true;Administracion;180;left");
                entity.Property(e => e.SincronizarAppProducto).HasMaxLength(1).HasDefaultValueSql("'1'");
                entity.Property(e => e.SincronizarWebProducto).HasMaxLength(1).HasDefaultValueSql("'0'");
                entity.Property(e => e.SumarNumeroFilasBonificacionProducto).HasPrecision(16, 4);
                entity.Property(e => e.SustitutoProducto).HasMaxLength(1).HasDefaultValueSql("'0'").HasComment("Es un Sustituto de otro Item;text;true;true;Otras Consideraciones;180;left");
                entity.Property(e => e.TiempomedioServicioTecnicoProducto).HasColumnType("int(6)");
                entity.Property(e => e.TipoExtrasProducto).HasMaxLength(20).HasDefaultValueSql("''");
                entity.Property(e => e.Tonelaje).HasMaxLength(36).HasColumnName("_Tonelaje");
                entity.Property(e => e.UnidadesCajaProducto).HasPrecision(16, 4);
                entity.Property(e => e.UnidadesProducto).HasMaxLength(20).HasDefaultValueSql("'1'");
                entity.Property(e => e.UsuariosProducto).HasMaxLength(20).HasDefaultValueSql("'fmaldonado'");
                entity.Property(e => e.ValorIcexItemProducto).HasPrecision(16, 4).HasColumnName("ValorICExItemProducto");
                entity.Property(e => e.ValorXlitroAlcoholProducto).HasPrecision(16, 4);
                entity.Property(e => e.VariacionCostoProduccionProducto).HasPrecision(16, 2).HasDefaultValueSql("'5.00'");
                entity.Property(e => e.VentaProducto).HasMaxLength(1).HasDefaultValueSql("'1'").HasComment("Es un Item para Venta;chk;true;true;Administracion;180;left");
                entity.Property(e => e.VentajasProducto).HasColumnType("text");
                entity.Property(e => e.VerificarPlazoLineasProducto).HasColumnType("int(1)");
                entity.Property(e => e.VisualizarDescuentoProducto).HasColumnType("int(1)");

                entity.HasOne(d => d.LineasProductoNavigation).WithMany(p => p.Productos).HasForeignKey(d => d.LineasProducto).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Lineas");
                entity.HasOne(d => d.CategoriasProductoNavigation).WithMany(p => p.Productos).HasForeignKey(d => d.CategoriasProducto).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("categorias");
                entity.HasOne(d => d.GruposProductoNavigation).WithMany(p => p.Productos).HasForeignKey(d => d.GruposProducto).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Grupos");
                entity.HasOne(d => d.MarcasProductoNavigation).WithMany(p => p.Productos).HasForeignKey(d => d.MarcasProducto).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Marcas");
                entity.HasOne(d => d.TiposProductoNavigation).WithMany(p => p.Productos).HasForeignKey(d => d.ProductosTipoProducto).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Fk_TipoProducto");

            });
            modelBuilder.Entity<Empresasproducto>(entity =>
            {
                entity.HasKey(e => new { e.EmpresasEmpresaProducto, e.ProductosEmpresaProducto }).HasName("PRIMARY").HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                entity.ToTable("empresasproductos");
                entity.HasIndex(e => e.EmpresasEmpresaProducto, "EmpresasEmpresaProducto");
                entity.HasIndex(e => new { e.EmpresasEmpresaProducto, e.ProductosEmpresaProducto }, "EmpresasProductos");
                entity.HasIndex(e => e.ProductosEmpresaProducto, "FK_EmpresasProductos_Producto");
                entity.Property(e => e.EmpresasEmpresaProducto).HasMaxLength(20);
                entity.Property(e => e.ProductosEmpresaProducto).HasMaxLength(20);
                entity.Property(e => e.BufferEmpresaProducto).HasPrecision(10, 4);
                entity.Property(e => e.Compraminimamayoristaempresaproducto).HasPrecision(16, 4).HasColumnName("compraminimamayoristaempresaproducto");
                entity.Property(e => e.CostoInicialProducto).HasPrecision(16, 6);
                entity.Property(e => e.CostoProducto).HasPrecision(12, 6).HasComment("Costo el Item;text;true;true;Administracion;180;left");
                entity.Property(e => e.DescuentoProductoEmpresaProducto).HasPrecision(12, 6);
                entity.Property(e => e.FacturaBajoCostoEmpresaProducto).HasColumnType("int(1)");
                entity.Property(e => e.MargenUtilidadEmpresaProducto).HasPrecision(16, 4);
                entity.Property(e => e.PorcentajeDescuentoMayoristaempresaproducto).HasPrecision(16, 4);
                entity.Property(e => e.PorcentajeIncrementoEmpresaProducto).HasColumnType("int(1)");
                entity.Property(e => e.PrecioMarcadoEmpresaProducto).HasPrecision(16, 4);
                entity.Property(e => e.PrecioVentaProducto).HasPrecision(12, 4).HasComment("Precio de Venta;text;true;true;Administracion;180;left");
                entity.Property(e => e.TieneRecetaXadis).HasColumnType("int(1)");
                entity.Property(e => e.TiposEstadoProductoEmpresaProducto).HasMaxLength(20).HasDefaultValueSql("'0'");
                entity.Property(e => e.ValorIce).HasPrecision(16, 4);
                entity.Property(e => e.VisualizarDescuentoProductoEmpresaProducto).HasColumnType("int(1)");
                entity.HasOne(d => d.EmpresasEmpresaProductoNavigation).WithMany(p => p.Empresasproductos).HasForeignKey(d => d.EmpresasEmpresaProducto).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_EmpresasEmpresaProducto");
                entity.HasOne(d => d.ProductosEmpresaProductoNavigation).WithMany(p => p.Empresasproductos).HasForeignKey(d => d.ProductosEmpresaProducto).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ProductosEmpresaProducto");
            });
            modelBuilder.Entity<Linea>(entity =>
            {
                entity.HasKey(e => e.CodigoLinea).HasName("PRIMARY");
                entity.ToTable("lineas");
                entity.HasComment("Linea;NombreLinea,AbreviadoLinea");
                entity.HasIndex(e => e.CodigoLinea, "CodigoLinea").IsUnique();
                entity.HasIndex(e => e.AbreviadoLinea, "Index_Abreviado");
                entity.HasIndex(e => e.NombreLinea, "Index_Nombre").IsUnique();
                entity.Property(e => e.CodigoLinea).HasMaxLength(20).HasComment("Codigo Linea;text;true;false;Datos;180;left");
                entity.Property(e => e.AbreviadoLinea).HasMaxLength(6).HasComment("Nombre Abreviado;text;true;true;Datos;180;left");
                entity.Property(e => e.ActivaLinea).HasMaxLength(1).HasDefaultValueSql("'1'");
                entity.Property(e => e.NombreLinea).HasMaxLength(60).HasComment("Nombre Linea;text;true;true;Datos;180;left");
                entity.Property(e => e.PresupuestoLinea).HasMaxLength(1).HasDefaultValueSql("'0'");
                entity.Property(e => e.UsuariosLinea).HasMaxLength(20).HasDefaultValueSql("'fmaldonado'");
                entity.Property(e => e.VentaLinea).HasMaxLength(1).HasColumnName("VentaLInea").HasDefaultValueSql("'1'");
            });
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.CodigoCategoria).HasName("PRIMARY");
                entity.ToTable("categorias");
                entity.HasComment("Categoria;NombreCategoria,AbreviadoC");
                entity.HasIndex(e => e.CodigoCategoria, "CodigoCategoria").IsUnique();
                entity.HasIndex(e => e.LineasCategorias, "FK_Categoria_Lineas");
                entity.Property(e => e.CodigoCategoria).HasMaxLength(20).HasComment("Codigo Categoria;text;true;false;Datos;180;left");
                entity.Property(e => e.AbreviadoCategoria).HasMaxLength(6).HasComment("Nombre Abreviado;text;true;true;Datos;180;left");
                entity.Property(e => e.ActivaCategoria).HasMaxLength(1).HasDefaultValueSql("'1'");
                entity.Property(e => e.LineasCategorias).HasMaxLength(20).HasDefaultValueSql("'SINA'").HasComment("Linea;combo;true;true;Datos;180;left;select CodigoLinea,NombreLinea from lineas");
                entity.Property(e => e.NombreCategoria).HasMaxLength(60).HasComment("Nombre Categoria;text;true;true;Datos;180;left");
                entity.Property(e => e.PresupuestoCategoria).HasMaxLength(1).HasDefaultValueSql("'0'");
                entity.Property(e => e.UsuariosCategoria).HasMaxLength(20).HasDefaultValueSql("'fmaldonado'");
                // entity.HasOne(d => d.LineasCategoriasNavigation).WithMany(p => p.Categoria).HasForeignKey(d => d.LineasCategorias).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_LineasCategorias");
            });

            modelBuilder.Entity<Grupo>(entity =>
            {
                entity.HasKey(e => e.CodigoGrupo).HasName("PRIMARY");
                entity.ToTable("grupos");
                entity.HasComment("Grupo;NombreGrupo,AbreviadoGrupo");
                entity.HasIndex(e => e.CodigoGrupo, "CodigoGrupo").IsUnique();
                entity.HasIndex(e => e.CategoriasGrupos, "FK_grupos_categorias");
                entity.HasIndex(e => e.IdMarca, "idMarca");
                entity.Property(e => e.CodigoGrupo).HasMaxLength(20).HasComment("Codigo Grupo;text;true;false;Datos;180;left");
                entity.Property(e => e.AbreviadoGrupo).HasMaxLength(6).HasComment("Nombre Abreviado;text;true;true;Datos;180;left");
                entity.Property(e => e.ActivoGrupo).HasMaxLength(1).HasDefaultValueSql("'1'");
                entity.Property(e => e.CategoriasGrupos).HasMaxLength(20).HasDefaultValueSql("''").HasComment("Categoria;combo;true;true;Datos;180;left;select CodigoCategoria,NombreCategoria from Categorias");
                entity.Property(e => e.IdMarca).HasMaxLength(20).HasColumnName("idMarca").HasComment("Marca;combo;true;true;Datos;180;left;SELECT CodigoMarca, NombreMarca FROM marcas ORDER BY NombreMarca");
                entity.Property(e => e.NombreGrupo).HasMaxLength(60).HasComment("Nombre Grupo;text;true;true;Datos;180;left");
                entity.Property(e => e.PresupuestoGrupo).HasMaxLength(1).HasDefaultValueSql("'0'").IsFixedLength();
                entity.Property(e => e.UsuariosGrupo).HasMaxLength(20).HasDefaultValueSql("'fmaldonado'");
            });
            modelBuilder.Entity<Marca>(entity =>
            {
                entity.HasKey(e => e.CodigoMarca).HasName("PRIMARY");
                entity.ToTable("marcas");
                entity.HasComment("Marca;NombreMarca,AbreviadoMarca");
                entity.HasIndex(e => e.CodigoMarca, "CodigoMarca").IsUnique();
                entity.HasIndex(e => e.AbreviadoMarca, "Index_Abreviado");
                entity.HasIndex(e => e.NombreMarca, "Index_Nombre").IsUnique();
                entity.HasIndex(e => e.JefeMarca, "JefeMarca");
                entity.Property(e => e.CodigoMarca).HasMaxLength(20).HasDefaultValueSql("''").HasComment("Codigo Marca;text;true;false;Datos;180;left");
                entity.Property(e => e.AbreviadoMarca).HasMaxLength(6).HasComment("Nombre Abreviado;text;true;true;Datos;180;left");
                entity.Property(e => e.EcommerceIdMarca).HasMaxLength(20).HasDefaultValueSql("'0'");
                entity.Property(e => e.FechaModificacionMarca).HasColumnType("datetime").HasDefaultValueSql("'1990-01-01 00:00:00'");
                entity.Property(e => e.FechaRegistroMarca).HasColumnType("datetime").HasDefaultValueSql("'1990-01-01 00:00:00'");
                entity.Property(e => e.GestionadaRemotamenteMarca).HasMaxLength(1).HasDefaultValueSql("'0'").HasComment("GestionadaRemotamente;chk;true;true;Datos;180;left");
                entity.Property(e => e.IconoMarca).HasMaxLength(100).HasDefaultValueSql("'internet.png'");
                entity.Property(e => e.JefeMarca).HasMaxLength(20).HasDefaultValueSql("''").HasComment("Jefe Marca;combo;true;true;Datos;380;left;SELECT CodigoEmpleado,Concat(ApellidoEmpleado,' ',NombreEmpleado) as Empleado FROM empleados Order by ApellidoEmpleado");
                entity.Property(e => e.NombreMarca).HasMaxLength(100).HasComment("Nombre Marca;text;true;true;Datos;180;left");
                entity.Property(e => e.PresupuestoMarca).HasMaxLength(1).HasDefaultValueSql("'1'").HasComment("Presupuestar Marca;chk;true;true;Datos;180;left");
                entity.Property(e => e.SincronizarEcommerceMarca).HasColumnType("int(1)");
                entity.Property(e => e.TiposTecnologiaMarca).HasMaxLength(20).HasDefaultValueSql("'1'");
                entity.Property(e => e.UsuariosMarca).HasMaxLength(20).HasDefaultValueSql("'fmaldonado'");
                entity.Property(e => e.UsuariosModificaMarca).HasMaxLength(20).HasDefaultValueSql("'wise'");
            });
            modelBuilder.Entity<Tiposproducto>(entity =>
            {
                entity.HasKey(e => e.CodigoTipoProducto).HasName("PRIMARY");
                entity.ToTable("tiposproducto");
                entity.HasIndex(e => e.CodigoTipoProducto, "CodigoTipoProducto").IsUnique();
                entity.Property(e => e.CodigoTipoProducto).HasMaxLength(20).HasDefaultValueSql("''").HasComment("Codigo ;text;true;false;Datos;120;left");
                entity.Property(e => e.DescripcionTipoProducto).HasMaxLength(100).HasDefaultValueSql("''").HasComment("Descripcion ;text;true;True;Datos;200;left");
                entity.Property(e => e.PresentaciónTipoProducto).HasMaxLength(3).HasDefaultValueSql("''").HasComment("Abreviado (max 3);text;true;True;Datos;20;left");
                entity.Property(e => e.UsuariosTipoProductos).HasMaxLength(20).HasDefaultValueSql("'Admin'");
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
