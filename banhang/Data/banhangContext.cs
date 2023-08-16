using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using banhang.Models;

namespace banhang.Data
{
    public class banhangContext : DbContext
    {
        public banhangContext (DbContextOptions<banhangContext> options)
            : base(options)
        {
        }

        public DbSet<banhang.Models.sanpham> sanpham { get; set; } = default!;

        public DbSet<banhang.Models.Category>? Category { get; set; }

        public DbSet<banhang.Models.User>? User { get; set; }
    }
}
