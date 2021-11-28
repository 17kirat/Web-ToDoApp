using Microsoft.EntityFrameworkCore;
using ToDoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.Data
{
    public class EFContext : DbContext
    {
        public DbSet<ToDos> ToDos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ToDoDB;Integrated Security=true;");
        }
    }
} 
