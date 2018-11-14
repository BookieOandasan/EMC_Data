using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResidencyApplication.Repository.ResidencyApplication;

namespace ResidencyApplication.Webapi.Controllers
{
    [Route("odata/[controller]")]
    [ApiController]
    [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
    public class ApplicantsController : ControllerBase
    {
        private readonly ResidencyApplicationContext _context;

        public ApplicantsController(ResidencyApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Applicants
        //[HttpGet]
        //[ODataRoute("Applicants")]
        //[EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        //public IQueryable<ApplicantModel> Applicants()
        //{
        //    var result = _context.Applicants.AsQueryable();
        //    return result;
        //}

        ///https://localhost:44353/odata/Applicants?searchText=111
        [HttpGet]
       [ODataRoute("getApplicants(searchText={searchText})")]
       [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IQueryable<ApplicantModel> getApplicants([FromODataUri]string searchText)
        {
            var result = _context.Applicants.AsQueryable();
            return result;
        }

        // GET: api/Applicants/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetApplicantModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var applicantModel = await _context.Applicants.FindAsync(id);

            if (applicantModel == null)
            {
                return NotFound();
            }

            return Ok(applicantModel);
        }

        // PUT: api/Applicants/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApplicantModel([FromRoute] int id, [FromBody] ApplicantModel applicantModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != applicantModel.id)
            {
                return BadRequest();
            }

            _context.Entry(applicantModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicantModelExists(id))
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

        // POST: api/Applicants
        [HttpPost]
        public async Task<IActionResult> PostApplicantModel([FromBody] ApplicantModel applicantModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Applicants.Add(applicantModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetApplicantModel", new { id = applicantModel.id }, applicantModel);
        }

        // DELETE: api/Applicants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApplicantModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var applicantModel = await _context.Applicants.FindAsync(id);
            if (applicantModel == null)
            {
                return NotFound();
            }

            _context.Applicants.Remove(applicantModel);
            await _context.SaveChangesAsync();

            return Ok(applicantModel);
        }

        private bool ApplicantModelExists(int id)
        {
            return _context.Applicants.Any(e => e.id == id);
        }
    }
}