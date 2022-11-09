using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Implementation
{
    public class UsersServices:IUsersServices
    {
        public string NormalizeEmail(string email)
        {
            //Normalize email
            var aux = email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);

            var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);

            aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);

            return string.Join("@", new string[] { aux[0], aux[1] });
        }

        public bool isDuplicated( IList<User> users , User newUser)
        {
            return users.Any(u => (u.Email == newUser.Email || u.Phone == newUser.Phone) ||
                          (u.Name == newUser.Name && u.Address == newUser.Address));
        }

        public decimal calcularMoney(String UserType, String money)
        {
            decimal moneyResult = decimal.Parse(money);
            if (UserType == "Normal")
            {
                if (decimal.Parse(money) > 100)
                {
                    var percentage = Convert.ToDecimal(0.12);
                    //If new user is normal and has more than USD100
                    var gif = decimal.Parse(money) * percentage;
                    moneyResult = moneyResult + gif;
                }
                if (decimal.Parse(money) < 100)
                {
                    if (decimal.Parse(money) > 10)
                    {
                        var percentage = Convert.ToDecimal(0.8);
                        var gif = decimal.Parse(money) * percentage;
                        moneyResult = moneyResult + gif;
                    }
                }
            }
            if (UserType == "SuperUser")
            {
                if (decimal.Parse(money) > 100)
                {
                    var percentage = Convert.ToDecimal(0.20);
                    var gif = decimal.Parse(money) * percentage;
                    moneyResult = moneyResult + gif;
                }
            }

            if (UserType == "Premium")
            {
                if (decimal.Parse(money) > 100)
                {
                    var gif = decimal.Parse(money) * 2;
                    moneyResult = moneyResult + gif;
                }
            }

            return moneyResult;
        }
    }
}
