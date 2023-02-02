using Sat.Recruitment.Api.Models;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Service.Interface
{
    public interface IUserService
    {
        Task<UserResult> Create(User user);
        //decimal UserMoneyNormal(User user);
        //decimal UserMoneySuperUser(User user);
        //decimal UserMoneyPremium(User user);
    }
}
