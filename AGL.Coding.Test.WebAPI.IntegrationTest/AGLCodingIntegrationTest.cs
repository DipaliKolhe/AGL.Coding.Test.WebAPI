using AGL.Coding.Test.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace AGL.Coding.Test.WebAPI.IntegrationTest
{
    public class AGLCodingIntegrationTest : IClassFixture<TestFixture<Startup>>
    {
        private HttpClient Client;

        public AGLCodingIntegrationTest(TestFixture<Startup> fixture)
        {
            Client = fixture.Client;
        }

        
        [Theory]
        [InlineData(PetType.Cat)]
        [InlineData(PetType.Dog)]
        [InlineData(PetType.Fish)]
        public async Task TestGetAllPetsByOwnerGender(PetType type)
        {
            // Arrange
            var request = "/api/pets?type=" + type;

            // Act
            var response = await Client.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
         
        }

     
       

    }
}