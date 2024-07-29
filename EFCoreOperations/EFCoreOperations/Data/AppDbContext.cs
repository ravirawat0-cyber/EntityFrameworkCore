﻿using Microsoft.EntityFrameworkCore;

namespace EFCoreOperations.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
                
        }
    }
}
