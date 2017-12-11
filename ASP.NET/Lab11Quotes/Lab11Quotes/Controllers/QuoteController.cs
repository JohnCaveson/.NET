using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab11Quotes.Services.Interfaces;
using Lab11Quotes.Models.Entities;

namespace Lab11Quotes.Controllers
{
    public class QuoteController : Controller
    {
        private static Random _r = new Random();
        private IQuotesRepository _quotes;
        public QuoteController(IQuotesRepository quotes)
        {
            _quotes = quotes;
        }

        public IActionResult RandomQuote()
        {
            var newQuoteList = _quotes.ReadAllQuotes().ToList();
            var randIntLTTen = _r.Next(newQuoteList.Count);
            var quote = newQuoteList[randIntLTTen];
            return Json(new
            {
                Quote = quote.TheQuote,
                WhoSaidIt = quote.WhoSaidIt
            });
        }

        private bool IsAjaxRequest()
        {
            return Request.Headers["X-Requested-With"] == "XMLHttpRequest";
        }


        [HttpPost]
        public IActionResult Create(Quote quote)
        {
            if (ModelState.IsValid)
            {
                _quotes.Create(quote);
                if (IsAjaxRequest())
                {
                    return Json("Ok");
                }
            }
            if (IsAjaxRequest())
            {
                return Json("Not Ok");
            }
            return RedirectToAction("Index", "Home");
        }


    }
}