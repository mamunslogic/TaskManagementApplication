using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Commands.CreateProject;
using TaskManagement.Application.Commands.CreateTask;
using TaskManagement.Application.Queries.GetProjectByIdQuery;
using TaskManagement.Application.Queries.GetTaskByIdQuery;
using TaskManagement.Application.Queries.ProjectQuery;
using TaskManagement.Application.Queries.TaskQuery;

namespace TaskManagement.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaskController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        public async Task<ActionResult> CreateTask(CreateTaskCommand command)
        {
            var taskId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetTaskById), new { id = taskId }, taskId);
        }

        [HttpGet]
        public async Task<ActionResult> GetTaskById(int id)
        {
            var task = await _mediator.Send(new GetTaskByIdQuery { TaskId = id });
            return task == null ? NotFound() : Ok(task);
        }

        [HttpGet]
        public async Task<ActionResult> GetTasks()
        {
            var taskList = await _mediator.Send(new TaskQuery());
            return taskList == null ? NotFound() : Ok(taskList);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProject(CreateProjectCommand command)
        {
            var projectId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetProjects), new { id = projectId }, projectId);
        }

        [HttpGet]
        public async Task<ActionResult> GetProjectById(int id)
        {
            var project = await _mediator.Send(new GetProjectByIdQuery { ProjectId = id });
            return project == null ? NotFound() : Ok(project);
        }

        [HttpGet]
        public async Task<ActionResult> GetProjects()
        {
            var projectList = await _mediator.Send(new ProjectQuery());
            return projectList == null ? NotFound() : Ok(projectList);
        }
    }
}
