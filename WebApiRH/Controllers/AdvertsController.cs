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
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertsController : Controller
    {

        const string admin = "1";

        AppDbContext db;
        public AdvertsController(AppDbContext db)
        {
            this.db = db;
        }

        // GET api/adverts
        [HttpGet]
        public IEnumerable<Advert> Get([FromQuery] String Fk_Group)
        {
            return db.Advert.ToList().Where(x => x.Fk_LocalGroup == Fk_Group);
        }

        // GET api/adverts/view?Uid={Uid}
        [HttpGet("view")]
        public IActionResult Advert([FromQuery] String Uid)
        {
            Advert adv = db.Advert.Include(p => p.Image).Include(p => p.Votings).Include(p => p.Author).Include(p => p.Reviews).FirstOrDefault(x => x.Uid == Uid);
            if (adv == null)
                return NotFound();
            return new ObjectResult(adv);
        }
        [Authorize(Roles = admin)]
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
