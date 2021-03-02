using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApplication.Models  {

    // Inherit from DB Context
    public class AppDbContext : DbContext {
        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<Category> Categories { get; set; }


        //default constructor
        public AppDbContext() { }


        protected override void OnConfiguring(DbContextOptionsBuilder builder) {

            if (!builder.IsConfigured) {
                //build connection string fro Sql server
                var connStr = "server=localhost\\sqlexpress;" +
                                "database=AppDbToDo;" +
                                "trusted_connection=true;";
                //pass in connection string
                builder.UseSqlServer(connStr);
            }
        }


        protected override void OnModelCreating(ModelBuilder builder) {



        }

    }
}