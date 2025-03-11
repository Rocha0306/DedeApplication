using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DedeApplication.DTOs;
using DedeApplication.Entities;
using DedeApplication.Interfaces;
using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;

namespace DedeApplication.UsersCase.Database
{
    public class UserCaseKeepData : DbContext
    {

        public UserCaseKeepData(DbContextOptions<UserCaseKeepData> options) : base(options) {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PatientsEntity>().ToCollection("Patients");
            modelBuilder.Entity<UsersEntity>().ToCollection("Users");
        }

     

        public DbSet<PatientsEntity> Patients {get;set;} 

        public DbSet<UsersEntity> Users {get;set;} 

    }
}