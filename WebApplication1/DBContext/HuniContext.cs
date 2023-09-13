using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.DBContext
{
    public class HuniContext : DbContext
    {
        public HuniContext(DbContextOptions<HuniContext> options)
            : base(options)
        {
        }
        public DbSet<Person> Persons { get; set; }
    }
}
