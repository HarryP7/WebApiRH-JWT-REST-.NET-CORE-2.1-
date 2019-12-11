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
    public class HomeController : ControllerBase
    {
        AppDbContext db;
        public HomeController(AppDbContext db)
        {
            this.db = db;
        }

        // GET api/home
        [HttpGet]
        public ActionResult<IEnumerable<Home>> Get()
        {
            return db.Home.Include(p => p.ImageUrl).Include(p => p.Admin).Include(p => p.LocalGroups).Include(p => p.Tenants).ToList();
        }

        [Authorize]
        // POST api/home
        [HttpPost("my")]
        public IActionResult MyHome([FromBody] MyHomeModel m)
        {            
            Home home = db.Home.Include(p => p.ImageUrl).Include(p => p.Admin).Include(p => p.LocalGroups).Include(p => p.Tenants).FirstOrDefault(x => x.Uid == m.Uid);
            if (home == null)
                return NotFound();
            return new ObjectResult(home);
        }

        // POST api/home
        [HttpPost("create")]
        public IActionResult Create([FromBody] HomeCreateModel model)
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

        // PUT api/groups/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/groups/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
