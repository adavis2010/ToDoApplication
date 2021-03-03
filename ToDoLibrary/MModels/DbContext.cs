using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoApplication;

namespace ToDoLib.Models {

    // Inherit from DB Context
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext {
        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<Category> Categories { get; set; }


        //default constructor
        public DbContext() { }


        protected override void OnConfiguring(DbContextOptionsBuilder builder) {

            if (!builder.IsConfigured) {
                //build connection string for Sql server
                var connStr = "server=localhost\\sqlexpress;" +
                                "database=ToDo;" +
                                "trusted_connection=true;";
                //pass in connection string
                builder.UseSqlServer(connStr);
            }
        }


        protected override void OnModelCreating(ModelBuilder builder) { 
        
        }

    }


}
