using System;

namespace WebApiRH.Models.ViewModel
{
    public class AddAdressModel
    {
        public Guid Fk_User { get; set; }
        public Guid Fk_Home { get; set; }
        public int Appartment { get; set; }
        public String Address { get; set; }
    }
}