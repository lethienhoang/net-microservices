using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _configuration;
        public CommandHttpClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<string> GetCommandInfoByPlatformId(int paltformId)
        {
            var res = await _httpClient.GetAsync(_configuration["CommandService"] + "test");
            if (res.IsSuccessStatusCode)
            {
                var result = await res.Content.ReadAsStringAsync();
                return result;
            }

            return string.Empty;
        }
    }
}
