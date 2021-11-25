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
                var row = 0;
                var column = 0;

                foreach (var note in notes)
                {
                    new Note { Id = Guid.NewGuid().ToString(), Name = note.Name, Description = note.Description };
                    Grid myNote = new Grid
                    {
                        /*RowDefinitions =
                        {
                            new RowDefinition { Height = new GridLength(2, GridUnitType.Star) },
                        },
                        ColumnDefinitions =
                        {
                            new ColumnDefinition(){ Width = new GridLength(2, GridUnitType.Star) },
                        },*/
                        ClassId = note.Id,
                        //HeightRequest = 10
                    };
                    
                    var stackLayout = new StackLayout
                    {
                        
                        Padding = new Thickness(0, 20, 0, 0),
                        Children = {
                            //new BoxView {Color = Color.Aqua},
                            new Label { Text = note.Name },
                            new Label { Text = note.Description }
                        }
                    };
                    
                    myNote.Children.Add(stackLayout, row, column);
                    //myNote.Children.Add(stackLayoutDec, row, column+1);

                    //row++;
                    
                    //myNote.Children.Add(stackLayout);
                    //myNote.Children.Add(stackLayoutDec);
                    noteGrid.Children.Add(myNote);
                    column++;
                    //Height += 100;

                }
                
            }
            else
            {
                // password.Text = "blablabla";
            }
        }
    }
}