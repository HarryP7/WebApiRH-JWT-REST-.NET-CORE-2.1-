using System;
using System.Collections.Generic;

namespace WebApiRH.Models.ViewModel
{
    public class VotingCreateModel
    {
        public string Title { get; set; }
        public ICollection<AnswerCreateModel> Options { get; set; }
        public bool IsMulti { get; set; }
        public Guid Fk_Advert { get; set; }
        public DateTime CreatedAt = DateTime.Now;

        public static explicit operator Voting(VotingCreateModel m)
        {
            return new Voting()
            {
                Uid = Guid.NewGuid(),
                Title = m.Title,
                IsMulti = m.IsMulti,
                Fk_Advert = m.Fk_Advert,
                TotalVotes = 0,
                CreatedAt = m.CreatedAt,
                EditedAt = m.CreatedAt,
            };
        }
    }
}