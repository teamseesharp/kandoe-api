using AutoMapper;

using Kandoe.Business.Domain;
using Kandoe.Web.Model.Dto;
using Kandoe.Web.Model.Mapping;

namespace Kandoe.Web.Model.Mapping.Profiles {
    public class AccountProfile : Profile {
        protected override void Configure() {
            this.CreateMap<Account, AccountDto>()
                .Ignore(account => account.Secret);

            this.CreateMap<AccountDto, Account>()
                .ConstructUsing(
                    dto => new Account(
                        dto.Email,
                        dto.Name,
                        dto.Surname,
                        dto.Picture,
                        dto.Secret
                    ));
        }
    }
}