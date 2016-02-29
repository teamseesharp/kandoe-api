using AutoMapper;

using Kandoe.Business.Domain;
using Kandoe.Web.Model.Dto;

namespace Kandoe.Web.Model.Mapping {
    public class AccountProfile : Profile {
        protected override void Configure() {
            this.CreateMap<Account, AccountDto>();

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