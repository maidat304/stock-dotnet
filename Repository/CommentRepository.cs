using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_dotnet.Data;
using api_dotnet.Interface;
using api_dotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace api_dotnet.Repository
{
    public class CommentRepository : ICommentRepository
    {
        public readonly ApplicationDBContext _context;

        public CommentRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            return await _context.Comments.FindAsync(id);
        }
    }
}