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
    public class GroupsController : Controller
    {
        AppDbContext db;
        public GroupsController(AppDbContext db)
        {
            this.db = db;
        }

        // GET api/groups
        [HttpGet]
        public ActionResult<IEnumerable<LocalGroup>> Get()
        {
            return db.LocalGroup.Include(p => p.Image).Include(p => p.Users).OrderByDescending(p => p.CreatedAt).ToList();
        }

        // GET api/groups?Fk_Home={Uid}
        [HttpGet("home")]
        public ActionResult<IEnumerable<LocalGroup>> HomeGroups([FromQuery] String Fk_Home)
        {
            Home home = db.Home.Include(p => p.LocalGroups).ThenInclude(p => p.Image).FirstOrDefault(p => p.Uid == Fk_Home);
            return home.LocalGroups.OrderByDescending(p => p.CreatedAt).ToList();
        }
        
        // POST api/groups
        [HttpPost("create")]
        public IActionResult Create([FromBody] GroupCreateModel model)
        {
            try
            {
                var group = (LocalGroup)model;
                db.LocalGroup.Add(group);
                db.SaveChanges();
                return Ok(group);
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
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/groups/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
