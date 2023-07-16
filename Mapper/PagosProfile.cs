using apiwise.Models.Pagos.PagosDto;
using AutoMapper;
using Models;

namespace apiwise.Mapper
{
    public class PagosProfile : Profile
    {
        public PagosProfile()
        {
            CreateMap<PagoscabeceraDTO, Pagoscabecera>()
               .ForMember(dest => dest.CodigoPagoCabecera,
                       opt => opt.MapFrom(o => o.id))
               .ForMember(dest => dest.EmpresasPagoCabecera,
                       opt => opt.MapFrom(o => o.empresa))
               .ForMember(dest => dest.SucursalesPagoCabecera,
                       opt => opt.MapFrom(o => o.sucursal))
               .ForMember(dest => dest.NumeroPagosPagoCabecera,
                       opt => opt.MapFrom(o => o.numpago))
               .ForMember(dest => dest.FechaPagoCabecera,
                       opt => opt.MapFrom(o => o.fecha))
               .ForMember(dest => dest.FormaPagoPagoCabecera,
                       opt => opt.MapFrom(o => o.formapago))
               .ForMember(dest => dest.TipoPagoCabecera,
                       opt => opt.MapFrom(o => o.tipopago))
               .ForMember(dest => dest.NumeroDocumentoPagoCabecera,
                       opt => opt.MapFrom(o => o.numerodoc))
               .ForMember(dest => dest.ValorPagoCabecera,
                       opt => opt.MapFrom(o => o.valorpago))
               .ForMember(dest => dest.DiferenciaPagoCabecera,
                       opt => opt.MapFrom(o => o.diferencia))
               .ForMember(dest => dest.ValorCruceEmpleadoPagoCabecera,
                       opt => opt.MapFrom(o => o.valoremplecruze))
               .ForMember(dest => dest.EmpleadoCrucePagoCabecera,
                       opt => opt.MapFrom(o => o.emplecruze))
               .ForMember(dest => dest.EmpleadosCobroPagoCabecera,
                       opt => opt.MapFrom(o => o.emplecobro))
               .ForMember(dest => dest.EstadoPagoCabecera,
                       opt => opt.MapFrom(o => o.estado))
               .ForMember(dest => dest.AsientosCabeceraPagoCabecera,
                       opt => opt.MapFrom(o => o.asientoCab))
               .ForMember(dest => dest.NumeroReciboPagoCabecera,
                       opt => opt.MapFrom(o => o.numrecibo))
               .ForMember(dest => dest.CodigoMovilPagoCabecera,
                       opt => opt.MapFrom(o => o.codmovil))
               .ForMember(dest => dest.ObservacionPagoCabecera,
                       opt => opt.MapFrom(o => o.observacion))
               .ForMember(dest => dest.FechaRegistro,
                       opt => opt.MapFrom(o => o.fecharegistro))
               .ForMember(dest => dest.UsuariosPagoCabecera,
                       opt => opt.MapFrom(o => o.usuario))
               .ForMember(dest => dest.EstadoSincronizado,
                       opt => opt.MapFrom(o => o.sincronizacion));


            CreateMap<PagoschequedetalleDTO, Pagoschequedetalle>()
                .ForMember(dest => dest.CodigoPagoChequeDetalle,
                        opt => opt.MapFrom(o => o.id))
                .ForMember(dest => dest.PagosCabeceraPagoDetalle,
                        opt => opt.MapFrom(o => o.pagocab))
                .ForMember(dest => dest.PropietarioPagoChequeDetalle,
                        opt => opt.MapFrom(o => o.propietario))
                .ForMember(dest => dest.BancosPagoDetalle,
                        opt => opt.MapFrom(o => o.banco))
                .ForMember(dest => dest.NumeroCuentaPagoDetalle,
                        opt => opt.MapFrom(o => o.numcuenta))
                .ForMember(dest => dest.NumeroChequePagoChequeDetalle,
                        opt => opt.MapFrom(o => o.numcheque))
                .ForMember(dest => dest.ValorDocumentoPagoDetalle,
                        opt => opt.MapFrom(o => o.valordoc))
                .ForMember(dest => dest.FechaDocumentoPagoDetalle,
                        opt => opt.MapFrom(o => o.fechadoc))
                .ForMember(dest => dest.EstadoDocumentoPagoDetalle,
                        opt => opt.MapFrom(o => o.estadodoc))
                .ForMember(dest => dest.AsientosCabeceraPagoDetalle,
                        opt => opt.MapFrom(o => o.asientocab));

            CreateMap<PagosdetalleDTO, Pagosdetalle>()
                .ForMember(dest => dest.CodigoPagoDetalle,
                        opt => opt.MapFrom(o => o.id))
                .ForMember(dest => dest.PagosCabeceraPagoDetalle,
                        opt => opt.MapFrom(o => o.pagocab))
                .ForMember(dest => dest.CreditosDetallePagoDetalle,
                        opt => opt.MapFrom(o => o.creditodeta))
                .ForMember(dest => dest.ValorPagoDetalle,
                        opt => opt.MapFrom(o => o.valor))
                .ForMember(dest => dest.FormaPagoPagoCabecera,
                        opt => opt.MapFrom(o => o.formpago))
                .ForMember(dest => dest.NumeroDocumentoPagoDetalle,
                        opt => opt.MapFrom(o => o.numdoc))
                .ForMember(dest => dest.FechaDocumentoPagoDetalle,
                        opt => opt.MapFrom(o => o.fechadoc))
                .ForMember(dest => dest.PropietarioPagoDetalle,
                        opt => opt.MapFrom(o => o.propietario))
                .ForMember(dest => dest.BancosPagoDetalle,
                        opt => opt.MapFrom(o => o.banco))
                .ForMember(dest => dest.NumeroCuentaPagoDetalle,
                        opt => opt.MapFrom(o => o.numcuenta))
                .ForMember(dest => dest.NumeroChequePagoDetalle,
                        opt => opt.MapFrom(o => o.numcheque))
                .ForMember(dest => dest.ValorDocumentoPagoDetalle,
                        opt => opt.MapFrom(o => o.valordoc))
                .ForMember(dest => dest.EstadoDocumentoPagoDetalle,
                        opt => opt.MapFrom(o => o.estadodoc))
                .ForMember(dest => dest.ObservacionPagoDetalle,
                        opt => opt.MapFrom(o => o.observacion));

            CreateMap<PagosdetalleinteresesDTO, Pagosdetalleinterese>()
               .ForMember(dest => dest.CodigoPagoDetalleInteres,
                       opt => opt.MapFrom(o => o.id))
               .ForMember(dest => dest.PagosCabeceraPagoDetalleInteres,
                       opt => opt.MapFrom(o => o.pagocab))
               .ForMember(dest => dest.PagosdetallepagosdetalleIntereses,
                       opt => opt.MapFrom(o => o.pagodeta))
               .ForMember(dest => dest.CreditosDetallePagoDetalleInteres,
                       opt => opt.MapFrom(o => o.creditodeta))
               .ForMember(dest => dest.BaseInterespagodetalleinteres,
                       opt => opt.MapFrom(o => o.baseinte))
               .ForMember(dest => dest.InterescuotapagodetalleInteres,
                       opt => opt.MapFrom(o => o.intecuota))
               .ForMember(dest => dest.MorapagodetalleInteres,
                       opt => opt.MapFrom(o => o.mora))
               .ForMember(dest => dest.PorcentajemorapagodetalleInteres,
                       opt => opt.MapFrom(o => o.porcenmora));

            CreateMap<PagosmanejoscajasDto, Pagosmanejoscaja>()
              .ForMember(dest => dest.CodigoPagoManejoCaja,
                      opt => opt.MapFrom(o => o.id))
              .ForMember(dest => dest.PagosCabeceraPagoManejoCaja,
                      opt => opt.MapFrom(o => o.pagocab))
              .ForMember(dest => dest.ManejoCajasPagoManejoCaja,
                      opt => opt.MapFrom(o => o.manejocaja))
              .ForMember(dest => dest.FechaRegistroPagoManejoaCaja,
                      opt => opt.MapFrom(o => o.fecha))
              .ForMember(dest => dest.UsuariosPagoManejoCaja,
                      opt => opt.MapFrom(o => o.usuario));
        }
    }
}
