using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiRH.Models
{
    public class ChatReply
    {
        [Key]
        public Guid Uid { get; set; }
        [Required]
        [Display(Name = "Автор"), ForeignKey(nameof(Author))]
        public Guid FK_Author { get; set; }
        [Required]
        [Display(Name = "Ответ"), Column(TypeName = "nvarchar(MAX)")]
        public string Reply { get; set; }
        [Required]
        [Display(Name = "Сообщение чата группы"), ForeignKey(nameof(GroupChat))]
        public Guid Fk_GroupChat { get; set; }
        [Display(Name = "Картинка"), ForeignKey(nameof(Image))]
        public Nullable<Guid> Fk_Image { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime EditedAt { get; set; }
        public bool Removed { get; set; }

        [JsonIgnore]
        public virtual GroupChat GroupChat { get; set; }
        public virtual User Author { get; set; }
        public virtual Images Image { get; set; }
    }
}