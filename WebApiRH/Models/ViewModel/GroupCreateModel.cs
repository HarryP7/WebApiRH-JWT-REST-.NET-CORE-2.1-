using System;

namespace WebApiRH.Models.ViewModel
{
    public class GroupCreateModel
    {
        public Guid Supervisor { get; set; }
        public String Title { get; set; }
        public Guid Home { get; set; }
        public int Status { get; set; }
        public Guid Image { get; set; }
        public DateTime CreatedAt = DateTime.Now;


        public static explicit operator LocalGroup(GroupCreateModel m)
        {
            return new LocalGroup()
            {
                Uid = Guid.NewGuid(),
                Fk_Supervisor = m.Supervisor,
                Fk_Image = m.Image,
                Title = m.Title,
                Fk_Home = m.Home,
                Fk_Status = m.Status,
                CreatedAt = m.CreatedAt,
                EditedAt = m.CreatedAt,
                Removed = false
            };
        }
    }
}