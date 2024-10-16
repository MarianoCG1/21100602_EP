using _21100602_EP.Interfaces;
using _21100602_EP.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _21100602_EP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompentencyController : ControllerBase
    {
        private readonly ICompentencyRepository _compentencyRepository;

        public CompentencyController(ICompentencyRepository compentencyRepository)
        {
            _compentencyRepository = compentencyRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var attendees = await _compentencyRepository.GetAll();
            return Ok(attendees);
        }

        [HttpPost]

        public async Task<IActionResult> Insert([FromBody] Competency competency)
        {
            int compentencyID = await _compentencyRepository.Insert(competency);
            return Ok(compentencyID);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _compentencyRepository.Delete(id);
            if (!result) return NotFound();
            return Ok(result);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Competency competency)
        {
            if (id != competency.Id) return BadRequest();
            var result = await _compentencyRepository.Update(competency);
            if (!result) return NotFound();
            return Ok(result);
        }

        

    }
}
