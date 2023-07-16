using apiwise.Models.Empresas;
using AutoMapper;
using Models;

namespace apiwise.Mapper
{
    public class EmpresasProfile : Profile
    {
        public EmpresasProfile()
        {
            CreateMap<Empresa, EmpresaDto>()
                .ForMember(dest => dest.CodigoEmpresa, opt => opt.MapFrom(o => o.CodigoEmpresa))
                .ForMember(dest => dest.RucEmpresa, opt => opt.MapFrom(o => o.RucEmpresa))
                .ForMember(dest => dest.NombreEmpresa, opt => opt.MapFrom(o => o.NombreEmpresa))
                .ForMember(dest => dest.NombreEmpresaImpresion, opt => opt.MapFrom(o => o.NombreEmpresaImpresion))
                .ForMember(dest => dest.NombreComercialEmpresa, opt => opt.MapFrom(o => o.NombreComercialEmpresa))
                .ForMember(dest => dest.CodigoDinardapEmpresa, opt => opt.MapFrom(o => o.CodigoDinardapEmpresa))
                .ForMember(dest => dest.LogoEmpresa, opt => opt.MapFrom(o => o.LogoEmpresa))
                .ForMember(dest => dest.OrdenIncialEmpresa, opt => opt.MapFrom(o => o.OrdenIncialEmpresa))
                .ForMember(dest => dest.VisualizarNombreComercialEmpresa, opt => opt.MapFrom(o => o.VisualizarNombreComercialEmpresa))
                .ForMember(dest => dest.UsuariosEmpresa, opt => opt.MapFrom(o => o.UsuariosEmpresa));
        }
    }
}
