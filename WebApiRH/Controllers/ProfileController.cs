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
            return db.User.Include(p => p.Avatar).OrderByDescending(p => p.CreatedAt).ToList();
        }

        // GET api/profile?Uid={Uid}
        [HttpGet]
        public IActionResult Profile([FromQuery] String Uid)
        {            
            User user = db.User.Include(p => p.Avatar).Include(p => p.MyGroups).FirstOrDefault(x => x.Uid == Uid);
            if (user == null)
                return NotFound();
            return new ObjectResult(user);
        }

        // GET api/profile/tentants?Fk_Home={Fk_Home}
        [HttpGet("tentants")]
        public IActionResult Tentants([FromQuery] String Fk_Home)
        {
            var approvedTantains = db.User.Include(p => p.Avatar).Where(x => x.Fk_Home == Fk_Home && x.IsApprovedHome == true).OrderByDescending(p => p.CreatedAt).ToList();
            var newTantns = db.User.Include(p => p.Avatar).Where(x => x.Fk_Home == Fk_Home && x.IsApprovedHome == false).OrderByDescending(p => p.CreatedAt).ToList();            
            return Ok(new
            {
                tantains = approvedTantains,
                newTantains = newTantns
            });
        }

        // GET api/profile/search?Name={Name}
        [HttpGet("search")]
        public ActionResult<IEnumerable<User>> GetSearch([FromQuery] String Name)
        {
            var users = db.User.Where(p => p.FullName.Contains(Name)).OrderByDescending(p => p.CreatedAt).ToList();
            if (users == null)
                return NotFound();
            return users;
        }

        //PUT api/profile/approve?Uid={Uid}
        [HttpPut("approve")]
        public IActionResult Approve([FromQuery] String Uid)
        {
            try
            {
                var user = db.User.FirstOrDefault(x => x.Uid == Uid);
                if (user == null)
                {
                    return BadRequest();
                }
                user.IsApprovedHome = true;
                db.User.Update(user);
                db.SaveChanges();
                var approvedTantains = db.User.Include(p => p.Avatar).Where(x => x.Fk_Home == user.Fk_Home && x.IsApprovedHome == true).OrderByDescending(p => p.CreatedAt).ToList();
                var newTantns = db.User.Include(p => p.Avatar).Where(x => x.Fk_Home == user.Fk_Home && x.IsApprovedHome == false).OrderByDescending(p => p.CreatedAt).ToList();
                return Ok(new
                {
                    tantains = approvedTantains,
                    newTantains = newTantns
                });
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    message = "На сервере произошла ошибка, попробуйте позже"
                });
            }
        }

        // PUT api/profile/5
        //[HttpPut("{id}")]
        //public IActionResult Put([FromQuery] String Uid, [FromBody] HomeCreateModel model)
        //{
        //    try
        //    {
        //        db.Home.Add((Home)model);
        //        db.SaveChanges();
        //        return Ok();
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(new
        //        {
        //            message = "На сервере произошла ошибка, попробуйте позже"
        //        });
        //    }
        //}

        // DELETE api/profile/5
        //    [HttpDelete("{id}")]
        //    public void Delete(int id)
        //    {
        //    }
    }
}
