using AutoMapper;

namespace Demo.UI.Mvc.Mappers
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x => { x.AddProfile<AutoMapperProfile>(); });
        }
    }
}