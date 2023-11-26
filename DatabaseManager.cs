using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
public class DatabaseManager : IdentityDbContext<IdentityUser>

{   public DbSet<NewsArticle> NewsArticles { get; set; }

    public DbSet<Competition> Competitions { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=lan-week.db");
}
