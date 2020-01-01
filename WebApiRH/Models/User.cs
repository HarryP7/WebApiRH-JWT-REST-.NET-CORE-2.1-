using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiRH.Models
{
    public class User
    {
        [Key]
        public String Uid { get; set; }
        [Required]
        [Display(Name = "Имя пользователя"), Column(TypeName = "Nvarchar(100)")]
        public String FullName { get; set; }
        [Display(Name = "Пол")]
        public int? Fk_Gender { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(30)")]
        public String Login { get; set; }
        [Display(Name = "Email"), Column(TypeName = "varchar(50)")]
        public String Email { get; set; }
        [Display(Name = "Телефон"), Column(TypeName = "varchar(15)")]
        public String Phone { get; set; }
        [Display(Name = "Аватар"), ForeignKey(nameof(Avatar))]
        public String Fk_Avatar { get; set; }
        public int Appartament { get; set; }
        [Display(Name = "Роль")]
        public int Fk_Role { get; set; }
        [Display(Name = "Дом"), ForeignKey(nameof(Home))]
        public String Fk_Home { get; set; }
        [Column(TypeName = "Nvarchar(MAX)")]
        public String Address { get; set; }
        [JsonIgnore]
        public byte[] PasswordHash { get; set; }
        [JsonIgnore]
        public byte[] PasswordSalt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime EditedAt { get; set; }
        public bool Removed { get; set; }


        //public List<Dialogue> Dialogue { get; set; }
        [InverseProperty(nameof(Participant.User))]
        public virtual ICollection<Participant> MyGroups { get; set; } = new HashSet<Participant>();
        [JsonIgnore]
        [InverseProperty(nameof(LocalGroup.Admin))]
        public virtual ICollection<LocalGroup> ManagedGroups { get; set; } = new HashSet<LocalGroup>();

        //public virtual Gender Gender { get; set; }
        public virtual Images Avatar { get; set; }
        //public virtual Role Role { get; set; }
        [JsonIgnore]
        public virtual Home Home { get; set; }
    }
}
