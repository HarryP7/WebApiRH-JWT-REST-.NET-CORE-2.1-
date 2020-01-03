using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiRH.Models
{
    public class LocalGroup
    {
        [Key]
        public String Uid { get; set; }
        [Display(Name = "Название группы"), Column(TypeName = "nvarchar(200)")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Руководитель группы"), ForeignKey(nameof(Supervisor))]
        public String Fk_Supervisor { get; set; }
        [Display(Name = "Аватар"), ForeignKey(nameof(Image))]
        public String Fk_Image { get; set; }
        [Display(Name = "Статус")]
        public int Fk_Status { get; set; }
        [Display(Name = "Дом"), ForeignKey(nameof(Home))]
        public String Fk_Home { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime EditedAt { get; set; }
        public bool Removed { get; set; }


        [InverseProperty(nameof(Participant.LocalGroup))]
        public virtual ICollection<Participant> Users { get; set; } = new HashSet<Participant>();
        [InverseProperty(nameof(Advert.LocalGroup))]
        public virtual ICollection<Advert> Adverts { get; set; } = new HashSet<Advert>();
        [InverseProperty(nameof(GroupChat.LocalGroup))]
        public virtual ICollection<GroupChat> Messages { get; set; } = new HashSet<GroupChat>();

        public virtual User Supervisor { get; set; }
        public virtual Images Image { get; set; }
        //public virtual Access Status { get; set; }
        [JsonIgnore]
        public virtual Home Home { get; set; }

    }
}