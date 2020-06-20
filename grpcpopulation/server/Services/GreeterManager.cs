using System;
using System.Collections.Generic;
using System.Linq;

namespace server.Services
{
    public interface IGreeterManager
    {
        string Get(string greeting);
        string GetRandom();
    }

    public class GreeterManager : IGreeterManager
    {
        private readonly IDictionary<string, string> countries = new Dictionary<string, string> {
            { "INDIA", "Namaste" },
            { "USA", "Hello" },
            { "Tibet", "Tashi-Delek" },
            { "Telugu", "Namaskaram" },
            { "Tamil", "Vanakam" },
            { "Mexico", "Buenos dias" },
            { "Japan", "Konnichiwa" },
        };

        public string Get(string country)
        {
            if (countries.ContainsKey(country))
            {
                return countries[country];
            }
            return "Hello";
        }
        public string GetRandom()
        {
            Random rnd = new Random();
            int n = rnd.Next(0, countries.Count);
            return countries[countries.Keys.ToList()[n]];
        }
    }
}