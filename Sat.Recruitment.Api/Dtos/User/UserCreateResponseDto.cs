using Sat.Recruitment.Api.Mappings;
using Sat.Recruitment.Api.Models;

namespace Sat.Recruitment.Api.Dtos
{
    public class UserCreateResponseDto : IMapFrom<UserResult>
    {
        public void Mapping(AutoMapper.Profile profile)
        {
            profile.CreateMap<UserResult, UserCreateResponseDto>().ReverseMap();
        }
        public User User { get; set; }
        public bool IsSuccess { get; set; }
        public string Errors { get; set; }
    }
}
