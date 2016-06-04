using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace PumConverter.Model.Currencies
{
    public static class CurrencyDataService
    {
        private static List<string> _currencies;
        private static Dictionary<string, Dictionary<string, CurrencyRate>> _rates;

        private static async Task<IEnumerable<CurrencyRate>> RetrieveCurrencyRatesAsync()
        {
            var client = new HttpClient();
            var getResponse = await client.GetAsync(new Uri("https://pumconverter.azurewebsites.net/tables/rates?ZUMO-API-VERSION=2.0.0"));
            
            return await JsonConvert.DeserializeObjectAsync<List<CurrencyRate>>(await getResponse.Content.ReadAsStringAsync());
        }

        public static async Task LoadRatesAsync()
        {
            var downloadedRates = await RetrieveCurrencyRatesAsync();
            _currencies = downloadedRates
                .Select(r => r.First)
                .Concat(
                    downloadedRates.Select(r => r.Second))
                .Distinct()
                .ToList();

            _rates = downloadedRates
                .Concat(
                    downloadedRates
                    .Select(oldRate =>
                        new CurrencyRate
                        {
                            First = oldRate.Second,
                            Second = oldRate.First,
                            Rate = Math.Round(1 / oldRate.Rate, 4)
                        }
                ))
                .GroupBy(rate => rate.First)
                .ToDictionary(grouping => grouping.Key,
                grouping => grouping.ToDictionary(rate => rate.Second));
        }

        public static IEnumerable<string> Currencies { get { return _currencies; } }
        public static Dictionary<string, Dictionary<string, CurrencyRate>> Rates { get { return _rates; } }
    }
}
