using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Api.Dtos;
using Sat.Recruitment.Api.Models;
using Sat.Recruitment.Api.Service.Interface;
using System;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public partial class UsersController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Create(UserCreateRequestDto dto)
        {
            try
            {
                var user = mapper.Map<User>(dto);

                var userResult = await userService.Create(user);

                var userResponse = mapper.Map<UserCreateResponseDto>(userResult);

                if (userResponse.User == null)
                    return BadRequest(userResponse);
                else
                    return Ok(userResponse);                    
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
    }
   
}
