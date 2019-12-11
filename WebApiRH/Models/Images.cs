using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiRH.Models
{
    public class Images
    {
        [Key]
        public String Uid { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string Url { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Removed { get; set; }
    }
}