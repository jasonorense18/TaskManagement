using FluentValidation;

namespace TaskManagement.Application.Task.Commands.UpdateTask
{
    public sealed class UpdateTaskCoomandValidator : 
        AbstractValidator<UpdateTaskCommand>
    {
        public UpdateTaskCoomandValidator()
        {
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Description).NotNull();
        }
    }
}
