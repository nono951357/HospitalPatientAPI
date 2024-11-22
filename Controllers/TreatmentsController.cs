using HospitalPatientAPI.Context;
using HospitalPatientAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalPatientAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TreatmentsController : ControllerBase
    {
        private readonly HospitalContext _context;

        public TreatmentsController(HospitalContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetTreatments()
        {
            return Ok(_context.Treatments.Include(t => t.Patient).Include(t => t.Doctor));
        }

        [HttpGet("{id}")]
        public IActionResult GetTreatment(int id)
        {
            var treatment = _context.Treatments.Include(t => t.Patient).Include(t => t.Doctor).FirstOrDefault(t => t.Id == id);
            if (treatment == null)
            {
                return NotFound();
            }
            return Ok(treatment);
        }

        [HttpPost]
        public IActionResult CreateTreatment(Treatment treatment)
        {
            _context.Treatments.Add(treatment);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetTreatment), new { id = treatment.Id }, treatment);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTreatment(int id, Treatment treatment)
        {
            treatment.Id = id;
            _context.Entry(treatment).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTreatment(int id)
        {
            var treatment = _context.Treatments.Find(id);
            if (treatment == null)
            {
                return NotFound();
            }
            _context.Treatments.Remove(treatment);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
