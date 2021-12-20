using Microsoft.EntityFrameworkCore;
using Sophron.Domain;

namespace Sophron.Infrastructure
{
    public class SophronContext : DbContext
    {
        public SophronContext(DbContextOptions<SophronContext> options)
          : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Customer>(c =>
            {
                c.HasKey(x => x.Id);

                c.Property(x => x.Name).IsRequired();

                c.HasMany<Machine>();

                c.HasMany<Device>();

                c.HasIndex(x => x.Name);

                c.HasIndex(x => x.Email).IsUnique();
            });


            builder.Entity<Device>(d =>
            {
                d.HasKey(x => x.Id);

                d.Property(x => x.Name).IsRequired();

                d.HasIndex(x => x.Name);

                d.HasOne(s => s.Customer)
                               .WithMany(d => d.Devices)
                               .HasForeignKey(c => c.Id)
                               .OnDelete(DeleteBehavior.Cascade)
                               .IsRequired();
            });

            builder.Entity<Machine>(m =>
            {
                m.HasKey(x => x.Id);

                m.Property(x => x.Name).IsRequired();

                m.HasIndex(x => x.Name);

                m.HasOne(s => s.Customer)
                               .WithMany(d => d.Machines)
                               .HasForeignKey(c => c.Id)
                               .OnDelete(DeleteBehavior.Cascade)
                               .IsRequired();

                m.HasOne(s => s.Device)
                              .WithOne(d => d.Machine)
                              .OnDelete(DeleteBehavior.NoAction);
            });

        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<Machine> Machines { get; set; }
    }
}