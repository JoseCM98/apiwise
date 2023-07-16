using AutoMapper;

namespace apiwise.Mapper
{
    /// <summary>
    /// 
    /// </summary>
    public class AutomapperProfiles
    {
        public static Action<IMapperConfigurationExpression> ProfilesConfig = new(cfg =>
        {
            cfg.AddProfile<EmpleadoProfile>();
            cfg.AddProfile<PagosProfile>();
            cfg.AddProfile<EmpresasProfile>();
        });
    }
}
