using System;

namespace WebApiRH.Models.ViewModel
{
    public class VotedModel
    {
        public Guid Fk_User { get; set; }
        public Guid Fk_Voting { get; set; }
        public String YourOption { get; set; }
        public Guid Fk_Answer { get; set; }
        public static explicit operator Voted(VotedModel m)
        {
            return new Voted()
            {
                Uid = Guid.NewGuid(),
                Fk_User = m.Fk_User,
                Fk_Voting = m.Fk_Voting,
                Fk_Answer = m.Fk_Answer,
                DateAt = DateTime.Now
            };
        }
    }
}