using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiRH.Models
{
    public class Advert
    {
        [Key]
        public String Uid { get; set; }
        [Display(Name = "Автор"), ForeignKey(nameof(Author))]
        public String Fk_Author { get; set; }
        [Required]
        [Display(Name = "Заголовок объявления"), Column(TypeName = "nvarchar(200)")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Текст"), Column(TypeName = "nvarchar(MAX)")]
        public string Text { get; set; }
        [Display(Name = "Картинка"), ForeignKey(nameof(Image))]
        public String Fk_Image { get; set; }
        [Display(Name = "Категория")]
        public int Fk_Category { get; set; }
        [Display(Name = "Локальная группа"), ForeignKey(nameof(LocalGroup))]
        public String Fk_LocalGroup { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime EditedAt { get; set; }
        public bool Removed { get; set; }

        [InverseProperty(nameof(Voting.Advert))]
        public virtual ICollection<Voting> Votings { get; set; } = new HashSet<Voting>();
        [InverseProperty(nameof(AdvertsReview.Advert))]
        public virtual ICollection<AdvertsReview> Reviews { get; set; } = new HashSet<AdvertsReview>();
        [JsonIgnore]
        public virtual LocalGroup LocalGroup { get; set; }
        public virtual Images Image { get; set; }
        //public virtual Category Category { get; set; }

        //public List<Evaluation> Rating { get; set; }
        public virtual User Author { get; set; }
    }
}