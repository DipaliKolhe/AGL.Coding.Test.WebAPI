using AGL.Coding.Test.Models;
using AGL.Coding.Test.Services.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AGL.Coding.Test.Services
{
    public class PetOwnerService : IPetOwnerService
    {
        private readonly IAGLHttpClient _httpClient;

        public PetOwnerService(IAGLHttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<Owner>> GetAllPetOwnersAsync()
        {
            var response = await _httpClient.GetStringAsync("people.json");
            if (string.IsNullOrWhiteSpace(response))
            {
                return null;
            }
            return JsonConvert.DeserializeObject<List<Owner>>(response);
        }

        public async Task<IEnumerable<OwnerGenderPets>> GetAllPetsByOwnerGenderAsync(PetType petType)
        {
            var result = new List<OwnerGenderPets>();
            var allOwners = await GetAllPetOwnersAsync();
            var people = allOwners?.ToList();
            if (people != null && people.Any())
            {
                result = people.Where(x => x.Pets != null && x.Pets.Any(pet => pet.Type == PetType.Cat))
                  .GroupBy(x => x.Gender)
                  .Select(x => new OwnerGenderPets
                  {
                      Gender = Enum.GetName(typeof(Gender), x.Key),
                      PetNames = x.SelectMany(pet => pet.Pets
                                    .Where(t => t.Type == petType)
                                        .Select(n => n.Name)).ToList()
                  })
                  .ToList();
            }

            return result;
        }
    }
}
