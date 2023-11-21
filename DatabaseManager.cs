using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
public class DatabaseManager : IdentityDbContext<IdentityUser>

{
    public DbSet<Member> Members { get; set; }
    public DbSet<Article> Articles { get; set; }
    public DbSet<Competition> Competitions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=lan-week.db");
}
