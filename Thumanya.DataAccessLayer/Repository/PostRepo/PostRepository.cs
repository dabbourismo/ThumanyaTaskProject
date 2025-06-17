using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thumanya.DataAccessLayer.DatabaseEntities;
using Thumanya.Shared.Dtos.PostDtos;

namespace Thumanya.DataAccessLayer.Repository.PostRepo
{
    public class PostRepository : IPostRepository
    {
        private readonly CMSDbContext _context;
        public PostRepository(CMSDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PostDto>> Discovery(string searchTerm, int page, int pageSize)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return await GetAllAsync(page, pageSize);

            return await _context.Posts
                .Where(p => p.Title.Contains(searchTerm) ||
                           p.Description.Contains(searchTerm) ||
                           p.Content.Contains(searchTerm) ||
                           p.Auther.Name.Contains(searchTerm) ||
                           p.Channel.Name.Contains(searchTerm))
                .OrderByDescending(p => p.PublishDate)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(p => new PostDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    Description = p.Description,
                    Content = p.Content,
                    Thumbnail = p.Thumbnail,
                    Cover = p.Cover,
                    AudioUrl = p.AudioUrl,
                    VideoUrl = p.VideoUrl,
                    IsPaidContent = p.IsPaidContent,
                    PublishDate = p.PublishDate,
                    SponsoredBy = p.SponsoredBy,
                    Duration = p.Duration,
                    AuthorId = p.AuthorId,
                    AuthorName = p.Auther.Name,
                    ChannelId = p.ChannelId,
                    ChannelName = p.Channel.Name,
                    ChannelUrl = p.Channel.Url
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<PostDto>> GetAllAsync(int page, int pageSize)
        {
            return await _context.Posts
                .OrderByDescending(p => p.PublishDate)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(p => new PostDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    Description = p.Description,
                    Content = p.Content,
                    Thumbnail = p.Thumbnail,
                    Cover = p.Cover,
                    AudioUrl = p.AudioUrl,
                    VideoUrl = p.VideoUrl,
                    IsPaidContent = p.IsPaidContent,
                    PublishDate = p.PublishDate,
                    SponsoredBy = p.SponsoredBy,
                    Duration = p.Duration,
                    AuthorId = p.AuthorId,
                    AuthorName = p.Auther.Name,
                    ChannelId = p.ChannelId,
                    ChannelName = p.Channel.Name,
                    ChannelUrl = p.Channel.Url
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<PostSummaryDto>> GetAllSummaryAsync()
        {
            return await _context.Posts
                .OrderByDescending(p => p.PublishDate)
                .Select(p => new PostSummaryDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    Description = p.Description,
                    Thumbnail = p.Thumbnail,
                    IsPaidContent = p.IsPaidContent,
                    PublishDate = p.PublishDate,
                    Duration = p.Duration,
                    AuthorName = p.Auther.Name,
                    ChannelName = p.Channel.Name
                })
                .ToListAsync();
        }

        public async Task<PostDto?> GetByIdAsync(int id)
        {
            return await _context.Posts
                .Where(p => p.Id == id)
                .Select(p => new PostDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    Description = p.Description,
                    Content = p.Content,
                    Thumbnail = p.Thumbnail,
                    Cover = p.Cover,
                    AudioUrl = p.AudioUrl,
                    VideoUrl = p.VideoUrl,
                    IsPaidContent = p.IsPaidContent,
                    PublishDate = p.PublishDate,
                    SponsoredBy = p.SponsoredBy,
                    Duration = p.Duration,
                    AuthorId = p.AuthorId,
                    AuthorName = p.Auther.Name,
                    ChannelId = p.ChannelId,
                    ChannelName = p.Channel.Name,
                    ChannelUrl = p.Channel.Url
                })
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<PostDto>> GetByAuthorIdAsync(int authorId)
        {
            return await _context.Posts
                .Where(p => p.AuthorId == authorId)
                .OrderByDescending(p => p.PublishDate)
                .Select(p => new PostDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    Description = p.Description,
                    Content = p.Content,
                    Thumbnail = p.Thumbnail,
                    Cover = p.Cover,
                    AudioUrl = p.AudioUrl,
                    VideoUrl = p.VideoUrl,
                    IsPaidContent = p.IsPaidContent,
                    PublishDate = p.PublishDate,
                    SponsoredBy = p.SponsoredBy,
                    Duration = p.Duration,
                    AuthorId = p.AuthorId,
                    AuthorName = p.Auther.Name,
                    ChannelId = p.ChannelId,
                    ChannelName = p.Channel.Name,
                    ChannelUrl = p.Channel.Url
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<PostDto>> GetByChannelIdAsync(int channelId)
        {
            return await _context.Posts
                .Where(p => p.ChannelId == channelId)
                .OrderByDescending(p => p.PublishDate)
                .Select(p => new PostDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    Description = p.Description,
                    Content = p.Content,
                    Thumbnail = p.Thumbnail,
                    Cover = p.Cover,
                    AudioUrl = p.AudioUrl,
                    VideoUrl = p.VideoUrl,
                    IsPaidContent = p.IsPaidContent,
                    PublishDate = p.PublishDate,
                    SponsoredBy = p.SponsoredBy,
                    Duration = p.Duration,
                    AuthorId = p.AuthorId,
                    AuthorName = p.Auther.Name,
                    ChannelId = p.ChannelId,
                    ChannelName = p.Channel.Name,
                    ChannelUrl = p.Channel.Url
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<PostDto>> GetPublishedPostsAsync()
        {
            return await _context.Posts
                .Where(p => p.PublishDate <= DateTime.UtcNow)
                .OrderByDescending(p => p.PublishDate)
                .Select(p => new PostDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    Description = p.Description,
                    Content = p.Content,
                    Thumbnail = p.Thumbnail,
                    Cover = p.Cover,
                    AudioUrl = p.AudioUrl,
                    VideoUrl = p.VideoUrl,
                    IsPaidContent = p.IsPaidContent,
                    PublishDate = p.PublishDate,
                    SponsoredBy = p.SponsoredBy,
                    Duration = p.Duration,
                    AuthorId = p.AuthorId,
                    AuthorName = p.Auther.Name,
                    ChannelId = p.ChannelId,
                    ChannelName = p.Channel.Name,
                    ChannelUrl = p.Channel.Url
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<PostDto>> GetPaidContentAsync()
        {
            return await _context.Posts
                .Where(p => p.IsPaidContent)
                .OrderByDescending(p => p.PublishDate)
                .Select(p => new PostDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    Description = p.Description,
                    Content = p.Content,
                    Thumbnail = p.Thumbnail,
                    Cover = p.Cover,
                    AudioUrl = p.AudioUrl,
                    VideoUrl = p.VideoUrl,
                    IsPaidContent = p.IsPaidContent,
                    PublishDate = p.PublishDate,
                    SponsoredBy = p.SponsoredBy,
                    Duration = p.Duration,
                    AuthorId = p.AuthorId,
                    AuthorName = p.Auther.Name,
                    ChannelId = p.ChannelId,
                    ChannelName = p.Channel.Name,
                    ChannelUrl = p.Channel.Url
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<PostDto>> GetPostsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Posts
                .Where(p => p.PublishDate >= startDate && p.PublishDate <= endDate)
                .OrderByDescending(p => p.PublishDate)
                .Select(p => new PostDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    Description = p.Description,
                    Content = p.Content,
                    Thumbnail = p.Thumbnail,
                    Cover = p.Cover,
                    AudioUrl = p.AudioUrl,
                    VideoUrl = p.VideoUrl,
                    IsPaidContent = p.IsPaidContent,
                    PublishDate = p.PublishDate,
                    SponsoredBy = p.SponsoredBy,
                    Duration = p.Duration,
                    AuthorId = p.AuthorId,
                    AuthorName = p.Auther.Name,
                    ChannelId = p.ChannelId,
                    ChannelName = p.Channel.Name,
                    ChannelUrl = p.Channel.Url
                })
                .ToListAsync();
        }

        public async Task<PostDto> CreateAsync(PostCreateDto createDto)
        {
            if (createDto == null)
                throw new ArgumentNullException(nameof(createDto));

            // Validate foreign keys
            //await ValidateAuthorAndChannelAsync(createDto.AuthorId, createDto.ChannelId);

            var post = new Post
            {
                Title = createDto.Title,
                Description = createDto.Description,
                Content = createDto.Content,
                Thumbnail = createDto.Thumbnail,
                Cover = createDto.Cover,
                AudioUrl = createDto.AudioUrl,
                VideoUrl = createDto.VideoUrl,
                IsPaidContent = createDto.IsPaidContent,
                PublishDate = createDto.PublishDate ?? DateTime.UtcNow,
                SponsoredBy = createDto.SponsoredBy,
                Duration = createDto.Duration,
                AuthorId = createDto.AuthorId,
                ChannelId = createDto.ChannelId
            };

            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            // Return the created post with navigation properties
            return await _context.Posts
                .Where(p => p.Id == post.Id)
                .Select(p => new PostDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    Description = p.Description,
                    Content = p.Content,
                    Thumbnail = p.Thumbnail,
                    Cover = p.Cover,
                    AudioUrl = p.AudioUrl,
                    VideoUrl = p.VideoUrl,
                    IsPaidContent = p.IsPaidContent,
                    PublishDate = p.PublishDate,
                    SponsoredBy = p.SponsoredBy,
                    Duration = p.Duration,
                    AuthorId = p.AuthorId,
                    AuthorName = p.Auther.Name,
                    ChannelId = p.ChannelId,
                    ChannelName = p.Channel.Name,
                    ChannelUrl = p.Channel.Url
                })
                .FirstAsync();
        }

        public async Task<PostDto?> UpdateAsync(int id, PostUpdateDto updateDto)
        {
            if (updateDto == null)
                throw new ArgumentNullException(nameof(updateDto));

            var existingPost = await _context.Posts.FindAsync(id);
            if (existingPost == null)
                return null;

            // Validate foreign keys
            await ValidateAuthorAndChannelAsync(updateDto.AuthorId, updateDto.ChannelId);

            // Update properties
            existingPost.Title = updateDto.Title;
            existingPost.Description = updateDto.Description;
            existingPost.Content = updateDto.Content;
            existingPost.Thumbnail = updateDto.Thumbnail;
            existingPost.Cover = updateDto.Cover;
            existingPost.AudioUrl = updateDto.AudioUrl;
            existingPost.VideoUrl = updateDto.VideoUrl;
            existingPost.IsPaidContent = updateDto.IsPaidContent;
            existingPost.PublishDate = updateDto.PublishDate;
            existingPost.SponsoredBy = updateDto.SponsoredBy;
            existingPost.Duration = updateDto.Duration;
            existingPost.AuthorId = updateDto.AuthorId;
            existingPost.ChannelId = updateDto.ChannelId;

            _context.Entry(existingPost).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            // Return the updated post with navigation properties
            return await _context.Posts
                .Where(p => p.Id == id)
                .Select(p => new PostDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    Description = p.Description,
                    Content = p.Content,
                    Thumbnail = p.Thumbnail,
                    Cover = p.Cover,
                    AudioUrl = p.AudioUrl,
                    VideoUrl = p.VideoUrl,
                    IsPaidContent = p.IsPaidContent,
                    PublishDate = p.PublishDate,
                    SponsoredBy = p.SponsoredBy,
                    Duration = p.Duration,
                    AuthorId = p.AuthorId,
                    AuthorName = p.Auther.Name,
                    ChannelId = p.ChannelId,
                    ChannelName = p.Channel.Name,
                    ChannelUrl = p.Channel.Url
                })
                .FirstAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
                return false;

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Posts.AnyAsync(p => p.Id == id);
        }

        public async Task<int> CountAsync()
        {
            return await _context.Posts.CountAsync();
        }



        private async Task ValidateAuthorAndChannelAsync(int authorId, int channelId)
        {
            var authorExists = await _context.Authers.AnyAsync(a => a.Id == authorId);
            if (!authorExists)
                throw new ArgumentException($"Author with ID {authorId} does not exist.");

            var channelExists = await _context.Channels.AnyAsync(c => c.Id == channelId);
            if (!channelExists)
                throw new ArgumentException($"Channel with ID {channelId} does not exist.");
        }
    }
}
