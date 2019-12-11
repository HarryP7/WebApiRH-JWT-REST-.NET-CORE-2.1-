using System;

namespace WebApiRH.Models.ViewModel
{
    public class GroupCreateModel
    {
        public String Admin { get; set; }
        public String Title { get; set; }
        public String Home { get; set; }
        public int Status { get; set; }
        public String Image { get; set; }


        public static explicit operator LocalGroup(GroupCreateModel m)
        {
            return new LocalGroup()
            {
                Uid = Guid.NewGuid().ToString("D"),
                Fk_Admin = m.Admin,
                Fk_Image = m.Image,
                Title = m.Title,
                Fk_Home = m.Home,
                Fk_Status = m.Status,
                CreatedAt = DateTime.Now,
                EditedAt = DateTime.Now,
                Removed = false
            };
        }
    }
}