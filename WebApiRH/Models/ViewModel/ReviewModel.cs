using System;

namespace WebApiRH.Models.ViewModel
{
    public class ReviewModel
    {
        public Guid Fk_Author { get; set; }
        public string Reviews { get; set; }
        public Guid Fk_Advert { get; set; }
        public DateTime CreatedAt = DateTime.Now;

        public static explicit operator AdvertsReview(ReviewModel m)
        {
            return new AdvertsReview()
            {
                Uid = Guid.NewGuid(),
                Fk_Author = m.Fk_Author,
                Reviews = m.Reviews,
                Fk_Advert = m.Fk_Advert,
                CreatedAt = m.CreatedAt,
                EditedAt = m.CreatedAt,
            };
        }
    }
}