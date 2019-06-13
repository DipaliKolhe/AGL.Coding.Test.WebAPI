using AGL.Coding.Test.Models;
using AGL.Coding.Test.Services.Contracts;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AGL.Coding.Test.Services
{
    public class AGLHttpClient: IAGLHttpClient
    {
        private readonly Uri _baseAddress;

        public AGLHttpClient(IOptions<AppSettings> config)
        {
            if (config == null)
            {
                throw new ArgumentNullException(nameof(config));
            }
            _baseAddress = new Uri(config.Value.WebAPIEndpoint);
        }

        public async Task<string> GetStringAsync(string uri)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = _baseAddress;
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await httpClient.GetStringAsync(uri);
                return response;
            }
        }
    }
}
