using Microsoft.AspNetCore.Mvc;
using Lab4;
namespace Lab4.Controllers;
[ApiController]
[Route("api/tasks")]
public class TaskController : ControllerBase
{
    private readonly ITaskService taskService;

    public TaskController(ITaskService taskService)
    {
        this.taskService = taskService;
    }

    [HttpGet]
    public IActionResult GetAllTasks()
    {
        var tasks = taskService.GetAllTasks();
        return Ok(tasks);
    }

    [HttpGet("{numberOfTusks}")]
    public IActionResult GetNTask(int numberOfTusks)
    {
        var task = taskService.GetNTasks(numberOfTusks);
        if (task == null)
            return NotFound();

        return Ok(task);
    }

    [HttpPost]
    public IActionResult AddTask([FromBody] Task task)
    {
        if (task == null)
            return BadRequest();

        taskService.AddTask(task);

        return CreatedAtAction(nameof(GetAllTasks), new { id = task.Id }, task);
    }


}
