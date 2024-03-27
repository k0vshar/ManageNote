using ManageNote.Domain.Entity;
using ManageNote.Domain.Response;
using ManageNote.Domain.ViewModels.Note;

namespace ManageNote.Service.Interfaces
{
    public interface INoteService
    {
        IBaseResponse<List<Note>> GetNotes();

        Task<IBaseResponse<Note>> CreateNote(long id, NoteViewModel model);

        Task<IBaseResponse<Note>> EditNote(long id, NoteViewModel model);

        Task<IBaseResponse<bool>> DeleteNote(long id);

        Task<IBaseResponse<NoteViewModel>> ViewNote(long id);
    }
}
