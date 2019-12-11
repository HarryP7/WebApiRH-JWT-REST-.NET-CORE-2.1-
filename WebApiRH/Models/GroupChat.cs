using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiRH.Models
{
    public class GroupChat
    {
        [Key]
        public String Uid { get; set; }
        [Display(Name = "Автор"), ForeignKey(nameof(Author))]
        public String FK_Author { get; set; }
        [Required]
        [Display(Name = "Сообщение"), Column(TypeName = "nvarchar(MAX)")]
        public string Message { get; set; }
        [Display(Name = "Локальная группа"), ForeignKey(nameof(LocalGroup))]
        public String Fk_LocalGroup { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime EditedAt { get; set; }
        public bool Removed { get; set; }

        public virtual LocalGroup LocalGroup { get; set; }
        public virtual User Author { get; set; }
    }
}