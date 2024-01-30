using BAL.Interfaces;
using BAL.Services;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Task_Management_Application.Model;

namespace Task_Management_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController: ControllerBase
    {
        private readonly IStatusService _statusService;
        private readonly ILogger<StatusController> _logger;
        public StatusController(ILogger<StatusController> logger, IStatusService statusService)
        {

            _logger = logger;
            _statusService = statusService;

        }

        [HttpGet]
        public async Task<IActionResult> GetStatusesAsync()
        {
            try
            {
                return Ok(await _statusService.GetStatusesAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the request.");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
