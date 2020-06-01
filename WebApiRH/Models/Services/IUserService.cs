using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace WebApiRH.Models.Services
{
    public interface IUserService
    {
        User Authenticate(string login, string password);
        IEnumerable<User> Fetch(Expression<Func<User, bool>> predicate);
        User Get(String id);
        User Get(Func<User, bool> predicate);
        User Create(User user, string password);
        void Update(User user, String Fk_Home, int Appartment, String Address);
        void UpdateAuth(User user, string password = null);
        void Delete(String id);
    }
}
