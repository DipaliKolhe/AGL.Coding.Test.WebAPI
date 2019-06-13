using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AGL.Coding.Test.Models;
using AGL.Coding.Test.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AGL.Coding.Test.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IPetOwnerService _petOwnerService;
        public PetsController(IPetOwnerService petOwnerService)
        {
            _petOwnerService = petOwnerService;
        }

       

        [HttpGet]
        public async Task<ActionResult> GetAllPetsByOwnerGender(PetType type)
        {
            var pets = await _petOwnerService.GetAllPetsByOwnerGenderAsync(type);
            return Ok(pets);
        }
    }
}