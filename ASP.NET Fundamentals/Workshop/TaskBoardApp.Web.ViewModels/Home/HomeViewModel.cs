namespace TaskBoardApp.Web.ViewModels.Home
{
    public class HomeViewModel
    {
        public int AllTasksCount { get; set; }
        public IEnumerable<HomeBoardViewModel> BoardsTasksCount { get; set; } = null!;

        public int UserTaskCount { get; set; }
    }
}
