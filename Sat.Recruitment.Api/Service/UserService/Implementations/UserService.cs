using Sat.Recruitment.Api.Dtos;
using Sat.Recruitment.Api.Models;
using Sat.Recruitment.Api.Validators;
using Sat.Recruitment.Api.Service.Interface;
using Sat.Recruitment.Api.Repository.Interface;
using Sat.Recruitment.Api.Service.UserService.Helpers;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Service.Implements
{
    public class UserService : IUserService
    {
        #region Variables
        private readonly IUserRepository userRepository;
        #endregion

        #region Constructor
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        #endregion

        #region Public methods
        public async Task<UserResult> Create(User user)
        {
            UserValidator userValidator = new UserValidator();
            UserResult userResult = new UserResult();
            var validations = userValidator.ValidateErrors(user);
            if (!validations.Item1)
            {
                userResult.Errors = validations.Item2;
                userResult.IsSuccess = false;
                userResult.User = null;
                return userResult;
            }

            switch (user.UserType)
            {
                case "Normal":
                    user.Money = UserHelper.UserMoneyNormal(user.Money);
                    break;
                case "SuperUser":
                    user.Money = UserHelper.UserMoneySuperUser(user.Money);
                    break;
                case "Premium":
                    user.Money = UserHelper.UserMoneyPremium(user.Money);
                    break;
            }

            user.Email = UserHelper.NormalizeEmail(user.Email);


            if (await userRepository.IsUserDuplicated(user))
            {
                userResult.Errors = "User is duplicated.";
                userResult.User = null;
                userResult.IsSuccess = false;
                return userResult;
            }

            await userRepository.Add(user);
            userResult.User = user;
            userResult.IsSuccess = true;
            return userResult;
        }
        #endregion
    }
}
