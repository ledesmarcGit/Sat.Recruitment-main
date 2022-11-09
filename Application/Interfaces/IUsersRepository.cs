using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUsersRepository
    {
        Task<IList<User>> GetAllAsync();

        Task<bool> AddUser(User user);
    }
}