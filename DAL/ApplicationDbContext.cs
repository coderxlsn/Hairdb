using Hairdb.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hairdb.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<UtCalander> UtCalander { get; set; }
        public virtual DbSet<UtColors> UtColors { get; set; }
        public virtual DbSet<UtUsers> UtUsers { get; set; }
        public virtual DbSet<UtClient> UtClient { get; set; }
        public virtual DbSet<UtService> UtService { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UtCalander>(entity =>
            {
                entity.HasKey(e => e.EventId)
                    .HasName("PK__ut_Calan__2370F72790F2D6D6");

                entity.ToTable("ut_Calander");

                entity.Property(e => e.EventId)
                    .HasColumnName("event_id")
                    .HasMaxLength(50);

                entity.Property(e => e.AddbyUserId).HasColumnName("addby_user_id");

                entity.Property(e => e.ClientName)
                    .HasColumnName("client_name")
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedDtime)
                    .HasColumnName("created_dtime")
                    .HasColumnType("datetime");

                entity.Property(e => e.EndDtime)
                    .HasColumnName("end_dtime")
                    .HasColumnType("datetime");

                entity.Property(e => e.EventDescription)
                    .HasColumnName("event_description")
                    .HasMaxLength(500);

                entity.Property(e => e.EventName)
                    .HasColumnName("event_name")
                    .HasMaxLength(100);

                entity.Property(e => e.IsLocked).HasColumnName("isLocked");

                entity.Property(e => e.IsSms).HasColumnName("isSms");

                entity.Property(e => e.StartDtime)
                    .HasColumnName("start_dtime")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<UtColors>(entity =>
            {
                entity.ToTable("ut_Colors");

                entity.Property(e => e.Id).HasMaxLength(10);

                entity.Property(e => e.ColorHex)
                    .HasColumnName("color_hex")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<UtUsers>(entity =>
            {
                entity.HasKey(e => new { e.Username, e.Id })
                    .HasName("PK__ut_Users__90FA8BB3C0276880");

                entity.ToTable("ut_Users");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(50);

                entity.Property(e => e.ColorId)
                    .HasColumnName("color_id")
                    .HasMaxLength(10);

                entity.Property(e => e.CompanyName)
                    .HasColumnName("company_name")
                    .HasMaxLength(100);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.FullName)
                    .HasColumnName("full_name")
                    .HasMaxLength(50);

                entity.Property(e => e.UserGroupId)
                    .HasColumnName("user_group_id")
                    .HasMaxLength(50);

                entity.Property(e => e.Userpws)
                    .HasColumnName("userpws")
                    .HasMaxLength(50);
            });

         //   OnModelCreatingPartial(modelBuilder);
        }

       // partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
