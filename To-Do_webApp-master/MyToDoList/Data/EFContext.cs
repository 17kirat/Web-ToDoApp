using Microsoft.EntityFrameworkCore;
using MyToDoList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDoList.Data
{
    public class EFContext : DbContext
    {
        public DbSet<ToDos> ToDos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=MyToDo;Integrated Security=true;");
            //builder.UseSqlite(@"Data Source=c:\Temp\mydb/db");
        }
    }
} 
