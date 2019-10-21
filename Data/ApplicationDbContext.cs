using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MountainTourismBookingSystem.Models;

namespace MountainTourismBookingSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<MountainModel> Mountain { get; set; }
        public DbSet<RegionModel> Region { get; set; }
        public DbSet<ChaletTypeModel> ChaletType { get; set; }
        public DbSet<ChaletModel> Chalet { get; set; }
    }
}


/*
Add-migration Initial1
Update-Database
*/
