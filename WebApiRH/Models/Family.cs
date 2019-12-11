//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace WebApiRH.Models
//{
//    public class Family
//    {
//        [Key]
//        public string Uid { get; set; }
//        [Column(TypeName = "varchar(50)")]
//        public string Surname { get; set; }
//        public List<User> Members { get; set; }
//        public List<string> ImageUrl { get; set; }
//        public DateTime CreateAt { get; set; }
//        public bool Removed { get; set; }

//    }
//}