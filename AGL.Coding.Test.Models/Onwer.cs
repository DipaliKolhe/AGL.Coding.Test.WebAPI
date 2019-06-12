using System;
using System.Collections.Generic;
using System.Text;

namespace AGL.Coding.Test.Models
{
    public class Owner
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public ICollection<Pet> Pets { get; set; }
    }
}
