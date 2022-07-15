#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Exercise_4.Models;

namespace Exercise_4.Data
{
    public class Exercise_4Context : DbContext
    {
        public Exercise_4Context (DbContextOptions<Exercise_4Context> options)
            : base(options)
        {
        }

        public DbSet<Exercise_4.Models.Student> Student { get; set; }

        public DbSet<Exercise_4.Models.StudentHistory> StudentHistory { get; set; }
    }
}
