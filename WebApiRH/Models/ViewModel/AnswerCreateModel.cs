using System;

namespace WebApiRH.Models.ViewModel
{
    public class AnswerCreateModel
    {
        public string Option { get; set; }
        public String Fk_Voting { get; set; }

        public static explicit operator Answer(AnswerCreateModel m)
        {
            return new Answer()
            {
                Uid = Guid.NewGuid().ToString("D"),
                Option = m.Option,
                Count = 0,
                Fk_Voting = m.Fk_Voting
            };
        }
    }
}