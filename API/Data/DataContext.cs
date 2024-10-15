using System;
using Microsoft.EntityFrameworkCore;

namespace API.Entities;

public class DataContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<AppUser> Users { get; set; }
}
