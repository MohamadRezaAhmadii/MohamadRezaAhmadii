using Microsoft.EntityFrameworkCore;
using testWebsit.Models;

namespace testWebsit.Data
{
    public class CommentDbContext : DbContext
    {
        public CommentDbContext(DbContextOptions<CommentDbContext> options) : base(options)
        {

        }
        public DbSet<Comments> Comments { get; set; }
    }
}
