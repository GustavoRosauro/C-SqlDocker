using Microsoft.EntityFrameworkCore;
using SqlDockerContainer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlDockerContainer.Data
{
    public class PersonDbContext:DbContext
    {
        public DbSet<Person> Person {  get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=DockerDb;User Id=SA;Password=mypassword");
        }
    }
}
