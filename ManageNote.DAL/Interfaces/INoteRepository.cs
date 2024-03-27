using ManageNote.Domain.Entity;

namespace ManageNote.DAL.Interfaces
{
    internal interface INoteRepository : IBaseRepository<Note>
    {
        Task<Note> GetByTitle(string title);
    }
}
