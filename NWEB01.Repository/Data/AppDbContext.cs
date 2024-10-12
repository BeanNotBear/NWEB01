using Microsoft.EntityFrameworkCore;
using NWEB01.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWEB01.Repository.Data
{
	public class AppDbContext : DbContext
	{

		public DbSet<User> Users { get; set; }
		public DbSet<Appointment> Appointments { get; set; }
		public AppDbContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Appointment>(x =>
			{
				x.ToTable("appointments");
				x.HasKey(x => x.Id);

				x.Property(x => x.PatientId).IsRequired(true);
				x.Property(x => x.DoctorId).IsRequired(true);
				x.Property(x => x.Date).HasColumnType("datetime").HasDefaultValue(DateTime.Now);
				x.Property(x => x.Status).HasColumnType("int").IsRequired(true);
			});

			modelBuilder.Entity<User>(x =>
			{
				x.ToTable("users");
				x.HasKey(x => x.Id);

				x.Property(x => x.Name).HasColumnType("nvarchar").HasMaxLength(255).IsRequired(true);
				x.Property(x => x.Email).HasColumnType("varchar").HasMaxLength(255).IsRequired(true);
				x.Property(x => x.DateOfBirth).HasColumnType("date").IsRequired(false);
				x.Property(x => x.Password).HasColumnType("varchar").HasMaxLength(255).IsRequired(true);
				x.Property(x => x.Role).HasColumnType("int").IsRequired(true);
				x.Property(x => x.Specialization).HasColumnType("nvarchar").HasMaxLength(255).IsRequired();

				x.HasMany(x => x.PatientAppointments)
					.WithOne(x => x.Patient)
					.HasForeignKey(x => x.PatientId)
					.OnDelete(DeleteBehavior.NoAction);

				x.HasMany(x => x.DoctorAppointments)
					.WithOne(x => x.Doctor)
					.HasForeignKey(x => x.DoctorId)
					.OnDelete(DeleteBehavior.NoAction);

				x.Property(x => x.DateOfBirth).HasColumnType("Date").IsRequired(false);
			});
		}
	}
}
