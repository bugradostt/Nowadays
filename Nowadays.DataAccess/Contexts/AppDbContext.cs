﻿using Microsoft.EntityFrameworkCore;
using Nowadays.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Nowadays.DataAccess.Contexts
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        } 
        public DbSet<CompanyEntity> Companies { get; set; }
        public DbSet<ProjectEntity> Projects { get; set; }
        public DbSet<EmployeeProjectEntity> EmployeeProjects { get; set; }
        public DbSet<EmployeeEntity> Employees { get; set; }
        public DbSet<IssueEntity> Issues { get; set; }
        public DbSet<IssueProjectEntity> IssueProjects { get; set; }
        public DbSet<EmployeeIssueEntity> EmployeeIssues { get; set; }

        

    }
}
