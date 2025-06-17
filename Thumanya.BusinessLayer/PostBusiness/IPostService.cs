using Thumanya.Shared.Dtos.PostDtos;

namespace Thumanya.BusinessLayer.PostBusiness
{
    public interface IPostService
    {
        Task<IEnumerable<PostDto>> Discovery(string searchTerm, int page, int pageSize);
        Task<IEnumerable<PostDto>> GetAllAsync(int page, int pageSize);
        Task<IEnumerable<PostSummaryDto>> GetAllSummaryAsync();
        Task<PostDto> GetByIdAsync(int id);
        Task<IEnumerable<PostDto>> GetByAuthorIdAsync(int authorId);
        Task<IEnumerable<PostDto>> GetByChannelIdAsync(int channelId);
        Task<IEnumerable<PostDto>> GetPublishedPostsAsync();
        Task<IEnumerable<PostDto>> GetPaidContentAsync();
        Task<IEnumerable<PostDto>> GetPostsByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<PostDto> CreateAsync(PostCreateDto createDto);
        Task<PostDto> UpdateAsync(int id, PostUpdateDto updateDto);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<int> CountAsync();
    }
}
