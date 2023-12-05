using NotesAPP_Backend.Models;

namespace NotesAPP_Backend.Services.Contract
{
    public interface INotesService
    {
        Task<List<NotesScheme>> GetList();
        Task<NotesScheme> Get(int id);

        Task<NotesScheme> GetByTagNameId(int tagName);

        Task<NotesScheme> GetByCategoryName(string categoryName);

        Task<NotesScheme> Add(NotesScheme model);

        Task<bool> Update(NotesScheme model);
        Task<bool> Delete(NotesScheme model);
    }
}
