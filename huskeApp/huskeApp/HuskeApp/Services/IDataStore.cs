using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HuskeApp.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddNoteAsync(T note);
        Task<bool> UpdateNoteAsync(T note);
        Task<bool> DeleteNoteAsync(string id);
        Task<T> GetNoteAsync(string id);
        Task<IEnumerable<T>> GetNotesAsync(bool forceRefresh = false);
    }
}
