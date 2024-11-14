using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_dotnet.Models;

namespace api_dotnet.Interface
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}