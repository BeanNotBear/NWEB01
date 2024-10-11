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
			});

			modelBuilder.Entity<User>(x =>
			{
				x.ToTable("users");
				x.HasKey(x => x.Id);

				x.HasMany(x => x.PatientAppointments)
					.WithOne(x => x.Patient)
					.HasForeignKey(x => x.PatientId)
					.OnDelete(DeleteBehavior.Cascade);

				x.HasMany(x => x.DoctorAppointments)
					.WithOne(x => x.Doctor)
					.HasForeignKey(x => x.DoctorId)
					.OnDelete(DeleteBehavior.Cascade);

				x.Property(x => x.DateOfBirth).HasColumnType("Date").IsRequired(false);
			});
		}
	}
}
