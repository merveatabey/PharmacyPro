﻿using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<User, UserRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server = DESKTOP-U0D7TK1\\SQLEXPRESS; database = PharmacyPro; integrated security = true; TrustServerCertificate=True");
        }

        DbSet<Pharmacy> Pharmacies { get; set; }
        DbSet<Medicine> Medicines { get; set; }
      
    }
}
