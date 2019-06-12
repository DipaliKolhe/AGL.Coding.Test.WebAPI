using AGL.Coding.Test.Models;
using AGL.Coding.Test.Services;
using AGL.Coding.Test.Services.Contracts;
using AGL.Coding.Test.WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NSubstitute;
using System;
using System.Collections.Generic;
using Xunit;

namespace AGL.Coding.Test.WebAPI.UnitTest
{
    public class PetsControllerTest
    {
        private PetsController _petsController = null;
        IPetOwnerService petOwnerService = Substitute.For<IPetOwnerService>();

        public PetsControllerTest()
        {

        }
        [Fact]
        public void PetsController_GetAllPetsByOwnerGender_Test()
        {
            var list = new List<OwnerGenderPets>();
            list.Add(new OwnerGenderPets { Gender = "M", PetNames = new List<string> { "abc", "def", "ghi" } });
            list.Add(new OwnerGenderPets { Gender = "F", PetNames = new List<string> { "jkl", "mno", "pqr" } });
            petOwnerService.GetAllPetsByOwnerGenderAsync(PetType.Cat).Returns(list);

            _petsController = new PetsController(petOwnerService);

            var result = _petsController.GetAllPetsByOwnerGender(PetType.Cat).Result;
            Assert.IsType<OkObjectResult>(result);
            var value = ((OkObjectResult)result).Value;
            Assert.Equal(2, (value as List<OwnerGenderPets>).Count);
        }
    }
}
