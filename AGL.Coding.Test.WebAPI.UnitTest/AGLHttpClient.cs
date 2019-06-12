using AGL.Coding.Test.Models;
using AGL.Coding.Test.Services;
using Microsoft.Extensions.Options;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AGL.Coding.Test.WebAPI.UnitTest
{
    public class AGLHttpClientTest
    {
        private AGLHttpClient _aglHttpClient = null;
        IOptions<AGLConfig> config = null;
        private readonly string data = null;

        public AGLHttpClientTest()
        {
            data = "[{\"name\":\"Bob\",\"gender\":\"Male\",\"age\":23,\"pets\":[{\"name\":\"Garfield\",\"type\":\"Cat\"},{\"name\":\"Fido\",\"type\":\"Dog\"}]},{\"name\":\"Jennifer\",\"gender\":\"Female\",\"age\":18,\"pets\":[{\"name\":\"Garfield\",\"type\":\"Cat\"}]},{\"name\":\"Steve\",\"gender\":\"Male\",\"age\":45,\"pets\":null},{\"name\":\"Fred\",\"gender\":\"Male\",\"age\":40,\"pets\":[{\"name\":\"Tom\",\"type\":\"Cat\"},{\"name\":\"Max\",\"type\":\"Cat\"},{\"name\":\"Sam\",\"type\":\"Dog\"},{\"name\":\"Jim\",\"type\":\"Cat\"}]},{\"name\":\"Samantha\",\"gender\":\"Female\",\"age\":40,\"pets\":[{\"name\":\"Tabby\",\"type\":\"Cat\"}]},{\"name\":\"Alice\",\"gender\":\"Female\",\"age\":64,\"pets\":[{\"name\":\"Simba\",\"type\":\"Cat\"},{\"name\":\"Nemo\",\"type\":\"Fish\"}]}]";
            config = Options.Create(new AGLConfig { WebAPIEndpoint = "http://agl-developer-test.azurewebsites.net/" });
        }

        [Fact]
        public void AGLHttpClient_Test()
        {
            _aglHttpClient = new AGLHttpClient(config);
            string result = _aglHttpClient.GetStringAsync("people.json").Result;
            Assert.Equal(data, result);
        }
    }
}
