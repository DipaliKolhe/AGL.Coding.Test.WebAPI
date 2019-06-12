using AGL.Coding.Test.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AGL.Coding.Test.Services.Contracts
{
    public interface IPetOwnerService
    {
        Task<IEnumerable<Owner>> GetAllPetOwnersAsync();
        Task<IEnumerable<OwnerGenderPets>> GetAllPetsByOwnerGenderAsync(PetType petType);
    }
}
