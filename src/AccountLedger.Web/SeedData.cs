﻿using AccountLedger.Core.ProjectAggregate;
using AccountLedger.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace AccountLedger.Web
{
    public static class SeedData
    {
        public static readonly Project TestProject1 = new Project("Test Project");
        public static readonly ToDoItem ToDoItem1 = new ToDoItem
        {
            Title = "Get Sample Working",
            Description = "Try to get the sample to build."
        };
        public static readonly ToDoItem ToDoItem2 = new ToDoItem
        {
            Title = "Review Solution",
            Description = "Review the different projects in the solution and how they relate to one another."
        };
        public static readonly ToDoItem ToDoItem3 = new ToDoItem
        {
            Title = "Run and Review Tests",
            Description = "Make sure all the tests run and review what they are doing."
        };

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var dbContext = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null))
            {
                // Look for any TODO items.
                if (dbContext.ToDoItems.Any())
                {
                    return;   // DB has been seeded
                }
                PopulateTestData(dbContext);
                PopulateAccounts(dbContext);
            }
        }

        public static void PopulateTestData(AppDbContext dbContext)
        {
            foreach (var item in dbContext.ToDoItems)
            {
                dbContext.Remove(item);
            }
            dbContext.SaveChanges();

            TestProject1.AddItem(ToDoItem1);
            TestProject1.AddItem(ToDoItem2);
            TestProject1.AddItem(ToDoItem3);
            dbContext.Projects.Add(TestProject1);

            dbContext.SaveChanges();
        }


        public static void PopulateAccounts(AppDbContext dbContext)
        { 
            var item = new LedgerAccount
            {
                AccountNumber = "abc-scn-1123",
                Owner = "Usama",
                Balance = 2000
            };

            var itemTransactions = new AccountTransaction("Add", 20, item.AccountNumber);
            item.MakeDeposit(itemTransactions);
            dbContext.LedgerAccounts.Add(item);
            dbContext.SaveChanges();

     //       var dd = dbContext.LedgerAccounts.ToList();
        }
    }
}
