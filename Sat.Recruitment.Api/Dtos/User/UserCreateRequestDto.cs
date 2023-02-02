using Sat.Recruitment.Api.Mappings;
using Sat.Recruitment.Api.Models;

namespace Sat.Recruitment.Api.Dtos
{
    public class UserCreateRequestDto : IMapFrom<User>
    {
        public void Mapping(AutoMapper.Profile profile)
        {
            profile.CreateMap<User, UserCreateRequestDto>().ReverseMap();
        }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string UserType { get; set; }
        public decimal Money { get; set; }
    }
}
