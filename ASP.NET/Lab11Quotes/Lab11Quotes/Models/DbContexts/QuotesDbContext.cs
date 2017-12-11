using Lab11Quotes.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab11Quotes.Models.DbContexts
{
    public class QuotesDbContext : DbContext
    {
        public QuotesDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Quote> Quotes { get; set; }

        public void Seed()
        {
            Database.EnsureCreated();

            if (Quotes.Any()) return; // Already seeded

            var quotes = new List<Quote>
     {
        new Quote
        {
           TheQuote = "Strive not to be a success, but rather to be of value.",
           WhoSaidIt = "Albert Einstein"
        },
        new Quote
        {
           TheQuote = "Life is what happens to you while you’re busy making other plans.",
           WhoSaidIt = "John Lennon"
        },
        new Quote
        {
           TheQuote = "The mind is everything. What you think, you become.",
           WhoSaidIt = "Buddha"
        },
        new Quote
        {
           TheQuote = "Your time is limited, so don’t waste it living someone else’s life.",
           WhoSaidIt = "Steve Jobs"
        },
        new Quote
        {
           TheQuote = "The most difficult thing is the decision to act, the rest is merely tenacity.",
           WhoSaidIt = "Amelia Earhart"
        },
        new Quote
        {
           TheQuote = "The best and most beautiful things in the world cannot be seen or even touched - they must be felt with the heart.",
           WhoSaidIt = "Helen Keller"
        },
        new Quote
        {
           TheQuote = "Start by doing what's necessary; then do what's possible; and suddenly you are doing the impossible.",
           WhoSaidIt = "Francis of Assissi"
        },
        new Quote
        {
           TheQuote = "Try to be a rainbow in someone's cloud.",
           WhoSaidIt = "Maya Angelou"
        },
        new Quote
        {
           TheQuote = "No act of kindness, no matter how small, is ever wasted.",
           WhoSaidIt = "Aesop"
        }
     };
            Quotes.AddRange(quotes);
            SaveChanges();
        }
    }

}
