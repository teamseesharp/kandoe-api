using AutoMapper;

using Kandoe.Web.Model.Mapping;
using Kandoe.Web.Model.Mapping.Profiles;

namespace Kandoe.Web.Configuration {
    public static class MapperConfig {
        public static void Configure() {
            MapperConfiguration config = new MapperConfiguration(
                cfg => {
                    cfg.AddProfile<AccountProfile>();
                    cfg.AddProfile<CardProfile>();
                    cfg.AddProfile<ChatMessageProfile>();
                    cfg.AddProfile<OrganisationProfile>();
                    cfg.AddProfile<SessionProfile>();
                    cfg.AddProfile<SnapshotProfile>();
                    cfg.AddProfile<SubthemeProfile>();
                    cfg.AddProfile<ThemeProfile>();
                }
            );

            ModelMapper.Mapper = config.CreateMapper();
        }
    }
}