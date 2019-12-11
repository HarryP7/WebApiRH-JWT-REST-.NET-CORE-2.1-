using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiRH.Models
{
    /// <summary>
    /// Дом
    /// </summary>
    public class Home
    {
        [Key]
        public String Uid { get; set; }
        [Display(Name = "Управляющий"), ForeignKey(nameof(Admin))]
        public String FK_Admin { get; set; }
        [Display(Name = "Аватар Url"), ForeignKey(nameof(ImageUrl))]
        public String Fk_ImageUrl { get; set; }
        [Required]
        [Display(Name = "Адрес"), Column(TypeName = "nvarchar(200)")]
        public String Location { get; set; }
        [Required]
        [Display(Name = "Статус дома")]
        public int Fk_Status { get; set; }
        /// <summary>
        /// Количество квартир
        /// </summary>
        public int Appartaments { get; set; }
        /// <summary>
        /// Количество этажей
        /// </summary>
        public int Floors { get; set; }
        /// <summary>
        /// Количество подьездов
        /// </summary>
        public int Porches { get; set; }
        /// <summary>
        /// Год введения в эксплуатацию
        /// </summary>
        public String YearCommissioning { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime EditedAt { get; set; }
        public bool Removed { get; set; }


        /// <summary>
        /// Жители
        /// </summary>
        [InverseProperty(nameof(User.Home))]
        public virtual ICollection<User> Tenants { get; set; } = new HashSet<User>();
        [InverseProperty(nameof(LocalGroup.Home))]
        public virtual ICollection<LocalGroup> LocalGroups { get; set; } = new HashSet<LocalGroup>();

        public virtual User Admin { get; set; }
        public virtual Images ImageUrl { get; set; }
        //public virtual HomeStatus Status { get; set; }
    }
}