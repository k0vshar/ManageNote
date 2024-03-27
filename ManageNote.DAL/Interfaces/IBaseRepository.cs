using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageNote.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task Create(T entity);

        IQueryable<T> GetAllNotes();

        Task Delete(T entity);

        Task<T> Update(T entity);
    }
}
