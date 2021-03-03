using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test_PagedList_Dino
{
    class PagedListDataContext : DbContext
    {
        public DbSet<Helper> Helper { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=45.119.83.234;Initial Catalog=PagedList;Persist Security Info=True;User ID=thanhthuan1908;Password=thanhthuan1908");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
