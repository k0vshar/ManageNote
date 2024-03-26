using ManageNote.Domain.Entity;
using ManageNote.Domain.Response;
using ManageNote.Service.Interfaces;

namespace ManageNote.Service.Implementation
{
    internal class NoteService : INoteService
    {
        Task<IBaseResponse<Note>> INoteService.Create(string title, string desc)
        {
            throw new NotImplementedException();
        }

        Task<IBaseResponse<Note>> INoteService.Edit(string title, string desc)
        {
            throw new NotImplementedException();
        }

        IBaseResponse<List<Note>> INoteService.GetNotes()
        {
            throw new NotImplementedException();
        }

        Task<IBaseResponse<Note>> INoteService.ViewNote(int id)
        {
            throw new NotImplementedException();
        }
    }
}
