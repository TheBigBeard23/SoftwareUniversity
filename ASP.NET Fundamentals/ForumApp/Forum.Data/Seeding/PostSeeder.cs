using ForumApp.Data.Models;

namespace ForumApp.Data.Seeding
{
    internal class PostSeeder
    {
        internal Post[] GeneratePosts()
        {
            ICollection<Post> posts = new HashSet<Post>();
            Post currentPost;

            currentPost = new Post()
            {
                Id = 1,
                Title = "My First Post",
                Content = "My first post will be about performing CRUD operations in MVC. It's so much fun!"
            };
            posts.Add(currentPost);

            currentPost = new Post()
            {
                Id = 2,
                Title = "My Second Post",
                Content = "This is second post.CRUD operations is MVC ate getting more and more interesting!"
            };
            posts.Add(currentPost);

            currentPost = new Post()
            {
                Id = 3,
                Title = "My Third Post",
                Content = "Hello there! I'm getting better and better with the CRUD operations in MVC. Stay tuned!"
            };
            posts.Add(currentPost);

            return posts.ToArray();
        }
    }
}
