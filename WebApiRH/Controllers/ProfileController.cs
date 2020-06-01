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
    /// Содержит методы получения всех профилей, одного профиля, жителей дома, поиска профиля по имени, утвреждения профиля в доме, обновления профиля, загрузки картинки 
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        readonly AppDbContext db;
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
        public IActionResult Profile([FromQuery] Guid Uid)
        {            
            User user = db.User.Include(p => p.Avatar).FirstOrDefault(x => x.Uid == Uid);
            if (user == null)
                return NotFound();
            return new ObjectResult(user);
        }

        // GET api/profile/tentants?Fk_Home={Fk_Home}
        [HttpGet("tentants")]
        public IActionResult Tentants([FromQuery] Guid Fk_Home)
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
        public IActionResult Approve([FromQuery] Guid Uid)
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
                Home home = db.Home.Include(p => p.Tenants).ThenInclude(p => p.Avatar).FirstOrDefault(p => p.Uid == user.Fk_Home);
                var approvedTantains = home.Tenants.Where(x => x.IsApprovedHome == true).OrderByDescending(p => p.CreatedAt).ToList();
                var newTantns = home.Tenants.Where(x => x.IsApprovedHome == false).OrderByDescending(p => p.CreatedAt).ToList();
                return Ok(new
                {
                    tantains = approvedTantains,
                    newTantains = newTantns
                });
            }
            catch (Exception)
            {
                return BadRequest(new
                {
                    message = "На сервере произошла ошибка, попробуйте позже"
                });
            }
        }

        //PUT api/profile/upd?Uid={Uid}
        [HttpPut("upd")]
        public IActionResult Put([FromQuery] Guid Uid, [FromBody] EditUserModel model)
        {
            try
            {
                var user = db.User.Include(p => p.Avatar).FirstOrDefault(x => x.Uid == Uid);
                if (user == null)
                {
                    return BadRequest();
                }
                user.Login = model.Login;
                user.Email = model.Email;
                user.FullName = model.FullName;
                user.Phone = model.Phone;
                db.User.Update(user);
                db.SaveChanges();
                return Ok(user);
            }
            catch (Exception)
            {
                return BadRequest(new
                {
                    message = "На сервере произошла ошибка, попробуйте позже"
                });
            }
        }

        //PUT api/profile/loadImage?Uid={Uid}
        [HttpPut("loadImage")]
        public IActionResult LoadImage([FromQuery] Guid Uid, [FromBody] LoadImageModel model)
        {
            try
            {
                var user = db.User.Include(p => p.Avatar).FirstOrDefault(x => x.Uid == Uid);
                if (user == null) {
                    return BadRequest();
                }
                if (user.Fk_Avatar != null) {
                    var image = (Images)model;
                    image.Uid = user.Avatar.Uid;
                    db.Images.Update(image);
                }
                else {
                    var image = (Images)model;
                    db.Images.Add(image);
                    user.Fk_Avatar = image.Uid;
                    db.User.Update(user);
                }
                db.SaveChanges();
                return Ok(user);
            }
            catch (Exception)
            {
                return BadRequest(new
                {
                    message = "На сервере произошла ошибка, попробуйте позже"
                });
            }
        }
        // DELETE api/profile/5
        //    [HttpDelete("{id}")]
        //    public void Delete(int id)
        //    {
        //    }
    }
}
