using Lumen.Modules.Sleep.Common.Models;
using Lumen.Modules.Sleep.Data;

using Microsoft.AspNetCore.Mvc;

namespace Lumen.Modules.Sleep.Module.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class SleepController(ILogger<SleepController> logger, SleepContext context) : ControllerBase {

        [HttpPost]
        public async Task<IActionResult> SubmitEntry([FromBody] SleepEntry entry, CancellationToken cancellationToken = default) {
            if (entry.Start >= entry.End) {
                return BadRequest();
            }

            try {
                await context.Sleep.AddAsync(entry, cancellationToken);
                await context.SaveChangesAsync(cancellationToken);

                return Ok();
            } catch (Exception ex) {
                logger.LogError(ex, "Unexpected error when adding entries");
                return StatusCode(StatusCodes.Status500InternalServerError, "Unexpected error");
            }
        }
    }
}
