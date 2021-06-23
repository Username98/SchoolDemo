using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SchoolDemo.Models
{
    public class SchoolContext:DbContext
    {
        public DbSet<Class> Classes{ get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Pupil> Pupils { get; set; }
        public DbSet<EmployeeAndClass> EmployeeAndClasses { get; set; }
    }
}