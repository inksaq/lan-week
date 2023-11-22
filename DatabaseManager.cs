using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
public class DatabaseManager : IdentityDbContext<IdentityUser>

{   public DbSet<NewsArticle> NewsArticles { get; set; }
    public DbSet<LanCompetition> LanCompetitions { get; set; }
    public DbSet<TeamMember> TeamMembers { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=lan-week.db");
}
