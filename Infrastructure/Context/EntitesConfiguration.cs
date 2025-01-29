using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class EntitesConfiguration
{
    public static void Configure(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasOne(u => u.Account)
            .WithMany()
            .HasForeignKey(u => u.AccountId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Transfers>()
            .HasOne(t => t.AccountOrigin)
            .WithMany(a => a.TransfersSent)
            .HasForeignKey(t => t.AccountOriginId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Transfers>()
            .HasOne(t => t.AccountDestination)
            .WithMany(a => a.TransfersReceived)
            .HasForeignKey(t => t.AccountDestinationId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Account>()
            .Property(a => a.CurrentBalance)
            .HasDefaultValue(0);

        modelBuilder.Entity<Reminders>()
            .HasOne(r => r.Account)
            .WithMany(a => a.Reminders)
            .HasForeignKey(r => r.AccountId)
            .OnDelete(DeleteBehavior.Restrict);

        //Deal with timezones
        modelBuilder.Entity<User>().Property("RegisteredDate").HasColumnType("timestamp without time zone");
        modelBuilder.Entity<Account>().Property("RegisteredDate").HasColumnType("timestamp without time zone");
        modelBuilder.Entity<Transfers>().Property("RegisteredDate").HasColumnType("timestamp without time zone");
        modelBuilder.Entity<Reminders>().Property("RegisteredDate").HasColumnType("timestamp without time zone");        
    }
}
