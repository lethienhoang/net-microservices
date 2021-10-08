using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PlatformService.ExternalServices.CommandService
{
    public class CommandHttpClient : ICommandHttpClient
    {
        private readonly HttpClient _httpClient;
        public CommandHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetCommandInfoByPlatformId(int paltformId)
        {
            var res = await _httpClient.GetAsync("http://commandservice-clusterip-srv:80/v1/api/internal/platform/test");
            if (res.IsSuccessStatusCode)
            {
                var result = await res.Content.ReadAsStringAsync();
                return result;
            }

            return string.Empty;
        }
    }
}
