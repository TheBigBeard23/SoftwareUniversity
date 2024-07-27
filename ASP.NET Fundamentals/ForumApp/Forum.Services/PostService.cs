using Forum.Services.Interfaces;
using ForumApp.Data;
using ForumApp.Data.Models;
using ForumApp.Models.Post;
using Microsoft.EntityFrameworkCore;

namespace Forum.Services
{
    public class PostService : IPostService
    {
        private readonly ForumAppDbContext _context;

        public PostService(ForumAppDbContext ctx)
        {
            this._context = ctx;
        }

        public async Task AddPostAsync(PostFormModel model)
        {
            var post = new Post()
            {
                Title = model.Title,
                Content = model.Content,
            };

            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var post = await _context.Posts.FindAsync(id);

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();

        }

        public async Task EditByIdAsync(int id, PostFormModel model)
        {
            var postToEdit = await this._context
                .Posts
                .FirstAsync(p => p.Id == id);

            postToEdit.Title = model.Title;
            postToEdit.Content = model.Content;

            await this._context.SaveChangesAsync();
        }

        public async Task<PostFormModel> GetByIdAsync(int id)
        {
            var post = await _context.Posts
                .FirstAsync(p => p.Id == id);

            return new PostFormModel()
            {
                Title = post.Title,
                Content = post.Content

            };
        }

        public async Task<IEnumerable<PostViewModel>> ListAllAsync()
        {
            IEnumerable<PostViewModel> allPosts = await _context
                .Posts
                .Select(p => new PostViewModel
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content,
                })
                .ToListAsync();

            return allPosts;
        }
    }
}
