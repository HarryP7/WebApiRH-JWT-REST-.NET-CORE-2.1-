using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiRH.Models
{
    public class Answer
    {
        [Key]
        public String Uid { get; set; }
        [Display(Name = "Вариант ответа"), Column(TypeName = "nvarchar(50)")]
        public string Option { get; set; }
        [Display(Name = "Количество ответов")]
        public int Count { get; set; }
        [Display(Name = "Локальная группа"), ForeignKey(nameof(Voting))]
        public String Fk_Voting { get; set; }

        public virtual Voting Voting { get; set; }
    }
}