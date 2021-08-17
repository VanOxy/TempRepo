using Eonix2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DAO
{
    public class EonixContext : DbContext
    {
        public EonixContext(DbContextOptions<EonixContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite(@"Data Source=okidatabase.db");
        }

        public DbSet<Person> Persons { get; set; }
    }
}