using ManageNote.Domain.Entity;
using ManageNote.Domain.Response;

namespace ManageNote.Service.Interfaces
{
    public interface INoteService
    {
        IBaseResponse<List<Note>> GetNotes();
    }
}
