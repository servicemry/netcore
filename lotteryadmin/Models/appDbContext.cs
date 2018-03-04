using System;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
namespace lotteryadmin.Models{
    public class appDbContext:DbContext{
        public appDbContext(DbContextOptions<appDbContext> op) : base(op){}
        public DbSet<Manager> Manager{get;set;}//管理员
        public DbSet<CPType> CPType{get;set;}//彩种
    }
}