
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wholesaleStore.Core.Models;

namespace wholesaleStore.Storage
{
  
    public class wholesaleStoreDBContext : DbContext
    {
        public wholesaleStoreDBContext(DbContextOptions<wholesaleStoreDBContext> options) : base(options)
        {

        }

        
        public DbSet<User> Users { get; set; }
        public DbSet<Enterprice> Enterprices { get; set; }
        public DbSet<Addresses> Addresses { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Goods> Goods { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<FieldActivity> FieldActivitys { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
     
        
    }
}
