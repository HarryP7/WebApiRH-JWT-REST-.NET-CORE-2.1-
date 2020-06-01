using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiRH.Models
{
    public class Participant
    {
        [Key]
        public Guid Uid { get; set; }
        [Display(Name = "Участник"), ForeignKey(nameof(User))]
        public Guid Fk_User { get; set; }
        [Display(Name = "Локальная группа"), ForeignKey(nameof(LocalGroup))]
        public Guid Fk_LocalGroup { get; set; }

        public virtual User User { get; set; }
        public virtual LocalGroup LocalGroup { get; set; }
    }
}