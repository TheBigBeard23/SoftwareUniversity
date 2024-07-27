using ForumApp.Models.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Services.Interfaces
{
    public interface IPostService
    {
        Task<IEnumerable<PostViewModel>> ListAllAsync();
        Task AddPostAsync(PostFormModel model);
        Task<PostFormModel> GetByIdAsync(int id);
        Task EditByIdAsync(int id, PostFormModel model);
        Task DeleteByIdAsync(int id);
    }
}
