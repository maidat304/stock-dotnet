using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_dotnet.Data;
using api_dotnet.Dtos.Stock;
using api_dotnet.Interface;
using api_dotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace api_dotnet.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDBContext _context;
        public StockRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Stock> CreateAsync(Stock stockModel)
        {
            await _context.Stock.AddAsync(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<Stock?> DeleteAsync(int id)
        {
            var stockModel = await _context.Stock.FirstOrDefaultAsync(s => s.Id == id);
            if (stockModel == null)
            {
                return null;
            }
            _context.Stock.Remove(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<List<Stock>> GetAllAsync()
        {
            return await _context.Stock.ToListAsync();
        }

        public async Task<Stock?> GetByIdAsync(int id)
        {
            return await _context.Stock.FindAsync(id);
        }

        public async Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto updateDto)
        {
            var exitingStock = await _context.Stock.FirstOrDefaultAsync(x => x.Id == id);
            if (exitingStock == null)
            {
                return null;
            }
            exitingStock.Symbol = updateDto.Symbol;
            exitingStock.CompanyName = updateDto.CompanyName;
            exitingStock.Purchase = updateDto.Purchase;
            exitingStock.LastDiv = updateDto.LastDiv;
            exitingStock.Industry = updateDto.Industry;
            exitingStock.Marketcap = updateDto.Marketcap;
            await _context.SaveChangesAsync();
            return exitingStock;
        }

    }
}