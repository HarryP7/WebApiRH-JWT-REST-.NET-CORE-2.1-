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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertsController : Controller
    {
        AppDbContext db;
        public AdvertsController(AppDbContext db)
        {
            this.db = db;
        }

        // GET api/adverts
        [HttpGet]
        public IEnumerable<Advert> Get([FromQuery] String Fk_Group)
        {
            return db.Advert.Include(p => p.Votings).Where(x => x.Fk_LocalGroup == Fk_Group).OrderByDescending(p => p.CreatedAt).ToList();
        }

        // GET api/adverts/profile?Uid={Uid}
        [HttpGet("profile")]
        public IActionResult Advert([FromQuery] String Uid)
        {
            var adv = db.Advert.Include(p => p.Votings).Include(p => p.Author).Include(p => p.Reviews).FirstOrDefault(x => x.Uid == Uid);
            var vot = db.Voting.Include(p => p.Options).Include(p => p.Voteds).Where(x => x.Fk_Advert == adv.Uid).OrderByDescending(p => p.CreatedAt).ToList();
            if (adv == null)
                return NotFound();
            return Ok(new
            {
                advert = adv,
                voting = vot
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
            catch (Exception e)
            {
                return BadRequest(new
                {
                    message = "На сервере произошла ошибка, попробуйте позже"
                });
            }
        }

        //PUT api/adverts/vote
        [HttpPut("vote")]
        public IActionResult Put([FromBody] VotedModel model, [FromQuery] String Fk_Option)
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
                voting.yourOption = model.yourOption;
                db.Voting.Update(voting);
                db.SaveChanges();

                var voted = (Voted)model;
                db.Voted.Add(voted);
                db.SaveChanges();
                return Ok(voting);
            }
            catch (Exception e)
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
