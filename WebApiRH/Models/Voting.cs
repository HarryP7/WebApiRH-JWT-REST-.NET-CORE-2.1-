using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiRH.Models
{
    public class Voting
    {
        [Key]
        public String Uid { get; set; }
        [Required]
        [Display(Name = "Вопрос"), Column(TypeName = "nvarchar(200)")]
        public string Title { get; set; }
        [Display(Name = "Свой вариант"), Column(TypeName = "nvarchar(50)")]
        public string yourOption { get; set; }
        [Display(Name = "Многовариантное голосование")]
        public bool isMulti { get; set; }
        [Display(Name = "Локальная группа"), ForeignKey(nameof(Advert))]
        public String Fk_Advert { get; set; }
        [Display(Name = "Общее число голосов")]
        public int TotalVotes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime EditedAt { get; set; }
        public bool Removed { get; set; }


        [InverseProperty(nameof(Answer.Voting))]
        public virtual ICollection<Answer> Options { get; set; } = new HashSet<Answer>();
        [InverseProperty(nameof(Voted.Voting))]
        public virtual ICollection<Voted> Voteds { get; set; } = new HashSet<Voted>();
        [JsonIgnore]
        public virtual Advert Advert { get; set; }
    }
}