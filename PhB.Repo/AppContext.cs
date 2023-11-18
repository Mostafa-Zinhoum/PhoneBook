using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PhB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhB.Repo
{
    public class AppContext : IdentityDbContext
    {
        public AppContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=DESKTOP-M8GBBLK\\SQLEX14;Database=phbDB;User Id=sa;Password=0;");
        }

        public DbSet<Job> Jobs { get; set; }
        public DbSet<PhoneBook> PhoneBooks { get; set; }
        public DbSet<PhoneBook_Image> PhoneBook_Images { get; set; }
        public DbSet<Governorate> Governorates { get; set; }
        public DbSet<Center> Centers { get; set; }
    }
}
