using huskeApi.Helper;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HuskeApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class addNote : ContentPage
    {
        public addNote()
        {
            InitializeComponent();
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            var note = name.Text;
            var desc = description.Text;
            var data = "{\"name\": \"" + note + "\", \"description\": \"" + desc + "\"}";
            //DIN IP SKAL STÅ HER UNDER MED MINDRE API'EN KØRE I SKYEN!!!!!!!!!!!!!!!!!!!!!!!!!!!
            var result = await ApiCaller.Post("http://192.168.1.54:8080/note/add", data);
            //var result = await ApiCaller.Post("http://192.168.100.131:8080/note/add", data);
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