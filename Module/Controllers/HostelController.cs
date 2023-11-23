using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Module.Data;
using Module.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HostelController : Controller
    {
        private readonly ApplicationDBContext _db;
        public HostelController(ApplicationDBContext db)
        {
            _db = db;
        }

        // /Hostel/AllHostel
        [HttpGet]
        [Route("AllHostel")]
        public IActionResult AllHostel()
        {
            var hostels = from hostel in _db.Hostels
                          select new
                          {
                              hostel.HostelName,
                              hostel.HostelPicture
                          };

            return Ok(hostels);
        }


        // /Hostel/FindHostelByID/{id}
        [HttpGet]
        [Route("FindHostelByID/{id}")]
        public ActionResult FindHostelByID(int id)
        {
            var hostelByID = _db.Hostels.Find(id);
            if (hostelByID == null || id == 0)
            {
                return NotFound();
            }
            else if (ModelState.IsValid)
            {
                return Ok(hostelByID);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // /Hostel/CreateDataHostel
        [HttpPost]
        [Route("CreateDataHostel")]
        [IgnoreAntiforgeryToken]
        public IActionResult CreateDataHostel([FromBody] Hostels model)
        {
            if (ModelState.IsValid)
            {
                _db.Hostels.Add(model);
                _db.SaveChanges();
                return Ok("สร้างเรียบร้อย");
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // /Hostel/UpdateDataHostel/{id}
        [HttpPost]
        [Route("UpdateDataHostel/{id}")]
        [IgnoreAntiforgeryToken]
        public IActionResult UpdateDataHostel(int id, [FromBody] Hostels model)
        {
            var hostel = _db.Hostels.Find(id);
            if (hostel == null || id == 0)
            {
                return NotFound();
            }
            else if (ModelState.IsValid)
            {
                hostel.HostelName = model.HostelName;
                hostel.HostelNameDetail = model.HostelNameDetail;
                hostel.HostelZone = model.HostelZone;
                hostel.HostelFacilities = model.HostelFacilities;
                hostel.HostelNumberOfGuests = model.HostelNumberOfGuests;
                hostel.HostelNumberOfBedrooms  = model.HostelNumberOfBedrooms;
                hostel.HostelNumberOfBathrooms = model.HostelNumberOfBathrooms;
                hostel.HostelLinkToBook = model.HostelLinkToBook;
                hostel.HostelPicture = model.HostelPicture;
                hostel.HostelRoomPicture = model.HostelRoomPicture;
                _db.Hostels.Update(hostel);
                _db.SaveChanges();
                return Ok("แก้ไขเรียบร้อย");
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // /Hostel/DeleteHostel/{id}
        [HttpDelete()]
        [Route("DeleteHostel/{id}")]
        [IgnoreAntiforgeryToken]
        public IActionResult DeleteHostel(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Hostels.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Hostels.Remove(obj);
            _db.SaveChanges();
            return Ok("ลบเรียบร้อย");
        }


    }
}
