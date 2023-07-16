using apiwise.Models.EmpleadosDtos;
using apiwise.Models.Usuarios;
using AutoMapper;
using Models;

namespace apiwise.Mapper
{
    public class EmpleadoProfile : Profile
    {
        public EmpleadoProfile()
        {
            CreateMap<Empleado, EmpleadosDto>()
                .ForMember(dest => dest.CodigoEmpleado,
                           opt => opt.MapFrom(o => o.CodigoEmpleado))
                .ForMember(dest => dest.NombreEmpleado,
                           opt => opt.MapFrom(o => o.NombreEmpleado))
                .ForMember(dest => dest.ApellidoEmpleado,
                           opt => opt.MapFrom(o => o.ApellidoEmpleado))
                .ForMember(dest => dest.EmailEmpleado,
                           opt => opt.MapFrom(o => o.EmailEmpleado))
                .ForMember(dest => dest.TiposEmpleadosEmpleado,
                           opt => opt.MapFrom(o => o.TiposEmpleadosEmpleado))
                .ForMember(dest => dest.PerfilesEmpleado,
                           opt => opt.MapFrom(o => o.PerfilesEmpleado))
                .ForMember(dest => dest.NombreUsuarioEmpleado,
                           opt => opt.MapFrom(o => o.NombreUsuarioEmpleado))
                .ForMember(dest => dest.ClaveUsuarioEmpleado,
                           opt => opt.MapFrom(o => o.ClaveUsuarioEmpleado))
                .ForMember(dest => dest.CambiarPrimeraVezEmpleado,
                           opt => opt.MapFrom(o => o.CambiarPrimeraVezEmpleado))
                .ForMember(dest => dest.ClaveCaducaEmpleado,
                           opt => opt.MapFrom(o => o.ClaveCaducaEmpleado))
                .ForMember(dest => dest.FechaCaducaClaveEmpleado,
                           opt => opt.MapFrom(o => o.FechaCaducaClaveEmpleado))
                .ForMember(dest => dest.UsuarioCaducaEmpleado,
                           opt => opt.MapFrom(o => o.UsuarioCaducaEmpleado))
                .ForMember(dest => dest.FechaCaducaUsuarioEmpleado,
                           opt => opt.MapFrom(o => o.FechaCaducaUsuarioEmpleado))
                .ForMember(dest => dest.SeleccionaEmpresaEmpleado,
                           opt => opt.MapFrom(o => o.SeleccionaEmpresaEmpleado))
                .ForMember(dest => dest.SeleccionaSucursalEmpleado,
                           opt => opt.MapFrom(o => o.SeleccionaSucursalEmpleado))
                .ForMember(dest => dest.EmpresasEmpleado,
                           opt => opt.MapFrom(o => o.EmpresasEmpleado))
                .ForMember(dest => dest.SucursalesEmpleado,
                           opt => opt.MapFrom(o => o.SucursalesEmpleado))
                .ForMember(dest => dest.TiposIdentificacionEmpleado,
                           opt => opt.MapFrom(o => o.TiposIdentificacionEmpleado))
                .ForMember(dest => dest.CedulaEmpleado,
                           opt => opt.MapFrom(o => o.CedulaEmpleado))
                .ForMember(dest => dest.TitulosEmpleado,
                           opt => opt.MapFrom(o => o.TitulosEmpleado))
                .ForMember(dest => dest.EspecialidadesMedicasEmpleado,
                           opt => opt.MapFrom(o => o.EspecialidadesMedicasEmpleado))
                .ForMember(dest => dest.DireccionUnoEmpleado,
                           opt => opt.MapFrom(o => o.DireccionUnoEmpleado))
                .ForMember(dest => dest.DireccionDosEmpleado,
                           opt => opt.MapFrom(o => o.DireccionDosEmpleado))
                .ForMember(dest => dest.TelefonoUnoEmpleado,
                           opt => opt.MapFrom(o => o.TelefonoUnoEmpleado))
                .ForMember(dest => dest.TelefonoDosEmpleado,
                           opt => opt.MapFrom(o => o.TelefonoDosEmpleado))
                .ForMember(dest => dest.TelefonoTresEmpleado,
                           opt => opt.MapFrom(o => o.TelefonoTresEmpleado))
                .ForMember(dest => dest.EmailEmpleadoPersonal,
                           opt => opt.MapFrom(o => o.EmailEmpleadoPersonal))
                .ForMember(dest => dest.FechaNacimientoEmpleado,
                           opt => opt.MapFrom(o => o.FechaNacimientoEmpleado))
                .ForMember(dest => dest.CargaFamiliarEmpleado,
                           opt => opt.MapFrom(o => o.CargaFamiliarEmpleado))
                .ForMember(dest => dest.CuentasContabilidadEmpleado,
                           opt => opt.MapFrom(o => o.CuentasContabilidadEmpleado))
                .ForMember(dest => dest.CuentasContabilidadAnticipoEmpleado,
                           opt => opt.MapFrom(o => o.CuentasContabilidadAnticipoEmpleado))
                .ForMember(dest => dest.CuentasContabilidadViaticoEmpleado,
                           opt => opt.MapFrom(o => o.CuentasContabilidadViaticoEmpleado))
                .ForMember(dest => dest.CuentasContabilidadPrestamoEmpleado,
                           opt => opt.MapFrom(o => o.CuentasContabilidadPrestamoEmpleado))
                .ForMember(dest => dest.CuentasContabilidadSaldoEmpleado,
                           opt => opt.MapFrom(o => o.CuentasContabilidadSaldoEmpleado))
                .ForMember(dest => dest.CuentasContabilidadGastoDesahucioEmpleado, opt => opt.MapFrom(o => o.CuentasContabilidadGastoDesahucioEmpleado))
                .ForMember(dest => dest.CuentasContabilidadGastoEmpleado, opt => opt.MapFrom(o => o.CuentasContabilidadGastoEmpleado))
                .ForMember(dest => dest.CuentasContabilidadIessEmpleado,
                           opt => opt.MapFrom(o => o.CuentasContabilidadIessEmpleado))
                .ForMember(dest => dest.CuentasContabilidadIessPatronalEmpleado,
                           opt => opt.MapFrom(o => o.CuentasContabilidadIessPatronalEmpleado))
                .ForMember(dest => dest.CuentasContabilidadIessGastoPatronalEmpleado,
                           opt => opt.MapFrom(o => o.CuentasContabilidadIessGastoPatronalEmpleado))
                .ForMember(dest => dest.CuentasContabilidadXiiiEmpleado,
                           opt => opt.MapFrom(o => o.CuentasContabilidadXiiiEmpleado))
                .ForMember(dest => dest.CuentasContabilidadXivEmpleado,
                           opt => opt.MapFrom(o => o.CuentasContabilidadXivEmpleado))
                .ForMember(dest => dest.CuentasContabilidadFondoReservaEmpleado,
                           opt => opt.MapFrom(o => o.CuentasContabilidadFondoReservaEmpleado))
                .ForMember(dest => dest.CuentasContabilidadHoraJornadaNocturna,
                           opt => opt.MapFrom(o => o.CuentasContabilidadHoraJornadaNocturna))
                .ForMember(dest => dest.CuentasContabilidadHoraSuplementariaEmpleado,
                           opt => opt.MapFrom(o => o.CuentasContabilidadHoraSuplementariaEmpleado))
                .ForMember(dest => dest.CuentasContabilidadHoraExtraordinariaEmpleado,
                           opt => opt.MapFrom(o => o.CuentasContabilidadHoraExtraordinariaEmpleado))
                .ForMember(dest => dest.CuentasContabilidadRubrosEmpleado,
                           opt => opt.MapFrom(o => o.CuentasContabilidadRubrosEmpleado))
                .ForMember(dest => dest.CuentasContabilidadAtrazoEmpleado,
                           opt => opt.MapFrom(o => o.CuentasContabilidadAtrazoEmpleado))
                .ForMember(dest => dest.CuentasContabilidadMultaEmpleado,
                           opt => opt.MapFrom(o => o.CuentasContabilidadMultaEmpleado))
                .ForMember(dest => dest.CuentasContabilidadVacacionEmpleado,
                           opt => opt.MapFrom(o => o.CuentasContabilidadVacacionEmpleado))
                .ForMember(dest => dest.CuentasContabilidadComisionesEmpleado,
                           opt => opt.MapFrom(o => o.CuentasContabilidadComisionesEmpleado))
                .ForMember(dest => dest.CuentasContabilidadNominasEmpleado,
                           opt => opt.MapFrom(o => o.CuentasContabilidadNominasEmpleado))
                .ForMember(dest => dest.CuentasContabilidadProvisionFondoReservaEmpleado,
                           opt => opt.MapFrom(o => o.CuentasContabilidadProvisionFondoReservaEmpleado))
                .ForMember(dest => dest.CuentasContabilidadProvisionDecimoXiiiempleado,
                           opt => opt.MapFrom(o => o.CuentasContabilidadProvisionDecimoXiiiempleado))
                .ForMember(dest => dest.CuentasContabilidadProvisionDecimoXivempleado,
                           opt => opt.MapFrom(o => o.CuentasContabilidadProvisionDecimoXivempleado))
                .ForMember(dest => dest.CuentasContabilidadProvisionVacacionesEmpleado,
                           opt => opt.MapFrom(o => o.CuentasContabilidadProvisionVacacionesEmpleado))
                .ForMember(dest => dest.CuentasContabilidadPrestamosIess,
                           opt => opt.MapFrom(o => o.CuentasContabilidadPrestamosIess))
                .ForMember(dest => dest.CuentasContabilidadQuincena,
                           opt => opt.MapFrom(o => o.CuentasContabilidadQuincena))
                .ForMember(dest => dest.CuentasContabilidadBonoFijo,
                           opt => opt.MapFrom(o => o.CuentasContabilidadBonoFijo))
                .ForMember(dest => dest.CuentasContabilidadBonoVariable,
                           opt => opt.MapFrom(o => o.CuentasContabilidadBonoVariable))
                .ForMember(dest => dest.CuentasContabilidadBonoAlimenticio,
                           opt => opt.MapFrom(o => o.CuentasContabilidadBonoAlimenticio))
                .ForMember(dest => dest.SueldoNominalEmpleado,
                           opt => opt.MapFrom(o => o.SueldoNominalEmpleado))
                .ForMember(dest => dest.AdelantoQuincenalEmpleado,
                           opt => opt.MapFrom(o => o.AdelantoQuincenalEmpleado))
                .ForMember(dest => dest.HoraIngresoEmpleado,
                           opt => opt.MapFrom(o => o.HoraIngresoEmpleado))
                .ForMember(dest => dest.HoraSalidaEmpleado,
                           opt => opt.MapFrom(o => o.HoraSalidaEmpleado))
                .ForMember(dest => dest.TiempoAlmuerzoEmpleado,
                           opt => opt.MapFrom(o => o.TiempoAlmuerzoEmpleado))
                .ForMember(dest => dest.LetraCambioEmpleado,
                           opt => opt.MapFrom(o => o.LetraCambioEmpleado))
                .ForMember(dest => dest.CostaEmpleado,
                           opt => opt.MapFrom(o => o.CostaEmpleado))
                .ForMember(dest => dest.FondosReservaEmpleado,
                           opt => opt.MapFrom(o => o.FondosReservaEmpleado))
                .ForMember(dest => dest.RolPagoEmpleado,
                           opt => opt.MapFrom(o => o.RolPagoEmpleado))
                .ForMember(dest => dest.HoraExtraEmpleado,
                           opt => opt.MapFrom(o => o.HoraExtraEmpleado))
                .ForMember(dest => dest.MarcarEmpleado,
                           opt => opt.MapFrom(o => o.MarcarEmpleado))
                .ForMember(dest => dest.CalcularFondosReservaEmpleado,
                           opt => opt.MapFrom(o => o.CalcularFondosReservaEmpleado))
                .ForMember(dest => dest.CambiadoClaveEmpleado,
                           opt => opt.MapFrom(o => o.CambiadoClaveEmpleado))
                .ForMember(dest => dest.FormularioInicialEmpleado,
                           opt => opt.MapFrom(o => o.FormularioInicialEmpleado))
                .ForMember(dest => dest.PorcentajeAnticipoEmpleado,
                           opt => opt.MapFrom(o => o.PorcentajeAnticipoEmpleado))
                .ForMember(dest => dest.NumeroDiasHabilesVacacionTomadosEmpleado,
                           opt => opt.MapFrom(o => o.NumeroDiasHabilesVacacionTomadosEmpleado))
                .ForMember(dest => dest.NumeroDiasFinSemanaVacacionTomadosEmpleado,
                           opt => opt.MapFrom(o => o.NumeroDiasFinSemanaVacacionTomadosEmpleado))
                .ForMember(dest => dest.TipoSincronizacionEmpleado,
                           opt => opt.MapFrom(o => o.TipoSincronizacionEmpleado))
                .ForMember(dest => dest.EntregarDecimoEmpleado,
                           opt => opt.MapFrom(o => o.EntregarDecimoEmpleado))
                .ForMember(dest => dest.EntregarDecimoIvempleado,
                           opt => opt.MapFrom(o => o.EntregarDecimoIvempleado))
                .ForMember(dest => dest.BonoFijoEmpleado,
                           opt => opt.MapFrom(o => o.BonoFijoEmpleado))
                .ForMember(dest => dest.BonoVariableEmpleado,
                           opt => opt.MapFrom(o => o.BonoVariableEmpleado))
                .ForMember(dest => dest.BonoAlimentacionEmpleado,
                           opt => opt.MapFrom(o => o.BonoAlimentacionEmpleado))
                .ForMember(dest => dest.ValorFondoReservaEmpleado,
                           opt => opt.MapFrom(o => o.ValorFondoReservaEmpleado))
                .ForMember(dest => dest.TipoResidenciaEmpleado,
                           opt => opt.MapFrom(o => o.TipoResidenciaEmpleado))
                .ForMember(dest => dest.PaisResidenciaEmpleado,
                           opt => opt.MapFrom(o => o.PaisResidenciaEmpleado))
                .ForMember(dest => dest.DiscapacidadEmpleado,
                           opt => opt.MapFrom(o => o.DiscapacidadEmpleado))
                .ForMember(dest => dest.ConvenioEvitarDobleImposicionEmpleado,
                           opt => opt.MapFrom(o => o.ConvenioEvitarDobleImposicionEmpleado))
                .ForMember(dest => dest.PorcentajeDiscapacidadEmpleado,
                           opt => opt.MapFrom(o => o.PorcentajeDiscapacidadEmpleado))
                .ForMember(dest => dest.TipoIdentificacionReemplazaEmpleado,
                           opt => opt.MapFrom(o => o.TipoIdentificacionReemplazaEmpleado))
                .ForMember(dest => dest.CedulaRemplazoDiscapacidadEmplead,
                           opt => opt.MapFrom(o => o.CedulaRemplazoDiscapacidadEmplead))
                .ForMember(dest => dest.SistemaSalarioNetoEmpleado,
                           opt => opt.MapFrom(o => o.SistemaSalarioNetoEmpleado))
                .ForMember(dest => dest.TrabajaTiempoParcialEmpleado,
                           opt => opt.MapFrom(o => o.TrabajaTiempoParcialEmpleado))
                .ForMember(dest => dest.PresupuestarEmpleado,
                           opt => opt.MapFrom(o => o.PresupuestarEmpleado))
                .ForMember(dest => dest.RepresentanteLegalEmpleado,
                           opt => opt.MapFrom(o => o.RepresentanteLegalEmpleado))
                .ForMember(dest => dest.CuentaBancariaEmpleado,
                           opt => opt.MapFrom(o => o.CuentaBancariaEmpleado))
                .ForMember(dest => dest.TipoCuentaBancariaEmpleado,
                           opt => opt.MapFrom(o => o.TipoCuentaBancariaEmpleado))
                .ForMember(dest => dest.DuracionContratoEmpleado,
                           opt => opt.MapFrom(o => o.DuracionContratoEmpleado))
                .ForMember(dest => dest.NoCalculaBeneficiosEmpleado,
                           opt => opt.MapFrom(o => o.NoCalculaBeneficiosEmpleado))
                .ForMember(dest => dest.DiasLaboraTiempoParcialEmpleado,
                           opt => opt.MapFrom(o => o.DiasLaboraTiempoParcialEmpleado))
                .ForMember(dest => dest.VerCostoEmpleado,
                           opt => opt.MapFrom(o => o.VerCostoEmpleado))
                .ForMember(dest => dest.ImagenEmpleado,
                           opt => opt.MapFrom(o => o.ImagenEmpleado))
                .ForMember(dest => dest.NumeroCarnetConadisEmpleado,
                           opt => opt.MapFrom(o => o.NumeroCarnetConadisEmpleado))
                .ForMember(dest => dest.SustitutoEmpleado,
                           opt => opt.MapFrom(o => o.SustitutoEmpleado))
                .ForMember(dest => dest.UsuariosEmpleado,
                           opt => opt.MapFrom(o => o.UsuariosEmpleado))
                .ForMember(dest => dest.IesscodigosSectorialesEmpleado,
                           opt => opt.MapFrom(o => o.IesscodigosSectorialesEmpleado))
                .ForMember(dest => dest.EstadosCivilesPersonasEmpleados,
                           opt => opt.MapFrom(o => o.EstadosCivilesPersonasEmpleados))
                .ForMember(dest => dest.TiposSangrePersonasEmpleados,
                           opt => opt.MapFrom(o => o.TiposSangrePersonasEmpleados))
                .ForMember(dest => dest.GeneroEmpleado,
                           opt => opt.MapFrom(o => o.GeneroEmpleado))
                .ForMember(dest => dest.CuentasBancariasOrigenEmpleado,
                           opt => opt.MapFrom(o => o.CuentasBancariasOrigenEmpleado))
                .ForMember(dest => dest.FechaCalculoVacacionesEmpleado,
                           opt => opt.MapFrom(o => o.FechaCalculoVacacionesEmpleado))
                .ForMember(dest => dest.CuentasContabilidadDesahucioEmpleado,
                           opt => opt.MapFrom(o => o.CuentasContabilidadDesahucioEmpleado))
                .ForMember(dest => dest.CuentasContabilidadDespidoEmpleado,
                           opt => opt.MapFrom(o => o.CuentasContabilidadDespidoEmpleado))
                .ForMember(dest => dest.CuentasContabilidadOtrosIngresosEmpleado,
                           opt => opt.MapFrom(o => o.CuentasContabilidadOtrosIngresosEmpleado))
                .ForMember(dest => dest.CuentasContabilidadOtrosEgresosEmpleado,
                           opt => opt.MapFrom(o => o.CuentasContabilidadOtrosEgresosEmpleado))
                .ForMember(dest => dest.WebUsuarioEmpleado,
                           opt => opt.MapFrom(o => o.WebUsuarioEmpleado))
                .ForMember(dest => dest.TrabajaConstruccionEmpleado,
                           opt => opt.MapFrom(o => o.TrabajaConstruccionEmpleado))
                .ForMember(dest => dest.TiposRubroEmpleados,
                           opt => opt.MapFrom(o => o.TiposRubroEmpleados))
                .ForMember(dest => dest.PorcentajeIessEmpleados,
                           opt => opt.MapFrom(o => o.PorcentajeIessEmpleados))
                .ForMember(dest => dest.PorcentajeIessPatronoEmpleados,
                           opt => opt.MapFrom(o => o.PorcentajeIessPatronoEmpleados))
                .ForMember(dest => dest.PermiteAgendamientoEmpleados,
                           opt => opt.MapFrom(o => o.PermiteAgendamientoEmpleados))
                .ForMember(dest => dest.PlantillaCuentasEmpleados, opt => opt.MapFrom(o => o.PlantillaCuentasEmpleados))
                .ForMember(dest => dest.Ip, opt => opt.MapFrom(o => o.Ip));

            CreateMap<Empleado, authenticatedUser>()
               .ForMember(dest => dest.username,
                          opt => opt.MapFrom(o => o.NombreUsuarioEmpleado))
               .ForMember(dest => dest.nombres,
                          opt => opt.MapFrom(o => o.NombreEmpleado))
               .ForMember(dest => dest.apellidos,
                          opt => opt.MapFrom(o => o.ApellidoEmpleado))
               .ForMember(dest => dest.email,
                          opt => opt.MapFrom(o => o.EmailEmpleado));
        }
    }
}
