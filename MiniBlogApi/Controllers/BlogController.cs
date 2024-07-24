using Blog.Business.Services.Interfaces;
using Blog.Core.DTOS.Blog;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class BlogController : ControllerBase
{
    private readonly IBlogService _blogService;

    public BlogController(IBlogService blogService)
    {
        _blogService = blogService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] BlogCreateDto dto)
    {
        var result = await _blogService.CreateAsync(dto);
        if (result.Success)
        {
            return Ok(result.Message);
        }
        return BadRequest(result.Message);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 6)
    {
        var result = await _blogService.GetAllAsync(pageNumber, pageSize);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(int id)
    {
        var result = await _blogService.GetAsync(id);
        if (result.Success)
        {
            return Ok(result.Data);
        }
        return NotFound(result.Message);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveAsync(int id)
    {
        var result = await _blogService.RemoveAsync(id);
        if (result.Success)
        {
            return NoContent();
        }
        return NotFound(result.Message);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] BlogUpdateDto dto)
    {
        var result = await _blogService.UpdateAsync(id, dto);
        if (result.Success)
        {
            return NoContent();
        }
        return NotFound(result.Message);
    }

    [HttpGet("recent")]
    public async Task<IActionResult> GetRecentAsync([FromQuery] int count = 5)
    {
        var result = await _blogService.GetRecentAsync(count);
        if (result.Success)
        {
            return Ok(result.Data);
        }
        return NotFound(result.Message);
    }
}
