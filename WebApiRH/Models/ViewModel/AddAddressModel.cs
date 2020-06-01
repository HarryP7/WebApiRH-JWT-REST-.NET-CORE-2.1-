using System;

namespace WebApiRH.Models.ViewModel
{
    public class AddAdressModel
    {
        public String Fk_User { get; set; }
        public String Fk_Home { get; set; }
        public int Appartment { get; set; }
        public String Address { get; set; }        
    }
}