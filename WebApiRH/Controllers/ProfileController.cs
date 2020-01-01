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
    public class ProfileController : ControllerBase
    {
        AppDbContext db;
        public ProfileController(AppDbContext db)
        {
            this.db = db;
        }

        // GET api/profile
        [HttpGet("all")]
        public ActionResult<IEnumerable<User>> Get()
        {
            return db.User.Include(p => p.Avatar).ToList();
        }

        // POST api/profile?Uid={Uid}
        [HttpGet]
        public IActionResult Profile([FromQuery] String Uid)
        {            
            User user = db.User.Include(p => p.Avatar).Include(p => p.MyGroups).FirstOrDefault(x => x.Uid == Uid);
            if (user == null)
                return NotFound();
            return new ObjectResult(user);
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
