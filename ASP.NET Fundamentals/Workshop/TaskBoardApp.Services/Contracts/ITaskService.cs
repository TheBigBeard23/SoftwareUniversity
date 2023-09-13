namespace TaskBoardApp.Services.Contracts
{
    using TaskBoardApp.Web.ViewModels.Task;
    public interface ITaskService
    {
        Task AddAsync(string ownerId, TaskFormModel viewModel);
    }
}
