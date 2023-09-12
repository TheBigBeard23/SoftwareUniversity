namespace TaskBoardApp.Data.Configurations
{

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using TaskBoardApp.Data.Models;

    public class BoardEntityConfiguration : IEntityTypeConfiguration<Board>
    {
        public void Configure(EntityTypeBuilder<Board> builder)
        {
            ICollection<Board> boards = this.GenerateBoard();

            builder
                .HasData(boards);

        }

        private ICollection<Board> GenerateBoard()
        {
            ICollection<Board> boards = new HashSet<Board>();

            Board crnBoard;

            crnBoard = new Board()
            {
                Id = 1,
                Name = "Open"
            };
            boards.Add(crnBoard);

            crnBoard = new Board()
            {
                Id = 2,
                Name = "InProgress"
            };
            boards.Add(crnBoard);

            crnBoard = new Board()
            {
                Id = 3,
                Name = "Done"
            };
            boards.Add(crnBoard);

            return boards;
        }
    }
}
