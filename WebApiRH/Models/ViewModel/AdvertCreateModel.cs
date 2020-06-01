using System;
using System.Collections.Generic;

namespace WebApiRH.Models.ViewModel
{
    public class AdvertCreateModel
    {
        public Guid Author { get; set; }
        public String Title { get; set; }
        public String Text { get; set; }
        public int Category { get; set; }
        public Guid LocalGroup { get; set; }
        public ICollection<VotingCreateModel> Voting { get; set; }
        public DateTime CreatedAt = DateTime.Now;

        public static explicit operator Advert(AdvertCreateModel m)
        {
            return new Advert()
            {
                Uid = Guid.NewGuid(),
                Fk_Author = m.Author,
                Title = m.Title,
                Text = m.Text,
                Fk_Category = m.Category,
                Fk_LocalGroup = m.LocalGroup,
                CreatedAt = m.CreatedAt,
                EditedAt = m.CreatedAt,
                Removed = false
            };
        }
    }
}