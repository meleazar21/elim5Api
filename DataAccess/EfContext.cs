using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    /// <summary>
    /// Context for the project
    /// </summary>
    /// <remarks>Autor: Eleazar Martinez</remarks>
    public class EfContext : DbContext
    {
        /// <summary>
        /// DBset for the UserLog entity
        /// </summary>
        public virtual DbSet<UserLog> UserLogs { get; set; }

        /// <summary>
        /// Overriding de OnConfiguring Method
        /// </summary>
        /// <param name="options">options</param>
        /// <remarks>Autor: Eleazar Martinez</remarks>
        protected override void OnConfiguring(DbContextOptionsBuilder options)
      => options.UseMySQL("Server=elim5.mysql.database.azure.com; Port=3306; Database=elim5db; Uid=elim5@elim5; Pwd=Sistema123; SslMode=Preferred;");


        /// <summary>
        /// Method for specify the entity constraints
        /// </summary>
        /// <param name="modelBuilder">model builder</param>
        /// <remarks>Autor: Eleazar Martinez</remarks>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserLog>(entity =>
            {
                entity.HasKey(c => c.id);
            });
        }
    }
}
