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
    public class HomeController : ControllerBase
    {
        const string admin = "1";
        AppDbContext db;
        public HomeController(AppDbContext db)
        {
            this.db = db;
        }

        // GET api/home/all
        [AllowAnonymous]
        [HttpGet("all")]
        public ActionResult<IEnumerable<Home>> Get()
        {
            return db.Home.Include(p => p.ImageUrl).ToList();
        }

        // POST api/home/search
        [HttpPost("search")]
        public ActionResult<IEnumerable<Home>> Search([FromBody] HomeSearchModel model)
        {
            ActionResult<IEnumerable< Home>> result = db.Home.Include(p => p.ImageUrl).ToList();

            //Поиск когда заданы все 3 параметра
            if (model.City != "" && model.Street != "" && model.HomeNumber != "")
            {
                result = db.Home.Include(p => p.ImageUrl).Where(c => c.City == model.City && c.Street == model.Street && c.HomeNumber.Contains(model.HomeNumber)).ToList();
            }
            //иначе поиск по городу и улице
            else if (model.City != "" && model.Street != "")
            {
                result = db.Home.Include(p => p.ImageUrl).Where(c => c.City == model.City && c.Street == model.Street).ToList();
            }
            //иначе поиск по городу и номеру дома
            else if (model.City != "" && model.HomeNumber != "")
            {
                result = db.Home.Include(p => p.ImageUrl).Where(c => c.City == model.City && c.HomeNumber.Contains(model.HomeNumber)).ToList();
            }
            //иначе поиск по улице и номеру дома
            else if (model.Street != "" && model.HomeNumber != "")
            {
                result = db.Home.Include(p => p.ImageUrl).Where(c => c.Street == model.Street && c.HomeNumber.Contains(model.HomeNumber)).ToList();
            }
            //иначе поиск по одному параметру
            else
            {
                if (model.City != "")
                {
                    result = db.Home.Include(p => p.ImageUrl).Where(c => c.City == model.City).ToList();
                }
                else if (model.Street != "")
                {
                    result = db.Home.Include(p => p.ImageUrl).Where(c => c.Street == model.Street).ToList();
                }
                else if (model.HomeNumber != "")
                {
                    result = db.Home.Include(p => p.ImageUrl).Where(c => c.HomeNumber.Contains(model.HomeNumber)).ToList();
                }
            }
            return result;
        }

        // GET api/home?Fk_Home={Uid}
        [HttpGet]
        public IActionResult Home([FromQuery] String Fk_Home)
        {            
            Home home = db.Home.Include(p => p.ImageUrl).Include(p => p.Manager).Include(p => p.LocalGroups).Include(p => p.Tenants).FirstOrDefault(x => x.Uid == Fk_Home);
            if (home == null)
                return NotFound();
            IEnumerable<User> approvedTantains = home.Tenants.Where(p => p.IsApprovedHome == true).ToList();
            IEnumerable<User> newTantns = home.Tenants.Where(p => p.IsApprovedHome == false).ToList();
            
            return Ok(new
            {
                homeData = home,
                tantains = approvedTantains,
                newTantains = newTantns
            });
        }                

        // POST api/home
        [HttpPost("create")]
        public IActionResult Create([FromBody] HomeCreateModel model)
        {
            if(model.Fk_Role == (int)Role.admin || model.Fk_Role != (int)Role.moderator)
            {
                return BadRequest(new
                {
                    message = "У вас нет прав на выолнение данного запроса!"
                });
            }
            try
            {

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
        //[HttpPut]
        //public void Put([FromQuery] String Uid, [FromBody] HomeCreateModel model)
        //{
        //}

        // DELETE api/groups/5
        //[HttpDelete]
        //public void Delete([FromQuery] String Uid)
        //{
        //}
    }
}
