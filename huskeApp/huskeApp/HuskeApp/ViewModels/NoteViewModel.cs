using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Xamarin.Forms;
using HuskeApp.Services;
using HuskeApp.ViewModels;


namespace HuskeApp.ViewModels
{
    [QueryProperty(nameof(NoteId), nameof(NoteId))]
    public class NoteViewModel : BaseViewModel
    {
        private string noteId;
        private string name;
        private string description;
        private string timeOfEvent;
        public string Id { get; set; }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public string TimeOfEvent
        {
            get => timeOfEvent;
            set => SetProperty(ref timeOfEvent, value);
        }

        public string NoteId
        {
            get
            {
                return noteId;
            }
            set
            {
                noteId = value;
                LoadNoteId(value);
            }
        }

        public async void LoadNoteId(string noteId)
        {
            try
            {
                var note = await DataStore.GetNoteAsync(noteId);
                Id = note.Id;
                Name = note.Name;
                Description = note.Description;
                TimeOfEvent = note.TimeOfEvent;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to load note");
            }
        }
    }
    public class Note
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string TimeOfEvent { get; set; }
        public string Description { get; set; }
    }
}
