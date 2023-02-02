using Sat.Recruitment.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Repository.Interface
{
    public interface IUserRepository
    {
        Task<bool> IsUserDuplicated(User user);
        Task<List<User>> GetAll();
        Task<bool> Add(User user);
    }
}
