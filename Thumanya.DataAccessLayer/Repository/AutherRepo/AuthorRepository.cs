using Microsoft.EntityFrameworkCore;
using Thumanya.DataAccessLayer.DatabaseEntities;
using Thumanya.Shared.Dtos.AutherDtos;

namespace Thumanya.DataAccessLayer.Repository.AutherRepo
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly CMSDbContext _context;

        public AuthorRepository(CMSDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AuthorDto>> GetAllAsync()
        {
            return await _context.Authers
                .Select(a => new AuthorDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    ProfileUrl = a.ProfileUrl,
                    ProfileImage = a.ProfileImage
                })
                .ToListAsync();
        }

        public async Task<AuthorDto> GetByIdAsync(int id)
        {
            return await _context.Authers
                .Where(a => a.Id == id)
                .Select(a => new AuthorDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    ProfileUrl = a.ProfileUrl,
                    ProfileImage = a.ProfileImage
                })
                .FirstOrDefaultAsync();
        }

        public async Task<AuthorDto> CreateAsync(CreateAuthorDto createAuthorDto)
        {
            var author = new Auther
            {
                Name = createAuthorDto.Name,
                ProfileUrl = createAuthorDto.ProfileUrl,
                ProfileImage = createAuthorDto.ProfileImage
            };

            _context.Authers.Add(author);
            await _context.SaveChangesAsync();

            return new AuthorDto
            {
                Id = author.Id,
                Name = author.Name,
                ProfileUrl = author.ProfileUrl,
                ProfileImage = author.ProfileImage
            };
        }

        public async Task<AuthorDto> UpdateAsync(int id, UpdateAuthorDto updateAuthorDto)
        {
            var author = await _context.Authers.FindAsync(id);

            if (author == null)
                return null;

            author.Name = updateAuthorDto.Name;
            author.ProfileUrl = updateAuthorDto.ProfileUrl;
            author.ProfileImage = updateAuthorDto.ProfileImage;

            await _context.SaveChangesAsync();

            return new AuthorDto
            {
                Id = author.Id,
                Name = author.Name,
                ProfileUrl = author.ProfileUrl,
                ProfileImage = author.ProfileImage
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var author = await _context.Authers.FindAsync(id);

            if (author == null)
                return false;

            _context.Authers.Remove(author);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Authers.AnyAsync(a => a.Id == id);
        }

    }
}
