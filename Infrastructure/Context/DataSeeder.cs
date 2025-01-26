using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class DataSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>().HasData(new Account
        {
            Id=0,
        });

        modelBuilder.Entity<User>().HasData(new User
        {
            Id=0,
            AccountId=0,
            Email="admin@moneto.com",
            Password="8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918", //SHA-256
            FirstName="admin"
        });
    }
}
