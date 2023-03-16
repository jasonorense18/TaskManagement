using ErrorOr;

namespace TaskManagement.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Task
        {
            public static Error EmptyDescription => Error.Validation(
                code: "Task.EmptyDescription",
                description: "Description is empty.");

            public static Error TaskNotFound => Error.NotFound(
                code: "Task.NotFound",
                description: "Task not found.");

            public static Error TaskVersionConflictUpdate => Error.Conflict(
                code: "Task.Conflict",
                description: "The record you attempted to update was modified by another user after you got the original value." +
                "The edit operation was canceled.");

            public static Error TaskVersionConflictDelete => Error.Conflict(
                code: "Task.Conflict",
                description: "The record you attempted to delete was modified by another user after you got the original value." +
                "The delete operation was canceled.");

        }
    }
}
