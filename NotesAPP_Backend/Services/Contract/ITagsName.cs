using NotesAPP_Backend.Models;

namespace NotesAPP_Backend.Services.Contract
{
    public interface ITagsName
    {
        Task<List<TagsName>> GetList();
        Task<TagsName> GetById(int id);
        Task<TagsName> GetByTagName(string tagName);

        Task<TagsName> Add(TagsName model);

        Task<bool> Update(TagsName model);
        Task<bool> Delete(TagsName model);
    }
}
