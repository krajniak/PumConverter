using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace PumConverter.Model.Currencies
{
    public static class CurrencyDataService
    {
        private static List<string> _currencies;
        private static Dictionary<string, Dictionary<string, Rates>> _rates;

        private static async Task<IEnumerable<Rates>> RetrieveCurrencyRatesJsonAsync()
        {
            var client = new HttpClient();
            var getResponse = await client.GetAsync(new Uri("https://pumconverter.azurewebsites.net/tables/rates?ZUMO-API-VERSION=2.0.0"));
            
            return await JsonConvert.DeserializeObjectAsync<List<Rates>>(await getResponse.Content.ReadAsStringAsync());
        }

        private static async Task<IEnumerable<Rates>> RetrieveCurrencyRatesTablesAsync()
        {
            var client = new MobileServiceClient("https://pumconverter.azurewebsites.net/");

            var table = client.GetTable<Rates>();
            return await table.ReadAsync();

        }
        private static async Task InitLocalStoreAsync(MobileServiceClient client)
        {
            if (!client.SyncContext.IsInitialized)
            {
                var store = new MobileServiceSQLiteStore("localstore.db");
                store.DefineTable<Rates>();
                await client.SyncContext.InitializeAsync(store);
            }
        }

        private static async Task<IEnumerable<Rates>> RetrieveCurrencyRatesAsync()
        {
            var client = new MobileServiceClient("https://pumconverter.azurewebsites.net/");

            await InitLocalStoreAsync(client);

            var table = client.GetSyncTable<Rates>();
            await table.PullAsync<Rates>("All", table.CreateQuery(), true,CancellationToken.None,new PullOptions { MaxPageSize = 200});
            return await table.ReadAsync();
        }

        public static async Task LoadRatesAsync()
        {
            var downloadedRates = await RetrieveCurrencyRatesTablesAsync();
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
                        new Rates
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
        public static Dictionary<string, Dictionary<string, Rates>> Rates { get { return _rates; } }
    }
}
