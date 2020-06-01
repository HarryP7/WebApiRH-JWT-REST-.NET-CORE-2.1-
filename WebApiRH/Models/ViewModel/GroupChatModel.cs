using System;

namespace WebApiRH.Models.ViewModel
{
    public class GroupChatModel
    {
        public Guid Fk_Author { get; set; }
        public String Message { get; set; }
        public String Image { get; set; }
        public Guid Fk_Group { get; set; }
        public DateTime CreatedAt = DateTime.Now;


        public static explicit operator GroupChat(GroupChatModel m)
        {
            return new GroupChat()
            {
                Uid = Guid.NewGuid(),
                Fk_Author = m.Fk_Author,
                Text = m.Message,
                Fk_LocalGroup = m.Fk_Group,
                CreatedAt = m.CreatedAt,
                EditedAt = m.CreatedAt,
            };
        }
        public static explicit operator Images(GroupChatModel m)
        {
            return new Images()
            {
                Uid = Guid.NewGuid(),
                Url = m.Image,
                CreatedAt = DateTime.Now,
            };
        }
    }
}