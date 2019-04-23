using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Models;

namespace Portfolio.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EducationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Education
        [HttpGet]
        public IEnumerable<EducationModel> GetEducationModel()
        {
            return _context.EducationModel;
        }

        // GET: api/Education/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEducationModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var educationModel = await _context.EducationModel.FindAsync(id);

            if (educationModel == null)
            {
                return NotFound();
            }

            return Ok(educationModel);
        }

        // PUT: api/Education/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEducationModel([FromRoute] int id, [FromBody] EducationModel educationModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != educationModel.InstitutionId)
            {
                return BadRequest();
            }

            _context.Entry(educationModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EducationModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Education
        [HttpPost]
        public async Task<IActionResult> PostEducationModel([FromBody] EducationModel educationModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.EducationModel.Add(educationModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEducationModel", new { id = educationModel.InstitutionId }, educationModel);
        }

        // DELETE: api/Education/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEducationModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var educationModel = await _context.EducationModel.FindAsync(id);
            if (educationModel == null)
            {
                return NotFound();
            }

            _context.EducationModel.Remove(educationModel);
            await _context.SaveChangesAsync();

            return Ok(educationModel);
        }

        private bool EducationModelExists(int id)
        {
            return _context.EducationModel.Any(e => e.InstitutionId == id);
        }
    }
}