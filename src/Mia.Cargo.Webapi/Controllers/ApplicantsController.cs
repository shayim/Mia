using System;
using System.Net;
using System.Threading.Tasks;
using Mia.Common.ViewModels.Applicants;
using Mia.Services.PartyService;
using Microsoft.AspNetCore.Mvc;

namespace Mia.Cargo.Webapi.Controllers
{
    //    [Authorize]
    [Route("api/[controller]")]
    public class ApplicantsController : Controller
    {
        private readonly IApplicantService _applicantService;

        public ApplicantsController(IApplicantService applicantService)
        {
            _applicantService = applicantService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var applicants = await _applicantService.GetAll(User.Identity.Name);
            return Ok(applicants);
        }

        [HttpGet("{applicantId}")]
        public async Task<IActionResult> Get(Guid applicantId)
        {
            if (applicantId == default(Guid))
            {
                return BadRequest();
            }

            var applicant = await _applicantService.Get(User.Identity.Name, applicantId);

            return Ok(applicant);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]NewApplicantVm newApplicant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var applicant = await _applicantService.Add(User.Identity.Name, newApplicant);

            return Created(Url.Action(nameof(Get), applicant.Id), applicant);
        }

        [HttpPut("{applicantId}")]
        public async Task<IActionResult> Put(Guid applicantId, [FromBody]UpdateApplicantVm updateApplicant)
        {
            if (!ModelState.IsValid || applicantId == default(Guid) || applicantId != updateApplicant.Id)
            {
                return BadRequest();
            }

            var applicant = await _applicantService.Update(User.Identity.Name, updateApplicant);

            return Ok(applicant);
        }

        // DELETE api/values/5
        [HttpDelete("{applicantId}")]
        public async Task<IActionResult> Delete(Guid applicantId)
        {
            if (applicantId == default(Guid))
            {
                return BadRequest();
            }

            var result = await _applicantService.Delete(User.Identity.Name, applicantId);

            if (!result.Sucess)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, result.ErrorMessage);
            }

            return Ok();
        }
    }
}
