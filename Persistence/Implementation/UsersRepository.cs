using Domain.Entities;
using Persistence.Interfaces;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Persistence.Implementation
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IUsersFiles _usersFiles;

        public UsersRepository(IUsersFiles usersFiles)
        {
            _usersFiles = usersFiles;
        }
        public async Task<IList<User>> GetAllAsync()
        {
            List<User> users = new List<User>();
            

            using var reader = _usersFiles.GetUsers();
          //  var nose = await reader.ReadToEndAsync();

            while (reader.Peek() >= 0)
            {
                var line = await reader.ReadLineAsync();

                if (line != null) {
                    var user = new User
                    {
                        Name = line.Split(',')[0].ToString(),
                        Email = line.Split(',')[1].ToString(),
                        Phone = line.Split(',')[2].ToString(),
                        Address = line.Split(',')[3].ToString(),
                        UserType = line.Split(',')[4].ToString(),
                        Money = decimal.Parse(line.Split(',')[5].ToString().Replace(".", ",")),
                    };
                    users.Add(user);
                }
            }

            return users;


        }

        public async Task<bool> AddUser(User user)
        {
            try
            {
              await _usersFiles.AddUser(user);

               return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($": {e.Message}");
                return false;
            }
        }
    }
}
