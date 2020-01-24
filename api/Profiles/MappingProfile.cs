using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace api.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Owner, OwnerDto>();
            CreateMap<Account, AccountDto>();
            CreateMap<Owner, OwnerDto>();
        }
    }
}