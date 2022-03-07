using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kitap.Models
{
    public class KitapContext :DbContext

    {
        public KitapContext(DbContextOptions<KitapContext> options) : base(options)
        {
        }

        public DbSet<Kitaplar> Courses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kitaplar>().ToTable("Kitaplar");
        }
    }
}
