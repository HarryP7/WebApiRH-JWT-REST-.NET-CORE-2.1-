using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiRH.Models
{
    public class Participant
    {
        [Key]
        public String Uid { get; set; }
        [Display(Name = "Участник"), ForeignKey(nameof(User))]
        public String Fk_User { get; set; }
        [Display(Name = "Локальная группа"), ForeignKey(nameof(LocalGroup))]
        public String Fk_LocalGroup { get; set; }

        public virtual User User { get; set; }
        public virtual LocalGroup LocalGroup { get; set; }
    }
}