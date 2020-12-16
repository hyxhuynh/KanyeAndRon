using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace KanyeAndRon
{
    public class QuoteGenerator
    {
        public static void KanyeQuote()
        {
            // new object created to make request to the Internet
            var client = new HttpClient();
            // Actual API url
            var kanyeURL = "https://api.kanye.rest";
            // from the instance of the internet (http) object client, use the GetStringAsync method to get the response back from the kanyeURL
            var kanyeResponse = client.GetStringAsync(kanyeURL).Result;
            // using static method Parse (no instance created, only class name JObject)
            // get the value pair of "quote" from the JSON object {"quote":"whatever written here for the quote value"} by referencing "quote"
            // send back the response in a string format
            var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();
            
            Console.WriteLine($"Kanye: \"{kanyeQuote}\"");
            Console.WriteLine("----------------------------------");
        }

        public static void RonQuote()
        {
            var client = new HttpClient();
            var ronURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
            var ronResponse = client.GetStringAsync(ronURL).Result;
            var ronQuote = JArray.Parse(ronResponse).ToString()
                .Replace('[', ' ').Replace(']', ' ').Trim();
            Console.WriteLine($"Ron: {ronQuote}");
            Console.WriteLine("----------------------------------");
        }
    }
}
