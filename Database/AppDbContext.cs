using api_personal.Entities;
using Microsoft.EntityFrameworkCore;

namespace api_personal.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<PersonalEntity> Personal { get; set; }
        public DbSet<AcademiaEntity> Academia { get; set; }
        public DbSet<AcademiaPersonalEntity> AcademiaPersonal { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AcademiaEntity>()
                .HasKey(a => a.Aca_id);

            modelBuilder.Entity<PersonalEntity>()
                .HasKey(p => p.Per_id);

            modelBuilder.Entity<AcademiaPersonalEntity>()
                .HasKey(ap => ap.Acp_id);

            // Relacionamento AcademiaPersonal -> Academia
            modelBuilder.Entity<AcademiaPersonalEntity>()
                .HasOne(ap => ap.Academia) // AcademiaPersonal tem uma Academia
                .WithMany(a => a.AcademiaPersonals) // Uma Academia tem muitos AcademiaPersonals
                .HasForeignKey(ap => ap.Acp_aca_id); // Define a chave estrangeira

            // Relacionamento AcademiaPersonal -> Personal
            modelBuilder.Entity<AcademiaPersonalEntity>()
                .HasOne(ap => ap.Personal) // AcademiaPersonal tem um Personal
                .WithMany(p => p.AcademiaPersonals) // Um Personal tem muitos AcademiaPersonals
                .HasForeignKey(ap => ap.Acp_per_id); // Define a chave estrangeira

            modelBuilder.Entity<AcademiaPersonalEntity>()
                .Property(a => a.Acp_valor)
                .HasColumnType("numeric(10,2)");
        }
    }
}
