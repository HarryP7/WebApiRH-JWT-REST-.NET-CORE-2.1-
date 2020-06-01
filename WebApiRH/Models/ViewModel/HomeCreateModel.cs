using System;

namespace WebApiRH.Models.ViewModel
{
    public class HomeCreateModel
    {
        public Guid Manager { get; set; }
        public String City { get; set; }
        public String Street { get; set; }
        public String HomeNumber { get; set; }
        public int Appartaments { get; set; }
        public int Floors { get; set; }
        public int Porches { get; set; }
        public String Year { get; set; }
        public int Status { get; set; }
        public Guid Image { get; set; }
        public int Fk_Role { get; set; }
        public DateTime CreatedAt = DateTime.Now;

        public static explicit operator Home(HomeCreateModel m)
        {
            return new Home()
            {
                Uid = Guid.NewGuid(),
                Fk_Manager = m.Manager,
                Fk_ImageUrl = m.Image,
                City = m.City,
                Street = m.Street,
                HomeNumber = m.HomeNumber,
                Appartaments = m.Appartaments,
                Floors = m.Floors,
                Porches = m.Porches,
                YearCommissioning = m.Year,
                Fk_Status = m.Status,
                CreatedAt = m.CreatedAt,
                EditedAt = m.CreatedAt,
                Removed = false
            };
        }
    }
}