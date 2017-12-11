using Lab11Quotes.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab11Quotes.Services.Interfaces
{
    public interface IQuotesRepository
    {
        IQueryable<Quote>ReadAllQuotes();
        Quote Create(Quote quote);
    }
}
