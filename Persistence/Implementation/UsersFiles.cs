using Domain.Entities;
using Persistence.Interfaces;
using System;
using System.Diagnostics;
using System.IO;

namespace Persistence.Implementation
{
    public class UsersFiles:IUsersFiles
    {
        private readonly Func<string> _getPath;
        private readonly string pathUsuarios = "/Files/Users.txt";
        public UsersFiles(Func<string> getPath)
        {
            _getPath = getPath;
        }
        public StreamReader GetUsers()
        {
            var fileStream = new FileStream(_getPath() + pathUsuarios, FileMode.Open);
            var reader = new StreamReader(fileStream);
            return reader;
        }

        public async Task<bool> AddUser(User user)
        {
            try
            {
                string usuario = user.Name.ToString()+','+user.Email.ToString()+','+user.Phone.ToString()+','+user.Address.ToString()+','+user.UserType.ToString()+','+user.Money.ToString();

                using (StreamWriter sw = File.AppendText(_getPath() + pathUsuarios))
                {
                    await sw.WriteLineAsync(usuario);
                }
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error: {e.Message}");
                return false;
            }
        }
    }
}