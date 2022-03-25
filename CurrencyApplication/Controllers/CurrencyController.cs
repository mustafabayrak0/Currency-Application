using Microsoft.AspNetCore.Mvc;
using CurrencyApplication.Models;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CurrencyApplication.Controllers
{
    public class CurrencyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<Currency> GetCurrency(string currency1)
        {
            var client = new RestSharp.RestClient($"https://api.fastforex.io");
            var request = new RestRequest($"/fetch-one?from={currency1}&to=TRY&api_key=70f537921a-99234aef35-r99euy", Method.Get);
            var response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                var content = JsonConvert.DeserializeObject<JToken>(response.Content);
                return content.ToObject<Currency>();
            }
            return null;
        }
        public async Task<IActionResult> ShowCurrency()
        {
            var CurrencyResponse = await GetCurrency("USD");
            var CurrencyResponse2 = await GetCurrency("EUR");
            var CurrencyResponse3 = await GetCurrency("GBP");
           
            Currency viewModel = new Currency();
            if (CurrencyResponse != null && CurrencyResponse2 != null && CurrencyResponse2 != null)
            {
                viewModel.USD= CurrencyResponse.Result.TRY;
                viewModel.EUR = CurrencyResponse2.Result.TRY;
                viewModel.GBP = CurrencyResponse3.Result.TRY;
            }
            return View(viewModel);
        }
    }
}
