using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab03Controllers.Services
{
    public interface IWordDictionary

    {

        void AddWord(string word, string meaning);

        Dictionary<string, string> GetWords();

    }

    public class WordDictionary : IWordDictionary

    {

        private static Dictionary<string, string> _words = null;

        public WordDictionary()

        {

            _words = new Dictionary<string, string>();

        }

        public void AddWord(string word, string meaning)

        {

            _words[word] = meaning;

        }

        public Dictionary<string, string> GetWords()

        {

            return _words;

        }

    }
}
