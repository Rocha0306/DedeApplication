using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DedeApplication.DTOs;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.EntityFrameworkCore.Extensions;

namespace DedeApplication.FrameworksDrivens
{
    public class MongoDbContext : DbContext {

    public MongoDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<UsersDTO>().ToCollection("Users");
    }

   public DbSet<UsersDTO> Users {get; set;} 
    
    }
}