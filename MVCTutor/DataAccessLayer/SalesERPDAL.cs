using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MVCTutor.Models;

namespace MVCTutor.DataAccessLayer
{
    public class SalesERPDAL : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("TblEmployee");
            modelBuilder.Entity<Departments>().ToTable("Departments");
             
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Departments> Departments { get; set; }

    }

   
}