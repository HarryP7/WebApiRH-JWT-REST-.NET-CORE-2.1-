using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiRH.Models.ViewModel
{
    public class RegisterUserViewModel
    {

        [Required(ErrorMessage = "Введите Login")]
        public String Login { get; set; }
        //[Required(ErrorMessage = "Не указан Адрес")]
        //public String Fk_Home { get; set; }
        [Required(ErrorMessage = "Введите имя пользователя"), Display(Name = "Имя")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public int Role { get; set; }

        public static explicit operator User(RegisterUserViewModel m)
        {
            return new User()
            {
                Uid = Guid.NewGuid().ToString("D"),
                Login = m.Login,
                Fk_Gender = 0,
                //Fk_Home = m.Fk_Home,
                Appartament = 0,
                FullName = m.FullName,
                Fk_Role = m.Role,
                Removed = false,
            };
        }
    }
}
