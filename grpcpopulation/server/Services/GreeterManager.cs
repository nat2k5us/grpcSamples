using System.Collections.Generic;
namespace server.Services
{
    public interface IGreeterManager
    {  
        string Get(string greeting);
    }

    public class GreeterManager : IGreeterManager
    {
        private readonly IDictionary<string, string> countries = new Dictionary<string, string> {
            { "INDIA", "Namaste" },
            { "USA", "Hello" },
            { "Tibet", "Tashi-Delek" },
            { "Andhra", "Namaskaram" },
        };

        public string Get(string country)
        {
            if (countries.ContainsKey(country))
            {
                return countries[country];
            }
            return "Hello";
        }
    }
}