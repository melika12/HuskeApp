using huskeApi.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HuskeApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class editNote : ContentPage
    {
        public editNote(string id, string n, string desc)
        {
            InitializeComponent();
            name.Text = n;
            description.Text = desc;
            noteId.Text = id;
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            var note = name.Text;
            var desc = description.Text;
            var data = "{\"name\": \"" + note + "\", \"description\": \"" + desc + "\"}";
            //DIN IP SKAL STÅ HER UNDER MED MINDRE API'EN KØRE I SKYEN!!!!!!!!!!!!!!!!!!!!!!!!!!!
            var result = await ApiCaller.Put("http://192.168.1.54:8080/note/edit/"+noteId.Text, data);
            //var result = await ApiCaller.Put("http://192.168.100.131:8080/note/edit/"+noteId.Text, data);
            if (result.Successful)
            {
                await Navigation.PushModalAsync(new note());
            }
            else
            {
                description.Text = "blablabla";
            }
        }

    }
}