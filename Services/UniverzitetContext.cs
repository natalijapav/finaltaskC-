using APISystem.Entity;
using APSystem.Entity;
using Microsoft.EntityFrameworkCore;

namespace UniAPISystem.Services
{
    public class UniverzitetContext : DbContext
    {
        public DbSet<Departmant> Departmanti { get; set; }
        public DbSet<Finansije> Finansiranje { get; set; }

        public DbSet<Osoba> Osobe { get; set; }
        public DbSet<Student> Studenti { get; set; }

        public DbSet<Profesor> Profesori { get; set; }
        public DbSet<Predmet> Predmeti { get; set; }
        public DbSet<Korisnik> Korisnici { get; set; }
        public DbSet<Uloga> Uloge { get; set; }
        public DbSet<Ocena> Ocene { get; set; }
        public object Departmant { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-MU34NUK\\MSSQLSERVER01;Database=Univerzitet;Trusted_Connection=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {

            modelBuilder.Entity<Profesor>().ToTable("Profesori");

            modelBuilder.Entity<Student>().ToTable("Studenti");

            modelBuilder.Entity<Profesor>().HasOne(p => p.Departmant).WithMany(d => d.Profesori).HasForeignKey(p => p.DepartmantId).OnDelete(DeleteBehavior.Restrict);



            modelBuilder.Entity<Departmant>()

                .HasMany(d => d.Profesori)

                .WithOne()

                .HasForeignKey("DepartmanId");


            modelBuilder.Entity<Predmet>()

                .HasOne(p => p.Profesor)

                .WithMany(prof => prof.Predmeti)

                .HasForeignKey(p => p.ProfesorId)

                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Predmet>()

                .HasMany(p => p.Studenti)

                .WithMany(s => s.Predmeti)

                .UsingEntity(j => j.ToTable("StudentPredmet"));

            modelBuilder.Entity<Korisnik>()

                .HasOne(k => k.UlogaKorisnik)

                .WithMany()

                .HasForeignKey("UlogaId");

            modelBuilder.Entity<Korisnik>()

                .Property(k => k.Lozinka)

                .HasMaxLength(255);

            modelBuilder.Entity<Korisnik>()

                .HasIndex(k => k.KorisnickoIme)

                .IsUnique();

            modelBuilder.Entity<Osoba>()

                .Property(o => o.GodinaRodjenja)

                .HasConversion(

                    v => v.ToDateTime(TimeOnly.MinValue),

                    v => DateOnly.FromDateTime(v)

                );



            modelBuilder.Entity<Finansije>()

                .ToTable("Finansiranja")

                .HasKey(f => f.FinId);

        }




    }
}
