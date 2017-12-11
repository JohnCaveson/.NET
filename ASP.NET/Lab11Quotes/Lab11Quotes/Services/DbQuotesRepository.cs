using Lab11Quotes.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab11Quotes.Models.Entities;
using Lab11Quotes.Models.DbContexts;

namespace Lab11Quotes.Services
{
    public class DbQuotesRepository : IQuotesRepository
    {
        QuotesDbContext _db;
        public DbQuotesRepository(QuotesDbContext db)
        {
            _db = db;
        }
        public IQueryable<Quote> ReadAllQuotes()
        {
            return _db.Quotes.AsQueryable();
        }

        public Quote Create(Quote quote)
        {
            _db.Quotes.Add(quote);
            _db.SaveChanges();
            return quote;
        }
    }
}
