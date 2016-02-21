using AutoMapper;

namespace Kandoe.Web.Model.Mapping {
    public static class ModelMapper {
        public static IMapper Mapper { private get; set; }

        public static TDestination Map<TDestination>(object source) {
            return Mapper.Map<TDestination>(source);
        }

        public static TDestination Map<TSource, TDestination>(TSource source) {
            return Mapper.Map<TSource, TDestination>(source);
        }
    }
}