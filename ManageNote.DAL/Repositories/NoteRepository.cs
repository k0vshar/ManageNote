using ManageNote.DAL.Interfaces;
using ManageNote.Domain.Entity;

namespace ManageNote.DAL.Repositories
{
    public class NoteRepository : IBaseRepository<Note>
    {
        private readonly AppDBContext _db;

        public NoteRepository(AppDBContext db)
        {
            _db = db;
        }

        public async Task Create(Note entity)
        {
            await _db.Notes.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public IQueryable<Note> GetAllNotes()
        {
            return _db.Notes;
        }

        public async Task Delete(Note entity)
        {
            _db.Notes.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<Note> Update(Note entity)
        {
            _db.Notes.Update(entity);
            await _db.SaveChangesAsync();

            return entity;
        }
    }
}
