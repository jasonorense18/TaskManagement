using FluentValidation;

namespace TaskManagement.Application.Task.Commands.CreateTask
{
    public sealed class CreateTaskCommandValidator :
        AbstractValidator<CreateTaskCommand>
    {
        public CreateTaskCommandValidator()
        {
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Description).NotNull();
        }
    }
}
