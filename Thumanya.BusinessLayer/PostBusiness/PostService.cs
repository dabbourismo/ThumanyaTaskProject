using Microsoft.Extensions.Caching.Memory;
using Thumanya.DataAccessLayer.DatabaseEntities;
using Thumanya.DataAccessLayer.Repository.PostRepo;
using Thumanya.Shared.Dtos.PostDtos;
using static System.Formats.Asn1.AsnWriter;

namespace Thumanya.BusinessLayer.PostBusiness
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IMemoryCache _cache;
        private const string CACHE_KEY_PREFIX = "posts_search_";
        private readonly MemoryCacheEntryOptions _cacheOptions;

        public PostService(IPostRepository postRepository, IMemoryCache cache)
        {
            _postRepository = postRepository;
            _cache = cache;

            _cacheOptions = new MemoryCacheEntryOptions()
           .SetSlidingExpiration(TimeSpan.FromMinutes(5))  // Expires if not accessed for 5 minutes
           .SetAbsoluteExpiration(TimeSpan.FromMinutes(15)); // Absolute expiration after 15 minutes

        }

        public async Task<IEnumerable<PostDto>> Discovery(string searchTerm, int page, int pageSize)
        {
            // Create a unique cache key based on search parameters
            var cacheKey = $"{CACHE_KEY_PREFIX}{searchTerm ?? "all"}_{page}_{pageSize}";

            // Try to get from cache
            if (_cache.TryGetValue<IEnumerable<PostDto>>(cacheKey, out var cachedPosts))
            {
                return cachedPosts;
            }

            // If not in cache, get from repository
            var posts = await _postRepository.Discovery(searchTerm, page, pageSize);

            // Store in cache
            _cache.Set(cacheKey, posts, _cacheOptions);

            return posts;
        }

        public void ClearSearchCache()
        {
            // This is a simple approach
            _cache.Remove(CACHE_KEY_PREFIX);
        }

        public async Task<IEnumerable<PostDto>> GetAllAsync(int page, int pageSize)
        {
            return await _postRepository.GetAllAsync(page, pageSize);
        }

        public async Task<IEnumerable<PostSummaryDto>> GetAllSummaryAsync()
        {
            return await _postRepository.GetAllSummaryAsync();
        }

        public async Task<PostDto> GetByIdAsync(int id)
        {
            // Create a unique cache key based on search parameters
            var cacheKey = $"{CACHE_KEY_PREFIX}{id}";

            // Try to get from cache
            if (_cache.TryGetValue<PostDto>(cacheKey, out var cachedPost))
            {
                return cachedPost;
            }

            var post = await _postRepository.GetByIdAsync(id);


            if (post == null)
            {
                throw new KeyNotFoundException($"Post with ID {id} not found.");
            }

            // Store in cache
            _cache.Set(cacheKey, post, _cacheOptions);

            return post;
        }

        public async Task<IEnumerable<PostDto>> GetByAuthorIdAsync(int authorId)
        {          
            if (authorId <= 0)
            {
                throw new ArgumentException("Author ID must be greater than 0.", nameof(authorId));
            }
            // Create a unique cache key based on search parameters
            var cacheKey = $"{CACHE_KEY_PREFIX}{authorId}";

            // Try to get from cache
            if (_cache.TryGetValue<IEnumerable<PostDto>>(cacheKey, out var cachedPosts))
            {
                return cachedPosts;
            }

           var posts = await _postRepository.GetByAuthorIdAsync(authorId);

            // Store in cache
            _cache.Set(cacheKey, posts, _cacheOptions);

            return posts;
        }

        public async Task<IEnumerable<PostDto>> GetByChannelIdAsync(int channelId)
        {
            if (channelId <= 0)
            {
                throw new ArgumentException("Channel ID must be greater than 0.", nameof(channelId));
            }

            // Create a unique cache key based on search parameters
            var cacheKey = $"{CACHE_KEY_PREFIX}{channelId}";

            // Try to get from cache
            if (_cache.TryGetValue<IEnumerable<PostDto>>(cacheKey, out var cachedPosts))
            {
                return cachedPosts;
            }

            var posts =  await _postRepository.GetByChannelIdAsync(channelId);

            // Store in cache
            _cache.Set(cacheKey, posts, _cacheOptions);

            return posts;
        }

        public async Task<IEnumerable<PostDto>> GetPublishedPostsAsync()
        {
            return await _postRepository.GetPublishedPostsAsync();
        }

        public async Task<IEnumerable<PostDto>> GetPaidContentAsync()
        {
            return await _postRepository.GetPaidContentAsync();
        }

        public async Task<IEnumerable<PostDto>> GetPostsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
            {
                throw new ArgumentException("Start date must be before or equal to end date.");
            }

            // Ensure dates are in UTC
            if (startDate.Kind != DateTimeKind.Utc)
            {
                startDate = DateTime.SpecifyKind(startDate, DateTimeKind.Utc);
            }
            if (endDate.Kind != DateTimeKind.Utc)
            {
                endDate = DateTime.SpecifyKind(endDate, DateTimeKind.Utc);
            }

            return await _postRepository.GetPostsByDateRangeAsync(startDate, endDate);
        }

        public async Task<PostDto> CreateAsync(PostCreateDto createDto)
        {
            if (createDto == null)
            {
                throw new ArgumentNullException(nameof(createDto));
            }

            // Validate required fields
            if (string.IsNullOrWhiteSpace(createDto.Title))
            {
                throw new ArgumentException("Post title is required.", nameof(createDto.Title));
            }

            if (createDto.AuthorId <= 0)
            {
                throw new ArgumentException("Valid Author ID is required.", nameof(createDto.AuthorId));
            }

            if (createDto.ChannelId <= 0)
            {
                throw new ArgumentException("Valid Channel ID is required.", nameof(createDto.ChannelId));
            }

            if (!createDto.PublishDate.HasValue)
            {
                createDto.PublishDate = DateTime.UtcNow;
            }

            var post = await _postRepository.CreateAsync(createDto);
            ClearSearchCache();
            return post;
        }

        public async Task<PostDto> UpdateAsync(int id, PostUpdateDto updateDto)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Post ID must be greater than 0.", nameof(id));
            }

            if (updateDto == null)
            {
                throw new ArgumentNullException(nameof(updateDto));
            }

            // Validate required fields
            if (string.IsNullOrWhiteSpace(updateDto.Title))
            {
                throw new ArgumentException("Post title is required.", nameof(updateDto.Title));
            }

            if (updateDto.AuthorId <= 0)
            {
                throw new ArgumentException("Valid Author ID is required.", nameof(updateDto.AuthorId));
            }

            if (updateDto.ChannelId <= 0)
            {
                throw new ArgumentException("Valid Channel ID is required.", nameof(updateDto.ChannelId));
            }

            var updatedPost = await _postRepository.UpdateAsync(id, updateDto);
            if (updatedPost == null)
            {
                throw new KeyNotFoundException($"Post with ID {id} not found.");
            }

            return updatedPost;
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Post ID must be greater than 0.", nameof(id));
            }

            var deleted = await _postRepository.DeleteAsync(id);
            if (!deleted)
            {
                throw new KeyNotFoundException($"Post with ID {id} not found.");
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            if (id <= 0)
            {
                return false;
            }
            return await _postRepository.ExistsAsync(id);
        }

        public async Task<int> CountAsync()
        {
            return await _postRepository.CountAsync();
        }
    }
}
