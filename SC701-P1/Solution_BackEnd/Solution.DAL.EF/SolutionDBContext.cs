﻿using Microsoft.EntityFrameworkCore;
using Solution.DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solution.DAL.EF
{
    public class SolutionDBContext:DbContext
    {
        public SolutionDBContext(DbContextOptions<SolutionDBContext> options) 
            : base(options) 
        { 
        
        }

        public DbSet<Pais> Paises { get; set; }
        public DbSet<Universidad> Universidad { get; set; }
    }
}
