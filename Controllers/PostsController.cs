using Microsoft.AspNetCore.Mvc;
using PostsApi.Models;
using PostsApi.Services;

namespace PostsApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostsController : ControllerBase
{
    private readonly PostService _postService;

    public PostsController(PostService postService)
    {
        _postService = postService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var posts = await _postService.GetAllPostsAsync();
        return Ok(posts);
    }

    [HttpGet("{name}")]
    public async Task<IActionResult> GetByName(string name)
    {
        var post = await _postService.GetPostByNameAsync(name);
        if (post == null) return NotFound();

        return Ok(post);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Post post)
    {
        await _postService.AddPostAsync(post);
        return CreatedAtAction(nameof(GetByName), new { name = post.Name }, post);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Post post)
    {
        var success = await _postService.UpdatePostAsync(id, post);
        if (!success) return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _postService.DeletePostAsync(id);
        if (!success) return NotFound();

        return NoContent();
    }
}