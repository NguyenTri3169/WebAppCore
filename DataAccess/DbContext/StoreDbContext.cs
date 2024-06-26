﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DTO;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DbContext
{
    public class StoreDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {

        }   
        public DbSet<Category> Categories { get; set; }
        public DbSet<CongDung> CongDungs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Function> function { get; set; }
        public DbSet<UserFunction> userfunction { get; set; }
    }
}
