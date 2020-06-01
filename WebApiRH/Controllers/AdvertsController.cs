using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiRH.Models;
using WebApiRH.Models.ViewModel;

namespace WebApiRH.Controllers
{
    /// <summary>
    /// Содержит методы получения всех объявлений, одного объявления, создания объявления, отправка голосования и отзыва 
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertsController : Controller
    {
        readonly AppDbContext db;
        public AdvertsController(AppDbContext db)
        {
            this.db = db;
        }

        // GET api/adverts?Fk_Group=
        [HttpGet]
        public IEnumerable<Advert> Get([FromQuery] Guid Fk_Group)
        {
            LocalGroup lg = db.LocalGroup.Include(p => p.Adverts).ThenInclude(a => a.Votings).FirstOrDefault(p => p.Uid == Fk_Group);
            return lg.Adverts.OrderByDescending(p => p.CreatedAt).ToList().Take(50);
        }
        // GET api/adverts/list?Fk_Home=
        [HttpGet("list")]
        public IEnumerable<LocalGroup> AdvertList([FromQuery] Guid Fk_Home)
        {
            Home home = db.Home.Include(h => h.LocalGroups).ThenInclude(l => l.Adverts).ThenInclude(a => a.Votings).FirstOrDefault(h => h.Uid == Fk_Home);
            return home.LocalGroups.ToList().Take(50);
        }

        // GET api/adverts/profile?Uid={Uid}
        [HttpGet("profile")]
        public IActionResult Advert([FromQuery] Guid Uid)
        {
            Advert adv = db.Advert.Include(p => p.Votings).ThenInclude(p => p.Voteds).
                                    Include(p => p.Votings).ThenInclude(p => p.Options).
                                    Include(p => p.Author).ThenInclude(p => p.Avatar).
                                    Include(p => p.Reviews).ThenInclude(p => p.Author).ThenInclude(p => p.Avatar).FirstOrDefault(x => x.Uid == Uid);
            if (adv == null) return NotFound();
            var vot = adv.Votings.OrderByDescending(p => p.CreatedAt).ToList();
            var rev = adv.Reviews.OrderBy(p => p.CreatedAt).ToList();
            return Ok(new
            {
                advert = adv,
                voting = vot,
                reviews = rev
            });
        }

        // POST api/adverts
        [HttpPost("create")]
        public IActionResult Create([FromBody] AdvertCreateModel model)
        {
            try
            {
                if (model == null)
                    return BadRequest();

                var advert = (Advert)model;
                db.Advert.Add(advert);
                db.SaveChanges();

                foreach (var elV in model.Voting)
                {
                    var voting = (Voting)elV;
                    voting.Fk_Advert = advert.Uid;
                    db.Voting.Add(voting);
                    db.SaveChanges();

                    //
                    foreach (var elO in elV.Options)
                    {
                        var option = (Answer)elO;
                        option.Fk_Voting = voting.Uid;
                        db.Answer.Add(option);
                        db.SaveChanges();
                    }
                }

                return Ok(advert);
            }
            catch (Exception)
            {
                return BadRequest(new
                {
                    message = "На сервере произошла ошибка, попробуйте позже"
                });
            }
        }

        //POST api/adverts/vote
        [HttpPost("vote")]
        public IActionResult Vote([FromBody] VotedModel model, [FromQuery] Guid Fk_Option)
        {
            var option = db.Answer.FirstOrDefault(x => x.Uid == Fk_Option);
            var voting = db.Voting.FirstOrDefault(x => x.Uid == model.Fk_Voting);
            if (option == null || voting == null)
            {
                return BadRequest();
            }
            try
            {
                option.Count += 1;
                db.Answer.Update(option);
                db.SaveChanges();

                voting.TotalVotes += 1;
                voting.YourOption = model.YourOption;
                db.Voting.Update(voting);
                db.SaveChanges();

                var voted = (Voted)model;
                db.Voted.Add(voted);
                db.SaveChanges();
                return Ok(voting);
            }
            catch (Exception)
            {
                return BadRequest(new
                {
                    message = "На сервере произошла ошибка, попробуйте позже"
                });
            }
        }
        //POST api/adverts/review
        [HttpPost("review")]
        public IActionResult Review([FromBody] ReviewModel model)
        {
            var advert = db.Advert.FirstOrDefault(x => x.Uid == model.Fk_Advert);
            if (advert == null)
            {
                return BadRequest();
            }
            try
            {
                var advertsReview = (AdvertsReview)model;
                db.AdvertsReview.Add(advertsReview);
                db.SaveChanges();
                return Ok(advertsReview);

            }
            catch (Exception)
            {
                return BadRequest(new
                {
                    message = "На сервере произошла ошибка, попробуйте позже"
                });
            }
        }

        // PUT api/adverts/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/adverts/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
