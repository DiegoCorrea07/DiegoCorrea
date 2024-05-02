using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DiegoCorrea.Models;

namespace DiegoCorrea.Data
{
    public class DiegoCorreaContext : DbContext
    {
        public DiegoCorreaContext (DbContextOptions<DiegoCorreaContext> options)
            : base(options)
        {
        }

        public DbSet<DiegoCorrea.Models.DCorrea> DCorrea { get; set; } = default!;
        public DbSet<DiegoCorrea.Models.Carrera> Carrera { get; set; } = default!;
    }
}
