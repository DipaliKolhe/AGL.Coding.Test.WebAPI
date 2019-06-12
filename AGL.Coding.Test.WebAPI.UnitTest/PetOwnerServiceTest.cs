using AGL.Coding.Test.Models;
using AGL.Coding.Test.Services;
using AGL.Coding.Test.Services.Contracts;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AGL.Coding.Test.WebAPI.UnitTest
{
    public class PetOwnerServiceTest
    {
        private PetOwnerService _petOwnerService = null;
        private IAGLHttpClient httpClient = Substitute.For<IAGLHttpClient>();
        private readonly string data ;
        public PetOwnerServiceTest()
        {
            data = "[{\"name\":\"Bob\",\"gender\":\"Male\",\"age\":23,\"pets\":[{\"name\":\"Garfield\",\"type\":\"Cat\"},{\"name\":\"Fido\",\"type\":\"Dog\"}]},{\"name\":\"Jennifer\",\"gender\":\"Female\",\"age\":18,\"pets\":[{\"name\":\"Garfield\",\"type\":\"Cat\"}]},{\"name\":\"Steve\",\"gender\":\"Male\",\"age\":45,\"pets\":null},{\"name\":\"Fred\",\"gender\":\"Male\",\"age\":40,\"pets\":[{\"name\":\"Tom\",\"type\":\"Cat\"},{\"name\":\"Max\",\"type\":\"Cat\"},{\"name\":\"Sam\",\"type\":\"Dog\"},{\"name\":\"Jim\",\"type\":\"Cat\"}]},{\"name\":\"Samantha\",\"gender\":\"Female\",\"age\":40,\"pets\":[{\"name\":\"Tabby\",\"type\":\"Cat\"}]},{\"name\":\"Alice\",\"gender\":\"Female\",\"age\":64,\"pets\":[{\"name\":\"Simba\",\"type\":\"Cat\"},{\"name\":\"Nemo\",\"type\":\"Fish\"}]}]";
        }

        [Fact]
        public void PetOwnerService_GetAllPetOwnersAsync_AGLServiceReturnsValidData()
        {
           httpClient.GetStringAsync("people.json").Returns(data);
            _petOwnerService = new PetOwnerService(httpClient);
            var result = _petOwnerService.GetAllPetOwnersAsync().Result;
            Assert.NotEmpty(result as List<Owner>);
            Assert.Equal(6, (result as List<Owner>).Count);
        }

        [Fact]
        public void PetOwnerService_GetAllPetOwnersAsync_AGLServiceReturnsNull()
        {
            string str = null;
            httpClient.GetStringAsync("people.json").Returns(str);
            _petOwnerService = new PetOwnerService(httpClient);
            var result = _petOwnerService.GetAllPetOwnersAsync().Result;
            Assert.Null(result);
        }

        [Fact]
        public void PetOwnerService_GetAllPetsByOwnerGenderAsync_AGLServiceReturnsValidData()
        {
            httpClient.GetStringAsync("people.json").Returns(data);
            _petOwnerService = new PetOwnerService(httpClient);
            var result = _petOwnerService.GetAllPetsByOwnerGenderAsync(PetType.Cat).Result;
            Assert.NotEmpty(result as List<OwnerGenderPets>);
            Assert.Equal(2, (result as List<OwnerGenderPets>).Count);
        }

        [Fact]
        public void PetOwnerService_GetAllPetsByOwnerGenderAsync_AGLServiceReturnsNull()
        {
            string str = null;
            httpClient.GetStringAsync("people.json").Returns(str);
            _petOwnerService = new PetOwnerService(httpClient);
            var result = _petOwnerService.GetAllPetsByOwnerGenderAsync(PetType.Cat).Result;
            Assert.Empty((result as List<OwnerGenderPets>));
        }

    }
}
