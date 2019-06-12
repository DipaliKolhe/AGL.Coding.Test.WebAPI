using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AGL.Coding.Test.Services.Contracts
{
   public interface IAGLHttpClient
    {
        Task<string> GetStringAsync(string uri);
    }

}
