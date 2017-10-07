using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab03Controllers.Services;
using System.Net;

namespace Lab03Controllers.Controllers
{
    public class DictionaryController : Controller
    {
        private IWordDictionary _words;

        public DictionaryController(IWordDictionary words)
        {
            _words = words;
        }
        public IActionResult Add()
        {
            return View();
        }

        //Because the form action was get
        [HttpPost]
        public IActionResult AddWord(string word, string meaning)
        {
            //Use HtmlEncode to eliminate the risk of script injection
            var safeWord = WebUtility.HtmlEncode(word);
            var safeMeaning = WebUtility.HtmlEncode(meaning);

            _words.AddWord(safeWord, safeMeaning);
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            return View(_words);
        }
    }
}