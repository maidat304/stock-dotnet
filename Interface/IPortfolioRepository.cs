using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_dotnet.Models;

namespace api_dotnet.Interface
{
    public interface IPortfolioRepository
    {
        Task<List<Stock>> GetUserPortfolios(AppUser user);
        Task<Portfolio> CreateAsync(Portfolio portfolio);
        Task<Portfolio> DeletePortfolio(AppUser appUser, string symbol);
    }
}