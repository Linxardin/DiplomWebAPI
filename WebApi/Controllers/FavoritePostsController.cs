using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;
using WebApi.Services.FavoritePostsService;

namespace WebApi.Controllers;


[ApiController]
[Route("[controller]")]
public class FavoritePostsController :ControllerBase
{
    private readonly IPostsService _postsService;

    public FavoritePostsController(IPostsService postsService)
    {
        _postsService = postsService;
    }
    [HttpGet("by-user/{userId:long}")]
    public async Task<ActionResult<IEnumerable<FavoritePostDto>>> GetAllFavoritePostsByUser([Required]long userId)
    {
        var postsByUserId = await _postsService.GetAllPostsByUserId(userId);
        return Ok(postsByUserId);
    }
    
    [HttpGet("{postId:Guid}")]
    public async Task<ActionResult<ApartmentDto>> GetPostById([Required]Guid postId)
    {
        var post = await _postsService.GetPostById(postId);
        if (post == null)
        {
            return NotFound();
        }
        return Ok(post);
    }
        
    [HttpPost("by-user/single/create")]
    public async Task<ActionResult<ApartmentDto>> Create(CreateFavoritePostDto createFavoritePostDto)
    {
        var createdFavoritePost = await _postsService.CreateFavoritePost(createFavoritePostDto);
        if (createdFavoritePost == null)
        {
            return BadRequest();
        }
        return Ok(createdFavoritePost);
    }
    
    [HttpDelete("{id:Guid}")]
    public async Task<ActionResult> DeletePost([Required]Guid id)
    {
        await _postsService.DeleteFavoritePost(id);
        return NoContent();
    }
}
