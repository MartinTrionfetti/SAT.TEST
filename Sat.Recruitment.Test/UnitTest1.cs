using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Api.Controllers;
using Sat.Recruitment.Api.Dtos;
using Sat.Recruitment.Api.Mappings;
using Sat.Recruitment.Api.Repository.Implements;
using Sat.Recruitment.Api.Service.Implements;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UnitTest1
    {
        private int RandomInt(int max) => new Random(Guid.NewGuid().GetHashCode()).Next(0, max);
        private string RandomString(int length = 6) => Guid.NewGuid().ToString().Substring(0, length);
        public UserService UserService { get; set; }
        private IMapper mapper { get; set; }
        public UnitTest1()
        {
            UserService = new UserService(new UserRepository());

            MapperConfiguration mapperConfig = new MapperConfiguration(
            cfg =>
               {
                   cfg.AddProfile(new MappingProfile());
               });

            mapper = new Mapper(mapperConfig);
        }
        [Fact]
        public async Task Test1Async()
        {
            var userController = new UsersController(UserService, mapper);

            UserCreateRequestDto userRequestDto = new UserCreateRequestDto()
            {
                Name = RandomString(),
                Email = RandomString() + "@gmail.com",
                Address = RandomString(),
                Phone = RandomString(),
                UserType = "Normal",
                Money = RandomInt(5000)
            };

            var result = await userController.Create(userRequestDto) as ObjectResult;

            Assert.NotNull(result);
            Assert.IsType<UserCreateResponseDto>(result.Value);
            Assert.True((result.Value as UserCreateResponseDto).IsSuccess);
            Assert.Equal(userRequestDto.Email, (result.Value as UserCreateResponseDto).User.Email);
        }

        [Fact]
        public async Task Test2Async()
        {
            var userController = new UsersController(UserService, mapper);

            UserCreateRequestDto userRequestDto = new UserCreateRequestDto()
            {
                Name = RandomString(),
                Email = RandomString() + "@gmail.com",
                Address = RandomString(),
                Phone = RandomString(),
                UserType = "Normal",
                Money = RandomInt(5000)
            };

            await userController.Create(userRequestDto);
            var result = await userController.Create(userRequestDto) as ObjectResult;

            //Expected BadRequest
            Assert.NotNull(result);
            Assert.IsType<UserCreateResponseDto>(result.Value);
            Assert.False((result.Value as UserCreateResponseDto).IsSuccess);
            Assert.Equal("User is duplicated.", (result.Value as UserCreateResponseDto).Errors);
        }        
    }
}
