using System;

namespace WebApiRH.Models.ViewModel
{
    public class AdvertCreateModel
    {
        public String Author { get; set; }
        public String Title { get; set; }
        public String Text { get; set; }
        public int Category { get; set; }
        public String LocalGroup { get; set; }

        public static explicit operator Advert(AdvertCreateModel m)
        {
            return new Advert()
            {
                Uid = Guid.NewGuid().ToString("D"),
                Fk_Author = m.Author,
                Title = m.Title,
                Text = m.Text,
                Fk_Category = m.Category,
                Fk_LocalGroup = m.LocalGroup,
                CreatedAt = DateTime.Now,
                EditedAt = DateTime.Now,
                Removed = false
            };
        }
    }
}