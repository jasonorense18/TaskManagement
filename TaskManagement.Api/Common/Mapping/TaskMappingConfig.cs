using Mapster;
using TaskManagement.Application.Task.Commands.CreateTask;
using TaskManagement.Application.Task.Commands.UpdateTask;
using TaskManagement.Application.Task.Common;
using TaskManagement.Contract.Task;

namespace TaskManagement.Api.Common.Mapping
{
    public sealed class TaskMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<TaskRequest, CreateTaskCommand>();
            config.NewConfig<TaskRequest, UpdateTaskCommand>();

            config.NewConfig<TaskResultDto, TaskResponse>()
                .Map(dest => dest, src => src.Task);


        }
    }
}
