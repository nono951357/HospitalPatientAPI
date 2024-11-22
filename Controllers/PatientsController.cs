using HospitalPatientAPI.Context;
using HospitalPatientAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalPatientAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController(HospitalContext context) : ControllerBase
    {
        private readonly HospitalContext _context = context;

        [HttpGet]
        public IActionResult GetPatients()
        {
            return Ok(_context.Patients);
        }

        [HttpGet("{id}")]
        public IActionResult GetPatient(int id)
        {
            var patient = _context.Patients.Find(id);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }

        [HttpPost]
        public IActionResult CreatePatient(Patient patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetPatient), new { id = patient.Id }, patient);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePatient(int id, Patient patient)
        {
            patient.Id = id;
            _context.Entry(patient).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePatient(int id)
        {
            var patient = _context.Patients.Find(id);
            if (patient == null)
            {
                return NotFound();
            }
            _context.Patients.Remove(patient);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
