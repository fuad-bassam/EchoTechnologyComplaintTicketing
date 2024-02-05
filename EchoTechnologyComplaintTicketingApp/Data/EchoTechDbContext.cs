using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EchoTechnologyComplaintTicketingApp.Models.Tickets;
using EchoTechnologyComplaintTicketingApp.Models.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace EchoTechnologyComplaintTicketing.Data
{
    public class EchoTechDbContext : IdentityDbContext<UserModel>
    {
        public EchoTechDbContext(DbContextOptions<EchoTechDbContext> options): base(options)
        {
        }
        public DbSet<ComplaintModel> Complaints { get; set; }
        public DbSet<DemandModel> Demands { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1:n
            modelBuilder.Entity<ComplaintModel>()
                .HasMany(c => c.Demands)
                .WithOne(d => d.Complaint)
                .HasForeignKey(d => d.ComplaintId)
                .OnDelete(DeleteBehavior.Cascade);

            // 1:n 
            modelBuilder.Entity<ComplaintModel>()
                .HasOne(c => c.User)
                .WithMany(u => u.Complaints)
                .HasForeignKey(c => c.UserId)
                
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserModel>().HasData(
                new UserModel { Id = "1", NameEn = "Admin", NameAr = "مسؤول النظام", PasswordHash = HashPassword("Aa102030#"), Email = "fuadabuawad55@gmail.com", IsAdminPrivilege = true }
            );
        }

        private static string HashPassword(string password)
        {
            var passwordHasher = new PasswordHasher<UserModel>();
            return passwordHasher.HashPassword(null, password);
        }
    }
}