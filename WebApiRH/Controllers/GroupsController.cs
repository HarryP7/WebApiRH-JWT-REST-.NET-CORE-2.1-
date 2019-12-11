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
            return db.LocalGroup.Include(p => p.Image).Include(p => p.Users).ToList();//.Include(p => p.Home)
        }

        // GET api/groups/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(string uid)
        {
            LocalGroup lg = db.LocalGroup.Include(p => p.Image).Include(p => p.Admin).Include(p => p.Adverts).FirstOrDefault(x => x.Uid == uid);
            if (lg == null)
                return NotFound();
            return new ObjectResult(lg);
        }

        // POST api/groups
        [HttpPost("create")]
        public IActionResult Create([FromBody] GroupCreateModel model)
        {
            try
            {
                //var LocalGroup = (LocalGroup)model;
                //LocalGroup.Fk_user = int.Parse(User.Identity.Name);
                //LocalGroup.Service.DatePlace = DateTime.Now;

                db.LocalGroup.Add((LocalGroup)model);
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
