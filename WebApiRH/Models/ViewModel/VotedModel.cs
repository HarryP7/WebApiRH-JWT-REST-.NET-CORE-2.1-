using System;

namespace WebApiRH.Models.ViewModel
{
    public class VotedModel
    {
        public String Fk_User { get; set; }
        public String Fk_Voting { get; set; }
        public String yourOption { get; set; }
        public static explicit operator Voted(VotedModel m)
        {
            return new Voted()
            {
                Uid = Guid.NewGuid().ToString("D"),
                Fk_User = m.Fk_User,
                Fk_Voting = m.Fk_Voting
            };
        }
    }
}