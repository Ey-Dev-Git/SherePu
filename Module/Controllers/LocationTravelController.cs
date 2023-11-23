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
    public class LocationTravelController : Controller
    {
        private readonly ApplicationDBContext _db;
        public LocationTravelController(ApplicationDBContext db)
        {
            _db = db;
        }

        // /LocationTravel/AllLocationTravel
        [HttpGet]
        [Route("AllLocationTravel")]
        public IActionResult AllLocationTravel()
        {
            var locationTravels = from locationTravel in _db.LocationTravels
                                  select new
                                  {
                                      locationTravel.LocationTravelName,
                                      locationTravel.LocationTravelPicture
                                  };

            return Ok(locationTravels);
        }


        // /LocationTravel/FindLocationTravelByID/{id}
        [HttpGet]
        [Route("FindLocationTravelByID/{id}")]
        public ActionResult FindLocationTravelByID(int id)
        {
            var locationTravelByID = _db.LocationTravels.Find(id);
            if (locationTravelByID == null || id == 0)
            {
                return NotFound();
            }
            else if (ModelState.IsValid)
            {
                var locationTravel = from locationTravelData in _db.LocationTravels
                                     where locationTravelData.LocationTravelID == id
                                     select new
                                     {

                                         locationTravelData.LocationTravelName,
                                         locationTravelData.LocationTravelDetail,
                                         locationTravelData.LocationTravelPicture,
                                         locationTravelData.LocationTravelPathGoogleMap,
                                         activities = (from activityData in _db.Activities
                                                       where activityData.LocationTravelID == locationTravelData.LocationTravelID
                                                       select new
                                                       {
                                                           activityData.ActivityName,
                                                           activityData.ActivityDetail,
                                                           activityData.ActivityPicture
                                                       }).ToList()
                                     };

                return Ok(locationTravel);

            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // /LocationTravel/CreateDataLocationTravel
        [HttpPost]
        [Route("CreateDataLocationTravel")]
        [IgnoreAntiforgeryToken]
        public IActionResult CreateDataLocationTravel([FromBody] LocationTravels model)
        {
            if (ModelState.IsValid)
            {
                _db.LocationTravels.Add(model);
                _db.SaveChanges();
                return Ok("สร้างเรียบร้อย");
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // /LocationTravel/UpdateDataLocationTravel/{id}
        [HttpPost]
        [Route("UpdateDataLocationTravel/{id}")]
        [IgnoreAntiforgeryToken]
        public IActionResult UpdateDataLocationTravel(int id, [FromBody] LocationTravels model)
        {
            var locationTravel = _db.LocationTravels.Find(id);
            if (locationTravel == null || id == 0)
            {
                return NotFound();
            }
            else if (ModelState.IsValid)
            {
                locationTravel.LocationTravelName = model.LocationTravelName;
                locationTravel.LocationTravelDetail = model.LocationTravelDetail;
                locationTravel.LocationTravelPicture = model.LocationTravelPicture;
                locationTravel.LocationTravelPathGoogleMap = model.LocationTravelPathGoogleMap;
                _db.LocationTravels.Update(locationTravel);
                _db.SaveChanges();
                return Ok("แก้ไขเรียบร้อย");
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // /LocationTravel/DeleteLocationTravel/{id}
        [HttpDelete()]
        [Route("DeleteLocationTravel/{id}")]
        [IgnoreAntiforgeryToken]
        public IActionResult DeleteLocationTravel(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.LocationTravels.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.LocationTravels.Remove(obj);
            _db.SaveChanges();
            return Ok("ลบเรียบร้อย");
        }

    }
}
