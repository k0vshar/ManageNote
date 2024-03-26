using ManageNote.Domain.Entity;
using ManageNote.Domain.Response;

namespace ManageNote.Service.Interfaces
{
    public interface INoteService
    {
        IBaseResponse<List<Note>> GetNotes();

        Task<IBaseResponse<Note>> Create(string title, string desc);

        Task<IBaseResponse<Note>> Edit(string title, string desc);

        Task<IBaseResponse<Note>> ViewNote(int id);
    }
}
