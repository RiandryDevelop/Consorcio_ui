using Microsoft.EntityFrameworkCore;
using NotesAPP_Backend.Models;
using NotesAPP_Backend.Services.Contract;

namespace NotesAPP_Backend.Services.Implementation
{
    public class TagsNameService : ITagsName
    {
        private DbnotesContext _dbContext;

        public TagsNameService(DbnotesContext dbContext)
        {
            _dbContext = dbContext;
        }
        public new async Task<List<TagsName>> GetList()
        {
            try
            {
                List<TagsName> list = new List<TagsName>();  
                list = await _dbContext.TagsNames.ToListAsync();
                return list;

            }catch (Exception ex) {
                throw ex;
            }
        }


        public Task<TagsName> Add(TagsName model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(TagsName model)
        {
            throw new NotImplementedException();
        }

        public Task<TagsName> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TagsName> GetByTagName(string tagName)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(TagsName model)
        {
            throw new NotImplementedException();
        }
    }
}
