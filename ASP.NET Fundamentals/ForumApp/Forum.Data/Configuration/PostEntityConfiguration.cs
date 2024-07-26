using ForumApp.Data.Models;
using ForumApp.Data.Seeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ForumApp.Data.Configuration
{
    public class PostEntityConfiguration : IEntityTypeConfiguration<Post>
    {
        private readonly PostSeeder _seeder;

        public PostEntityConfiguration()
        {
            _seeder = new PostSeeder();
        }
        public void Configure(EntityTypeBuilder<Post> builder)
        {
               builder.HasData(this._seeder.GeneratePosts());
        }
    }
}
