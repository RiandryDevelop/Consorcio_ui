using Microsoft.EntityFrameworkCore;
using NotesAPP_Backend.Models;
using NotesAPP_Backend.Services.Contract;

namespace NotesAPP_Backend.Services.Implementation
{
    public class NotesService : INotesService
    {
        private readonly DbnotesContext _dbContext;

        public NotesService(DbnotesContext dbContext)
        {
            _dbContext = dbContext;
        }

            
        public async Task<NotesScheme> Add(NotesScheme model)
        {
            try
            {
                _dbContext.NotesSchemes.Add(model);
                await _dbContext.SaveChangesAsync();
                return model;

            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<bool> Delete(NotesScheme model)
        {
            try
            {
                _dbContext.NotesSchemes.Remove(model);
                await _dbContext.SaveChangesAsync();
                return true;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<NotesScheme> Get(int id)
        {
            try
            {
                NotesScheme? foundONe = new();
                return foundONe = await _dbContext.NotesSchemes.Include(nt => nt.IdNote).
                    Where(e => e.IdNote == id).FirstOrDefaultAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<NotesScheme> GetByCategoryName(string categoryName)
        {
            try
            {
                NotesScheme? foundONe = new();
                return foundONe = await _dbContext.NotesSchemes.Include(nt => nt.CategoryName).
                    Where(e => e.CategoryName == categoryName).FirstOrDefaultAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public async Task<NotesScheme> GetByTagNameId(int tagNameId)
        {
            try
            {
                NotesScheme? foundONe = new();
                return foundONe = await _dbContext.NotesSchemes.Include(nt => nt.TagNameId).
                    Where(e => e.TagNameId == tagNameId).FirstOrDefaultAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<NotesScheme>> GetList()
        {
            try
            {
                List<NotesScheme> list = new();
                list = await _dbContext.NotesSchemes.Include(nt => nt.TagName).ToListAsync();
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Update(NotesScheme model)
        {
            try
            {
                _dbContext.NotesSchemes.Update(model);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}