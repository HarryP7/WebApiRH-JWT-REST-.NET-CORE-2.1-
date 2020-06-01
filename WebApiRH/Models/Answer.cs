using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiRH.Models
{
    public class Answer
    {
        [Key]
        public Guid Uid { get; set; }
        [Display(Name = "Вариант ответа"), Column(TypeName = "nvarchar(50)")]
        public string Option { get; set; }
        [Display(Name = "Количество ответов")]
        public int Count { get; set; }
        [Display(Name = "Локальная группа"), ForeignKey(nameof(Voting))]
        public Guid Fk_Voting { get; set; }
        [JsonIgnore]
        public virtual Voting Voting { get; set; }
    }
}