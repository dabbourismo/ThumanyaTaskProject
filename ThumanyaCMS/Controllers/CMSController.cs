using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Thumanya.BusinessLayer.PostBusiness;
using Thumanya.Shared.Dtos.PostDtos;

namespace ThumanyaCMS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class CMSController : ControllerBase
    {
        private readonly IPostService _postService;

        public CMSController(IPostService postService)
        {
            _postService = postService;
        }


        /// <summary>
        /// Create a new post
        /// </summary>
        /// <param name="createDto">Post creation data</param>
        [HttpPost]
        public async Task<ActionResult<PostDto>> Create([FromBody] PostCreateDto createDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var createdPost = await _postService.CreateAsync(createDto);
                return CreatedAtAction(nameof(GetById), new { id = createdPost.Id }, createdPost);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                // Log the exception here
                return StatusCode(500, ex.Message);
            }
        }



        /// <summary>
        /// Update an existing post
        /// </summary>
        /// <param name="id">Post ID</param>
        /// <param name="updateDto">Post update data</param>
        [HttpPut("{id}")]
        public async Task<ActionResult<PostDto>> Update(int id, [FromBody] PostUpdateDto updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var updatedPost = await _postService.UpdateAsync(id, updateDto);
                return Ok(updatedPost);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                // Log the exception here
                return StatusCode(500, "An error occurred while updating the post.");
            }
        }


        /// <summary>
        /// Get all posts
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostDto>>> GetAll(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10)
        {
            var posts = await _postService.GetAllAsync(page,pageSize);
            return Ok(posts);
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


       
    }
}
