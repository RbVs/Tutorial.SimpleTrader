using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;

namespace SimpleTrader.FinancialModelingPrepAPI.Services
{
    public class MajorIndexService : IMajorIndexService
    {
        public async Task<MajorIndex> GetMajorIndex(MajorIndexType indexType)
        {
            string uri = "https://financialmodelingprep.com/api/v3/majors-indexes/" + GetUriSuffix(indexType);

            using var client = new HttpClient();

            var response = await client.GetAsync(uri);
            var jsonResponse = await response.Content.ReadAsStringAsync();

            var majorIndex = JsonConvert.DeserializeObject<MajorIndex>(jsonResponse);
            majorIndex.Type = indexType;

            return majorIndex;
        }

        private string GetUriSuffix(MajorIndexType indexType)
        {
            return indexType switch
            {
                MajorIndexType.DowJones => ".DJI",
                MajorIndexType.Nasdaq => ".IXIC",
                MajorIndexType.SP500 => ".INX",
                _ => ".DJI"
            };
        }
    }
}
