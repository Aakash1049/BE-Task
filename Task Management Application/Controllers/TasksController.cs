using BAL.Interfaces;
using BAL.Model;
using BAL.Services;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Task_Management_Application.Model;

namespace Task_Management_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly ILogger<TasksController> _logger;
        private const string error = "An error occurred while processing the request.";
        private const string statusCodeMessage = "An error occurred while processing the request.";

        public TasksController(ITaskService taskService, ILogger<TasksController> logger)
        {
            _taskService = taskService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetTaskItems([FromQuery] PaginationParameters paginationParameters)
        {
            try
            {

                return Ok(await _taskService.GetTasksAsync(paginationParameters));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, error);
                return StatusCode(500, statusCodeMessage);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateTask(TaskItemDto taskItem)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                return Ok(await _taskService.AddTaskAsync(taskItem));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, error);
                return StatusCode(500, statusCodeMessage);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTask(int id, TaskItemDto taskItem)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                return Ok(await _taskService.UpdateTaskAsync(id, taskItem));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, error);
                return StatusCode(500, statusCodeMessage);
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTask(int id)
        {
            try
            {

                return Ok(await _taskService.DeleteTaskAsync(id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, error);
                return StatusCode(500, statusCodeMessage);
            }
        }
    }
}
