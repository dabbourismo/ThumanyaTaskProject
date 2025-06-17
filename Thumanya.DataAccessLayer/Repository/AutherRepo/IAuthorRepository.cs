using Thumanya.Shared.Dtos.AutherDtos;

namespace Thumanya.DataAccessLayer.Repository.AutherRepo
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<AuthorDto>> GetAllAsync();
        Task<AuthorDto> GetByIdAsync(int id);
        Task<AuthorDto> CreateAsync(CreateAuthorDto createAuthorDto);
        Task<AuthorDto> UpdateAsync(int id, UpdateAuthorDto updateAuthorDto);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
