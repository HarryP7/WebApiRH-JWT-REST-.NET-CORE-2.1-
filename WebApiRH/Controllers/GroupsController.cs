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
    /// Содержит методы получения всех групп, всех групп дома, создания группы, получения всех сообщений обсуждения группы, сохранения сообщения 
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : Controller
    {
        readonly AppDbContext db;
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

        // GET api/groups/home?Fk_Home={Uid}
        [HttpGet("home")]
        public ActionResult<IEnumerable<LocalGroup>> HomeGroups([FromQuery] Guid Fk_Home)
        {
            Home home = db.Home.Include(p => p.LocalGroups).ThenInclude(p => p.Image).FirstOrDefault(p => p.Uid == Fk_Home);
            return home.LocalGroups.OrderByDescending(p => p.CreatedAt).ToList();
        }

        // POST api/groups/create
        [HttpPost("create")]
        public IActionResult Create([FromBody] GroupCreateModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            try
            {
                var group = (LocalGroup)model;
                db.LocalGroup.Add(group);
                db.SaveChanges();
                return Ok(group);
            }
            catch (Exception)
            {
                return BadRequest(new
                {
                    message = "На сервере произошла ошибка, попробуйте позже"
                });
            }
        }

        // GET api/groups/chat?Fk_Group={Uid}
        [HttpGet("chat")]
        public ActionResult<IEnumerable<GroupChat>> GroupChat([FromQuery] Guid Fk_Group)
        {
            if (Fk_Group.ToString() == "")
            {
                return BadRequest();
            }
            LocalGroup lg = db.LocalGroup.Include(p => p.Messages).ThenInclude(p => p.Author).ThenInclude(p => p.Avatar)
                .Include(p => p.Messages).ThenInclude(p => p.Image).FirstOrDefault(p => p.Uid == Fk_Group);
            if (lg == null)
            {
                return BadRequest();
            }
            return lg.Messages.OrderByDescending(p => p.CreatedAt).ToList();
        }

        // POST api/groups/saveMessage
        [HttpPost("saveMessage")]
        public IActionResult SaveMessage([FromBody] GroupChatModel model)
        {
            if (model.Fk_Author == Guid.Empty || model.Fk_Group == Guid.Empty)
            {
                return BadRequest();
            }
            try
            {
                var image = new Images();
                if (model.Image != "")
                {
                    image = (Images)model;
                    db.Images.Add(image);
                    db.SaveChanges();
                }
                var message = (GroupChat)model;
                message.Fk_Image = image != new Images() ? image.Uid : Guid.Empty;
                db.GroupChat.Add(message);
                db.SaveChanges();
                return Ok(message);
            }
            catch (Exception)
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
