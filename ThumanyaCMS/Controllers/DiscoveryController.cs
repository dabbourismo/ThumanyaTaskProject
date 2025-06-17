using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Thumanya.BusinessLayer.PostBusiness;
using Thumanya.Shared.Dtos.PostDtos;

namespace ThumanyaCMS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class DiscoveryController : ControllerBase
    {
        private readonly IPostService _postService;
        public DiscoveryController(IPostService postService)
        {
            _postService = postService;
        }

        /// <summary>
        /// Search posts by term: title, description, content, author name, or channel name
        /// </summary>
        /// <param name="searchTerm">Search term to look for in title, description, content, author name, or channel name</param>
        /// 
        [HttpGet("Discovery")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<PostDto>>> Discovery(
            [FromQuery] string searchTerm,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10)
        {
            var posts = await _postService.Discovery(searchTerm, page, pageSize);
            return Ok(posts);
        }


        /// <summary>
        /// Get all posts summary (lightweight version)
        /// </summary>
        [HttpGet("summary")]
        public async Task<ActionResult<IEnumerable<PostSummaryDto>>> GetAllSummary()
        {
            var summaries = await _postService.GetAllSummaryAsync();
            return Ok(summaries);
        }

        /// <summary>
        /// Get posts by author ID
        /// </summary>
        /// <param name="authorId">Author ID</param>
        [HttpGet("author/{authorId}")]
        public async Task<ActionResult<IEnumerable<PostDto>>> GetByAuthor(int authorId)
        {
            try
            {
                var posts = await _postService.GetByAuthorIdAsync(authorId);
                return Ok(posts);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Get posts by channel ID
        /// </summary>
        /// <param name="channelId">Channel ID</param>
        [HttpGet("channel/{channelId}")]
        public async Task<ActionResult<IEnumerable<PostDto>>> GetByChannel(int channelId)
        {
            try
            {
                var posts = await _postService.GetByChannelIdAsync(channelId);
                return Ok(posts);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Get post by ID
        /// </summary>
        /// <param name="id">Post ID</param>
        [HttpGet("{id}")]
        public async Task<ActionResult<PostDto>> GetById(int id)
        {
            try
            {
                var post = await _postService.GetByIdAsync(id);
                return Ok(post);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpGet("big-data")]
        [AllowAnonymous]
        public IActionResult BigData()
        {
            var data = string.Join(" ", Enumerable.Repeat("This is test data.", 1000));
            return Ok(new { data });
        }

    }
}
