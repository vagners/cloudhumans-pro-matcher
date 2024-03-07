using Microsoft.AspNetCore.Mvc;
using ProMatcher.Api.Models;
using ProMatcher.Domain.Services;
using System.Net;
using ProMatcher.Domain.Exceptions;

namespace ProMatcher.Api.Controllers
{
    public class MatchProController : Controller
    {
        private readonly MatchProService _matchProService;

        public MatchProController(MatchProService matchProService) => _matchProService = matchProService;

        [HttpPost]
        [Route("matchpro")]
        [ProducesResponseType(typeof(MatchProResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> MatchPro([FromBody] MatchProRequest request)
        {
            try
            {
                var command = MatchProMapper.MapFromRequest(request);
                var result = await _matchProService.MatchProToProject(command);
                return Ok(MatchProMapper.MapFromResult(result));
            }
            catch (Exception ex)
            {
                if (ex is FixedValueNotFoundException || ex is BusinessException)
                    return BadRequest(ex.Message);
                else
                    throw;
            }
        }
    }
}
