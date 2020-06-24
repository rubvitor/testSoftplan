using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TesteSoftplan.Domain.Interfaces.ApiExternal;
using TesteSoftplan.Domain.Models;

namespace TesteSoftplan.Infra.Data.ApiExternal
{
    public class ApiOneHttpClient : IApiOneHttpClient
    {
        public HttpClient Client { get; }
        private readonly IOptions<AppSettingsConfig> _config;

        public ApiOneHttpClient(HttpClient client, IOptions<AppSettingsConfig> config)
        {
            _config = config;
            if (_config != null && _config.Value.Api != null)
            {
                client.BaseAddress = new Uri(_config.Value.Api.EnderecoApiOne);
                // GitHub API versioning
                client.DefaultRequestHeaders.Add("Accept",
                    "application/json");

                Client = client;
            }
        }

        public async Task<double> GetJuros()
        {
            var response = await Client.GetAsync(_config.Value.Api.EndpointJuros);

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync
                <double>(responseStream);
        }
    }
}
