using System.Threading.Tasks;
using SimpleTrader.Domain.Exceptions;
using SimpleTrader.Domain.Services;
using SimpleTrader.FinancialModelingPrepAPI.Results;

namespace SimpleTrader.FinancialModelingPrepAPI.Services
{
    public class StockPriceService : IStockPriceService
    {
        public async Task<double> GetPrice(string symbol)
        {
            using var client = new FinancialModelingPrepHttpClient();
            var uri = "stock/real-time-price/" + symbol;
            string apiKey = "f9640047997a5e29a933b2a86d1c337f";

            var stockPriceResult = await client.GetAsync<StockPriceResult>($"{uri}?apikey={apiKey}");

            if (stockPriceResult.Price == 0) throw new InvalidSymbolException(symbol);

            return stockPriceResult.Price;
        }
    }
}