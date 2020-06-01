using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiRH.Models.ViewModel
{
    public class ChangePassModel
    {
        [Required(ErrorMessage = "Не указан Email")]
        public String Email { get; set; }
        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public static explicit operator User(ChangePassModel m)
        {
            return new User()
            {
                Email = m.Email,
            };
        }
    }
}
