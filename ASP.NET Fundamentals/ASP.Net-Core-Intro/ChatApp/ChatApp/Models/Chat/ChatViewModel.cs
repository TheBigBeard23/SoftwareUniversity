namespace ChatApp.Models.Chat
{
    public class ChatViewModel
    {
        public ChatViewModel()
        {
            this.AllMessage = new HashSet<MessageViewModel>();
        }
        public MessageViewModel CrnMessage { get; set; } = null!;
        public ICollection<MessageViewModel> AllMessage { get; set; } = null!; 


    }
}
