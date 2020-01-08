using System;
using System.Collections.Generic;

namespace WebApiRH.Models.ViewModel
{
    public class VotingCreateModel
    {
        public string Title { get; set; }
        public ICollection<AnswerCreateModel> Options { get; set; }
        public bool isMulti { get; set; }
        public String Fk_Advert { get; set; }

        public static explicit operator Voting(VotingCreateModel m)
        {
            return new Voting()
            {
                Uid = Guid.NewGuid().ToString("D"),
                Title = m.Title,
                isMulti = m.isMulti,
                Fk_Advert = m.Fk_Advert,
                TotalVotes = 0,
                CreatedAt = DateTime.Now,
                EditedAt = DateTime.Now,
                Removed = false
            };
        }
    }
}