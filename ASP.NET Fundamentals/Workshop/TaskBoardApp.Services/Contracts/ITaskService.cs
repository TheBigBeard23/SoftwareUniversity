namespace TaskBoardApp.Services.Contracts
{
    using TaskBoardApp.Web.ViewModels.Task;
    public interface ITaskService
    {
        Task AddAsync(string ownerId, TaskFormModel viewModel);

        Task EditTask(string id, string Title, string Description, int BoardId);

        Task<TaskDetailsViewModel> GetTaskDetailsByIdAsync(string id);

        Task<TaskFormModel> GetTaskEditByIdAsync(string id);

        Task<TaskOwnerViewModel> GetTaskById(string id);

    }
}
