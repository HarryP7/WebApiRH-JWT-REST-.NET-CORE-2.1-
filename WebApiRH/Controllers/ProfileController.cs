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
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        AppDbContext db;
        public ProfileController(AppDbContext db)
        {
            this.db = db;
        }

        // GET api/profile
        [HttpGet]
        public ActionResult<IEnumerable<Home>> Get()
        {
            return db.Home.Include(p => p.ImageUrl).Include(p => p.Admin).Include(p => p.LocalGroups).Include(p => p.Tenants).ToList();
        }

        [Authorize]
        // POST api/profile
        [HttpPost("my")]
        public IActionResult MyHome([FromBody] MyHomeModel m)
        {            
            Home home = db.Home.Include(p => p.ImageUrl).Include(p => p.Admin).Include(p => p.LocalGroups).Include(p => p.Tenants).FirstOrDefault(x => x.Uid == m.Uid);
            if (home == null)
                return NotFound();
            return new ObjectResult(home);
        }
                
        // PUT api/profile/5
        [HttpPut("{id}")]
        public IActionResult Put(String Uid, [FromBody] HomeCreateModel model)
        {
            try
            {
                //var Home = (HomeCreateModel)model;
                //Home.Fk_user = int.Parse(User.Identity.Name);
                //Home.Service.DatePlace = DateTime.Now;

                db.Home.Add((Home)model);
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

        // DELETE api/profile/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
