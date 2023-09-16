using TaskBoardApp.Web.ViewModels.Task;

namespace TaskBoardApp.Web.ViewModels.Board
{
    public class BoardAllViewModel
    {
        public string Name { get; set; } = null!;

        public string Id { get; set; }
        public ICollection<TaskViewModel> Tasks { get; set; } = null!;
    }
}
