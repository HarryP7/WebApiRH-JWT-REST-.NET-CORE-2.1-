using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiRH.Models;
using WebApiRH.Models.ViewModel;

namespace WebApiRH.Controllers
{
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
        public ActionResult<IEnumerable<Advert>> Get()
        {
            return db.Advert.Include(p => p.Image).Include(p => p.Votings).Include(p => p.Author).Include(p => p.Reviews).ToList();
        }

        // GET api/adverts/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(string uid)
        {
            Advert adv = db.Advert.Include(p => p.Image).Include(p => p.Votings).Include(p => p.Author).Include(p => p.Reviews).FirstOrDefault(x => x.Uid == uid);
            if (adv == null)
                return NotFound();
            return new ObjectResult(adv);
        }

        // POST api/adverts
        [HttpPost("create")]
        public IActionResult Create([FromBody] AdvertCreateModel model)
        {
            try
            {
                //var Advert = (Advert)model;
                //Advert.Fk_user = int.Parse(User.Identity.Name);
                //Advert.Service.DatePlace = DateTime.Now;

                db.Advert.Add((Advert)model);
                db.SaveChanges();
                return Ok();
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
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/adverts/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
