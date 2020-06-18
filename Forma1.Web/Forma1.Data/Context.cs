using Forma1.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Forma1.Data
{
    public class Context: DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Team> Teams { get; set; }
    }
}
