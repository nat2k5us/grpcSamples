using System;
using System.Collections.Generic;
using System.Linq;

namespace server
{
    public interface IGreetingManager
    {
        string Get(string language);
        string GetRandom();
    }

    public class GreetingManager : IGreetingManager
    {
        private readonly IDictionary<string, string> languages = new Dictionary<string, string> {
            { "Hindi", "Namaste" },
            { "English", "Hello" },
            { "Tibetian", "Tashi-Delek" },
            { "Telugu", "Namaskaram" },
            { "Tamil", "Vanakam" },
            { "Mexico", "Buenos dias" },
            { "Japan", "Konnichiwa" },
        };
        public string Get(string language)
        {
            if (languages.ContainsKey(language))
            {
                return languages[language];
            }
            return "Hello";
        }

        public string GetRandom()
        {
            Random rnd = new Random();
            int n = rnd.Next(0, languages.Count);
            return languages[languages.Keys.ToList()[n]];
        }
    }

}