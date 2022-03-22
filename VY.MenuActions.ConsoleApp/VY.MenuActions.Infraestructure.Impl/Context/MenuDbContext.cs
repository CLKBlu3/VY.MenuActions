using Microsoft.EntityFrameworkCore;
using VY.MenuActions.Infraestructure.Contracts.Entities;

namespace VY.MenuActions.Infraestructure.Impl.Context
{
    public class MenuDbContext : DbContext
    {
        public MenuDbContext(DbContextOptions<MenuDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<MenuAction> MenuAction { get; set; }

        /*protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
             
            dbContextOptionsBuilder.UseSqlite(connectionString: "Data Source= MenuPrueba.db",
                sqliteOptionsAction: op =>
                {
                    op.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
                });
            base.OnConfiguring(dbContextOptionsBuilder);
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MenuAction>()
                .HasOne(e => e.ReportsToNavigation)
                .WithMany(p => p.InverseReportsToNavigation)
                .HasForeignKey(d => d.ReportsTo)
                .HasConstraintName("FK_MenuActions_MenuActions")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
