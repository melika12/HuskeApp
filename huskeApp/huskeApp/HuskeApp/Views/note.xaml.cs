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
            var result = await ApiCaller.Get("http://192.168.1.54:8080/notes/index");
            if (result.Successful)
            {
                var notes = JsonConvert.DeserializeObject<List<Note>>(result.Response);
                List<List<Note>> noteList = new List<List<Note>>();
                //var row = 0;
                //var column = 0;

                foreach (var note in notes)
                {
                    new Note { Id = Guid.NewGuid().ToString(), Name = note.Name, Description = note.Description };
                    var stackLayout = new StackLayout
                    {
                        Orientation = StackOrientation.Vertical,
                        Margin = new Thickness(20),
                        Spacing = 0,
                        ClassId = note.Id,
                    };
                    Label noteName = new Label
                    {
                        Text = note.Name,
                        FontSize = 15,
                    };
                    Label noteDescription = new Label
                    {
                        Text = note.Description,
                        FontSize = 15,
                    };
                    Button delete = new Button
                    {
                        Text = "Delete",
                        FontSize = 10,
                        ClassId = note.Id,
                        
                        //Clicked = DeleteNotes(note.Id);
                    };
                    
                    stackLayout.Children.Add(noteName);
                    stackLayout.Children.Add(noteDescription);
                    stackLayout.Children.Add(delete);
                    noteGrid.Children.Add(stackLayout);
                    delete.Clicked += async (sender, args) =>
                    {
                        await ApiCaller.Delete("http://192.168.1.54:8080/note/delete/" + note.Id);
                        await Navigation.PushModalAsync(new note());
                    };


                }

            }
            else
            {
                // password.Text = "blablabla";
            }
        }
    }
        
}