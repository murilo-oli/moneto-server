using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class MonetoDbContext(DbContextOptions<MonetoDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; } = default!;
    public DbSet<Account> Accounts { get; set; } = default!;
    public DbSet<Transfers> Transfers { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        EntitesConfiguration.Configure(modelBuilder);
        DataSeeder.Seed(modelBuilder);
    }
}
