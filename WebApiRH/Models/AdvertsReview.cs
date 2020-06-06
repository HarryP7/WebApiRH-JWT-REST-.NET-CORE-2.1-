using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiRH.Models
{
    public class AdvertsReview
    {
        [Key]
        public Guid Uid { get; set; }
        [Display(Name = "Автор"), ForeignKey(nameof(Author))]
        public Guid Fk_Author { get; set; }
        [Required]
        [Display(Name = "Отзыв"), Column(TypeName = "nvarchar(MAX)")]
        public string Reviews { get; set; }
        [Display(Name = "Объявление"), ForeignKey(nameof(Advert))]
        public Guid Fk_Advert { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime EditedAt { get; set; }
        public bool Removed { get; set; }

        public virtual User Author { get; set; }
        [JsonIgnore]
        public virtual Advert Advert { get; set; }
    }
}