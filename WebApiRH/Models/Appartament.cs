//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace WebApiRH.Models
//{
//    public class Appartament
//    {

//        [Key]
//        public String Uid { get; set; }
//        [Display(Name = "Номер квартиры"), Column(TypeName = "varchar(5)")]
//        public string Number { get; set; }
//        public int Floor { get; set; } 
//        public List<User> Members { get; set; }
//        public List<string> ImageUrl { get; set; }
//        public DateTime CreateAt { get; set; }
//        public bool Removed { get; set; }

//    }
//}