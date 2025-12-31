using DatasInformation.Database;
using DatasInformation.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace DatasInformation.Repositary.PostRepositary
{

    public class PostRepo : IPost
    {
        private readonly AppDbContext _context;

        public PostRepo(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public async Task AddAsync(Post post)
        {
            _context.Posts.Add(post);
          await  _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
           var post = await _context.Posts.FirstOrDefaultAsync(u=>u.Id == id);
            if (post != null) {
                _context.Posts.Remove(post);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Post>> GetAllAsync()
        {
        return  await  _context.Posts
                .Include(p=>p.Comments)
                .Include(p=>p.Category)
                .ToListAsync();
        }

        public async Task<Post?> GetByIdAsync(int id)
        {
            var post = await _context.Posts
                .Include(p=>p.Comments)
                .Include(p=>p.Category)
                .FirstOrDefaultAsync(u => u.Id == id);
            return post;
        }

        public async Task UpdateAsync(Post post)
        {
           var existingPost = await _context.Posts.Include(p=>p.Comments).Include(p=>p.Category).FirstOrDefaultAsync(p=>p.Id ==  post.Id);
            if (existingPost == null) {
                return;
            } 
            existingPost.Title = post.Title;
            existingPost.Content = post.Content;
            existingPost.Author = post.Author;
            existingPost.CategoryId = post.CategoryId;
            existingPost.FeatureImagePath = post.FeatureImagePath;

            await _context.SaveChangesAsync();

        }
    }
}
 