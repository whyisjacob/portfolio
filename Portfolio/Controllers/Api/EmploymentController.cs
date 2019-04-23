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
    public class EmploymentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EmploymentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EmploymentModels
        [HttpGet]
        public IEnumerable<EmploymentModel> GetEmploymentModel()
        {
            return _context.EmploymentModel;
        }

        // GET: api/EmploymentModels/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmploymentModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employmentModel = await _context.EmploymentModel.FindAsync(id);

            if (employmentModel == null)
            {
                return NotFound();
            }

            return Ok(employmentModel);
        }

        // PUT: api/EmploymentModels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmploymentModel([FromRoute] int id, [FromBody] EmploymentModel employmentModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employmentModel.EmploymentId)
            {
                return BadRequest();
            }

            _context.Entry(employmentModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmploymentModelExists(id))
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

        // POST: api/EmploymentModels
        [HttpPost]
        public async Task<IActionResult> PostEmploymentModel([FromBody] EmploymentModel employmentModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.EmploymentModel.Add(employmentModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmploymentModel", new { id = employmentModel.EmploymentId }, employmentModel);
        }

        // DELETE: api/EmploymentModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmploymentModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employmentModel = await _context.EmploymentModel.FindAsync(id);
            if (employmentModel == null)
            {
                return NotFound();
            }

            _context.EmploymentModel.Remove(employmentModel);
            await _context.SaveChangesAsync();

            return Ok(employmentModel);
        }

        private bool EmploymentModelExists(int id)
        {
            return _context.EmploymentModel.Any(e => e.EmploymentId == id);
        }
    }
}