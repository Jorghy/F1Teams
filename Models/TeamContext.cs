using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace F1TestApp.Models
{
    public class TeamContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }

        public TeamContext(DbContextOptions<TeamContext> options)
            : base(options)
        { }
    }
}
