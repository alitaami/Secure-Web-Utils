using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SecureWebUtils.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SanitizationController : ControllerBase
    {
        [HttpPost("sanitize-url")]
        public IActionResult SanitizeUrl([FromBody] string url)
        {
            try
            {
                string sanitizedUrl = url.SanitizeUrl();
                string escapedUrl = sanitizedUrl.EscapeOutput2();
                return Ok(new { SanitizedUrl = sanitizedUrl, EscapedUrl = escapedUrl });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        [HttpPost("escape-input")]
        public IActionResult EscapeInput([FromBody] string input)
        {
            try
            {
                string escapedOutput = input.EscapeOutput();
                return Ok(new { EscapedOutput = escapedOutput });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        [HttpGet("dangerous-patterns")]
        public IActionResult GetDangerousPatterns()
        {
            return Ok(Consts.DangerousPatterns);
        }
    }
}
  
