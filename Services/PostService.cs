using Microsoft.EntityFrameworkCore;
using PostsApi.Data;
using PostsApi.Models;

namespace PostsApi.Services;

public class PostService
{
    private readonly AppDbContext _context;

    public PostService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Post>> GetAllPostsAsync() => await _context.Posts.ToListAsync();

    public async Task<Post?> GetPostByNameAsync(string name) =>
        await _context.Posts.Where(p => p.Name == name).FirstOrDefaultAsync();

    public async Task AddPostAsync(Post post)
    {
        _context.Posts.Add(post);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> UpdatePostAsync(int id, Post updatedPost)
    {
        var existingPost = await _context.Posts.FindAsync(id);
        if (existingPost == null) return false;

        existingPost.Name = updatedPost.Name;
        existingPost.Description = updatedPost.Description;
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeletePostAsync(int id)
    {
        var post = await _context.Posts.FindAsync(id);
        if (post == null) return false;

        _context.Posts.Remove(post);
        await _context.SaveChangesAsync();

        return true;
    }
}