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

        public async Task<Comment> CreateAsync(Comment commentModel)
        {
            await _context.Comments.AddAsync(commentModel);
            await _context.SaveChangesAsync();
            return commentModel;
        }

        public async Task<Comment?> DeleteAsync(int id)
        {
            var commentModel = await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);
            if (commentModel == null)
            {
                return null;
            }
            _context.Comments.Remove(commentModel);
            await _context.SaveChangesAsync();
            return commentModel;
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            return await _context.Comments.FindAsync(id);
        }

        public async Task<Comment?> UpdateAsync(int id, Comment commentModel)
        {
            var exitingComment = await _context.Comments.FindAsync(id);
            if (exitingComment == null)
            {
                return null;
            }
            exitingComment.Title = commentModel.Title;
            exitingComment.Content = commentModel.Content;
            await _context.SaveChangesAsync();
            return exitingComment;
        }
    }
}