using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUsersServices
    {

        string NormalizeEmail(string email);

        bool isDuplicated(IList<User> users, User newUser);

        decimal calcularMoney(String UserType, String money);
    }
}
