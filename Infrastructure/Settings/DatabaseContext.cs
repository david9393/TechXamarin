using CommonShared.DTO.Tips;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Xamarin.Essentials;

namespace Infrastructure.Settings
{
    public class DatabaseContext : DbContext
    {
        public DbSet<TipModel> Tip { get; set; }
        private readonly string _databasePath;
      
        public DatabaseContext(string databasePath)
        {
            _databasePath = databasePath;
            SQLitePCL.Batteries_V2.Init();

            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_databasePath}");
        }
    }
}
