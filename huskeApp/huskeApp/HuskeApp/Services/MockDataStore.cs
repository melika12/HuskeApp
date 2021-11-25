using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HuskeApp.ViewModels;

namespace HuskeApp.Services
{
    public class MockDataStore : IDataStore<Note>
    {
        readonly List<Note> notes;
        public MockDataStore()
        {
            notes = new List<Note>()
            {
                new Note { Id = Guid.NewGuid().ToString(), Name = "First item", Description="This is an item description." },
                new Note { Id = Guid.NewGuid().ToString(), Name = "Second item", Description="This is an item description." },
                new Note { Id = Guid.NewGuid().ToString(), Name = "Third item", Description="This is an item description." },
                new Note { Id = Guid.NewGuid().ToString(), Name = "Fourth item", Description="This is an item description." },
                new Note { Id = Guid.NewGuid().ToString(), Name = "Fifth item", Description="This is an item description." },
                new Note { Id = Guid.NewGuid().ToString(), Name = "Sixth item", Description="This is an item description." }
            };
        }
        public async Task<bool> AddNoteAsync(Note note)
        {
            notes.Add(note);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateNoteAsync(Note note)
        {
            var oldNote = notes.Where((Note arg) => arg.Id == note.Id).FirstOrDefault();
            notes.Remove(oldNote);
            notes.Add(note);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteNoteAsync(string id)
        {
            var oldNote = notes.Where((Note arg) => arg.Id == id).FirstOrDefault();
            notes.Remove(oldNote);

            return await Task.FromResult(true);
        }

        public async Task<Note> GetNoteAsync(string id)
        {
            return await Task.FromResult(notes.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Note>> GetNotesAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(notes);
        }
    }
}
