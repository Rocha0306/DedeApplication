using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DedeApplication.DTOs;
using DedeApplication.Entities;
using DedeApplication.Interfaces;
using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;

namespace DedeApplication.UsersCase.Database
{
    public class KeepData : DbContext
    {

        public KeepData(DbContextOptions<KeepData> options) : base(options) {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PatientsDTO>().ToCollection("Patients");
            modelBuilder.Entity<Users>().ToCollection("Users"); 
        }

     

        public DbSet<PatientsDTO> Patients {get;set;} 

        public DbSet<Users> Users {get;set;} 

    }
}