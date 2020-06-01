using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiRH.Models.ViewModel
{
    public class EditUserModel
    {
        public String Login { get; set; }
        public String Email { get; set; }
        public String FullName { get; set; }
        public String Phone { get; set; }

        public static explicit operator User(EditUserModel m)
        {
            return new User()
            {
                Login = m.Login,
                Email = m.Email,
                FullName = m.FullName,
                Phone = m.Phone,
            };
        }
    }
}
