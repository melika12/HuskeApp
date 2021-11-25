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
            //var result = await ApiCaller.Get("http://192.168.100.131:8080/notes/index");
            if (result.Successful)
            {
                var notes = JsonConvert.DeserializeObject<List<Note>>(result.Response);
                List<List<Note>> noteList = new List<List<Note>>();

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
                    Button edit = new Button
                    {
                        Text = "Edit",
                        FontSize = 10,
                        ClassId = note.Id
                    };
                    edit.Clicked += async (sender, args) => await Navigation.PushModalAsync(new editNote(note.Id, note.Name, note.Description));
                    Button delete = new Button
                    {
                        Text = "Delete",
                        FontSize = 10,
                        ClassId = note.Id,
                        
                        //Clicked = DeleteNotes(note.Id);
                    };

                    stackLayout.Children.Add(noteName);
                    stackLayout.Children.Add(noteDescription);
                    stackLayout.Children.Add(edit);
                    stackLayout.Children.Add(delete);
                    noteGrid.Children.Add(stackLayout);
                    delete.Clicked += async (sender, args) =>
                    {
                        await ApiCaller.Delete("http://192.168.1.54:8080/note/delete/" + note.Id);
                        //await ApiCaller.Delete("http://192.168.100.131:8080/note/delete/" + note.Id);
                        await Navigation.PushModalAsync(new note());
                    };
                }
            }
            else
            {
                // password.Text = "blablabla";
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new addNote());
        }
    }
}