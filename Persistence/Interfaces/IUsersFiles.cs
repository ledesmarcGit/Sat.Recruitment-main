using Domain.Entities;
using System.IO;

namespace Persistence.Interfaces 
{ 
    public interface IUsersFiles
    {
        StreamReader GetUsers();

        Task<bool> AddUser(User user);
    }
}