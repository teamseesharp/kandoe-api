using AutoMapper;

using Kandoe.Web.Model.Mapping;

namespace Kandoe.Web.Configuration {
    public static class MapperConfig {
        public static void Configure() {
            MapperConfiguration config = new MapperConfiguration(
                cfg => {
                    cfg.AddProfile<AccountProfile>();
                    cfg.AddProfile<CardProfile>();
                    cfg.AddProfile<CardReviewProfile>();
                    cfg.AddProfile<ChatMessageProfile>();
                    cfg.AddProfile<OrganisationProfile>();
                    cfg.AddProfile<SessionProfile>();
                    cfg.AddProfile<SessionProfile>();
                    cfg.AddProfile<SubthemeProfile>();
                    cfg.AddProfile<ThemeProfile>();
                }
            );

            ModelMapper.Mapper = config.CreateMapper();
        }
    }
}