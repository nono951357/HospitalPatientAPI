using HospitalPatientAPI.Context;
using HospitalPatientAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalPatientAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorsController(HospitalContext context) : ControllerBase
    {
        private readonly HospitalContext _context = context;

        [HttpGet]
        public IActionResult GetDoctors()
        {
            return Ok(_context.Doctors);
        }

        [HttpGet("{id}")]
        public IActionResult GetDoctor(int id)
        {
            var doctor = _context.Doctors.Find(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return Ok(doctor);
        }

        [HttpPost]
        public IActionResult CreateDoctor(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetDoctor), new { id = doctor.Id }, doctor);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDoctor(int id, Doctor doctor)
        {
            doctor.Id = id;
            _context.Entry(doctor).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDoctor(int id)
        {
            var doctor = _context.Doctors.Find(id);
            if (doctor == null)
            {
                return NotFound();
            }
            _context.Doctors.Remove(doctor);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
