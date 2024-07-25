﻿using ForumApp.Data;
using ForumApp.Data.Models;
using ForumApp.Models.Post;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Controllers
{
    public class PostController : Controller
    {
        private readonly ForumAppDbContext _data;
        public PostController(ForumAppDbContext data)
        {
            _data = data;
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var posts = await _data
                .Posts
                .Select(p => new PostViewModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content,
                })
                .ToListAsync();

            return View(posts);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(PostFormModel model)
        {
            var post = new Post()
            {
                Title = model.Title,
                Content = model.Content,
            };

            await _data.Posts.AddAsync(post);
            await _data.SaveChangesAsync();

            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var post = await _data.Posts.FindAsync(id);

                return View(new PostFormModel()
                {
                    Title = post.Title,
                    Content = post.Content
                });
            }
            catch (Exception)
            {
                return this.RedirectToAction("All", "Post");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, PostFormModel model)
        {
            var post = await _data.Posts.FindAsync(id);

            post.Title = model.Title;
            post.Content = model.Content;

            await _data.SaveChangesAsync();

            return RedirectToAction("All");

        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var post = await _data.Posts.FindAsync(id);

                _data.Posts.Remove(post);
                await _data.SaveChangesAsync();
            }
            catch (Exception)
            {
                return this.RedirectToAction("All", "Post");
            }

            return RedirectToAction("All");
        }


    }
}
