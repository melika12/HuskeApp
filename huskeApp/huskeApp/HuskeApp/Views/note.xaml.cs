using huskeApi.Helper;
using Newtonsoft.Json;
using HuskeApp.ViewModels;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HuskeApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class note : ContentPage
    {
        public note()
        {
            InitializeComponent();
            GetNotes();
        }
        private async void GetNotes()
        {
            var result = await ApiCaller.Get("http://192.168.100.131:8080/notes/index");
            if (result.Successful)
            {
                var notes = (List<Note>)JsonConvert.DeserializeObject(result.Response);
                foreach (var note in notes)
                {
                    new Note { Id = Guid.NewGuid().ToString(), Name = note.Name, Description = note.Description };
                }
            }
            else
            {
                // password.Text = "blablabla";
            }
        }
    }
}