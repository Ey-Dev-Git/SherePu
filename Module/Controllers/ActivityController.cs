using Microsoft.AspNetCore.Mvc;
using Module.Data;
using Module.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ActivityController : Controller
    {

        private readonly ApplicationDBContext _db;
        public ActivityController(ApplicationDBContext db)
        {
            _db = db;
        }

        // /Activity/AllActivity
        [HttpGet]
        [Route("AllActivity")]
        public IActionResult AllActivity()
        {
            IEnumerable<Activities> allActivity = _db.Activities;

            return Ok(allActivity);
        }

        // /Activity/CreateDataActivity
        [HttpPost]
        [Route("CreateDataActivity")]
        [IgnoreAntiforgeryToken]
        public IActionResult CreateDataActivity([FromBody] Activities model)
        {
            if (ModelState.IsValid)
            {
                _db.Activities.Add(model);
                _db.SaveChanges();
                return Ok("สร้างเรียบร้อย");
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // /Activity/UpdateDataActivity/{id}
        [HttpPost]
        [Route("UpdateDataActivity/{id}")]
        [IgnoreAntiforgeryToken]
        public IActionResult UpdateDataActivity(int id, [FromBody] Activities model)
        {
            var activity = _db.Activities.Find(id);
            if (activity == null || id == 0)
            {
                return NotFound();
            }
            else if (ModelState.IsValid)
            {
                activity.ActivityName = model.ActivityName;
                activity.ActivityDetail = model.ActivityDetail;
                activity.ActivityPicture = model.ActivityPicture;
                activity.LocationTravelID = model.LocationTravelID;
                _db.Activities.Update(activity);
                _db.SaveChanges();
                return Ok("แก้ไขเรียบร้อย");
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // /Activity/DeleteActivity/{id}
        [HttpDelete()]
        [Route("DeleteActivity/{id}")]
        [IgnoreAntiforgeryToken]
        public IActionResult DeleteActivity(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Activities.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Activities.Remove(obj);
            _db.SaveChanges();
            return Ok("ลบเรียบร้อย");
        }


    }
}
