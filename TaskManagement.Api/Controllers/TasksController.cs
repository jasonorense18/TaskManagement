using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Task.Commands.CreateTask;
using TaskManagement.Application.Task.Commands.DeleteTask;
using TaskManagement.Application.Task.Commands.UpdateTask;
using TaskManagement.Application.Task.Common;
using TaskManagement.Application.Task.Queries.GetTaskById;
using TaskManagement.Application.Task.Queries.GetTasks;
using TaskManagement.Contract.Task;

namespace TaskManagement.Api.Controllers
{
    [Route("api/tasks")]
    public class TasksController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public TasksController(
            ISender mediator, 
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskRequest request)
        {
            var userId = GetUserId();

            var command = _mapper.Map<CreateTaskCommand>(request);
            command.UserId = userId;

            ErrorOr<TaskResultDto> results = await _mediator.Send(command);

            return results.Match(
                result => CreatedAtGetTask(result),
                errors => Problem(errors));
        }

        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            var userId = GetUserId();
            var query = new GetTaskQuery(userId);

            ErrorOr<IEnumerable<TaskResultDto>> results = await _mediator.Send(query);

            return results.Match(
                result => Ok(result.Select(a => _mapper.Map<TaskResponse>(a)).ToList()),
                errors => Problem(errors));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetTask(Guid id)
        {
            var userId = GetUserId();

            var query = new GetTaskByIdQuery(userId, id);
            ErrorOr<TaskResultDto> results = await _mediator.Send(query);

            return results.Match(
                result => Ok(_mapper.Map<TaskResponse>(result)),
                errors => Problem(errors));
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(
            Guid id,
            TaskRequest request)
        {
            var userId = GetUserId();

            var command = _mapper.Map<UpdateTaskCommand>(request);
            command.UserId = userId;
            command.TaskId = id;

            ErrorOr<TaskResultDto> results = await _mediator.Send(command);

            return results.Match(
                result => NoContent(),
                errors => Problem(errors));
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Remove(Guid id, TaskRequest request)
        {
            var userId = GetUserId();

            var command = new DeleteTaskCommand(userId, request.VersionId, id);
            ErrorOr<Deleted> results = await _mediator.Send(command);

            return results.Match(
                result => NoContent(),
                errors => Problem(errors));
        }


        private CreatedAtActionResult CreatedAtGetTask(TaskResultDto taskResultDto)
        {
            return CreatedAtAction(
                actionName: nameof(GetTask),
                routeValues: new { id = taskResultDto.Task.Id },
                value: _mapper.Map<TaskResponse>(taskResultDto)
            );
        }

    }
}
