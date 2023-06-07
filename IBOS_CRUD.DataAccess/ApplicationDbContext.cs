using IBOS_CRUD.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBOS_CRUD.DataAccess
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasAlternateKey(c => c.EmployeeCode)
                .HasName("AlternateKey_EmployeeCode");
        }*/

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmpAttendeance> EmpAttendeances { get; set; }



    }
}
