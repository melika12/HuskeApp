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
                List<List <Note>> noteList = new List<List <Note>>();
                foreach (var note in notes)
                {
                    new Note { Id = Guid.NewGuid().ToString(), Name = note.Name, Description = note.Description };

                    Grid myNote = new Grid
                    {
                        RowDefinitions =
                        {
                            new RowDefinition { Height = new GridLength(2, GridUnitType.Star) },
                            new RowDefinition(),
                            new RowDefinition { Height = new GridLength(100) }
                        },
                        ColumnDefinitions =
                        {
                            new ColumnDefinition(),
                            new ColumnDefinition()
                        },
                        ClassId = note.Id
                    };
                    myNote.Children.Add(new Label
                    {
                        Text = note.Name,
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center
                    });
                    myNote.Children.Add(new Label
                    {
                        Text = note.Description,
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center
                    });
                    noteGrid.Children.Add(myNote);

                }
            }
            else
            {
                // password.Text = "blablabla";
            }
        }
    }
}