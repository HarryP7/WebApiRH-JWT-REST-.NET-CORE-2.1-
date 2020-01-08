using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiRH.Models
{
    public class Voted
    {
        [Key]
        public String Uid { get; set; }
        [Required]
        [Display(Name = "Пользователь"), ForeignKey(nameof(User))]
        public String Fk_User { get; set; }
        [Required]
        [Display(Name = "Голосование"), ForeignKey(nameof(Voting))]
        public String Fk_Voting { get; set; }


        [JsonIgnore]
        public virtual Voting Voting { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
    }
}