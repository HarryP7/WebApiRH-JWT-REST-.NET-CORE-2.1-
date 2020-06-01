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
        public Guid Uid { get; set; }
        [Required]
        [Display(Name = "Пользователь"), ForeignKey(nameof(User))]
        public Guid Fk_User { get; set; }
        [Required]
        [Display(Name = "Голосование"), ForeignKey(nameof(Voting))]
        public Guid Fk_Voting { get; set; }
        [Display(Name = "Ответ"), ForeignKey(nameof(Answer))]
        public Guid Fk_Answer { get; set; }


        [JsonIgnore]
        public virtual Voting Voting { get; set; }
        [JsonIgnore]
        public virtual Answer Answer { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
    }
}