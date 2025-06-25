using ExpressVoitures.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Projet_5.Models.Entities;

namespace Projet_5.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Car> Car { get; set; }
    public DbSet<Brand> Brand { get; set; }
    public DbSet<CarImage> CarImage { get; set; }
    public DbSet<Model> Model { get; set; }
    public DbSet<Repair> Repair { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=(localdb)\\mssqllocaldb;Database=Projet5;Trusted_Connection=True;MultipleActiveResultSets=true"
        );
    }

}
