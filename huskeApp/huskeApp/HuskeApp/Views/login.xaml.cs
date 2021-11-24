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
    public partial class login : ContentPage
    {
        public login()
        {
            InitializeComponent();
            GetLogin();
        }
        private async void GetLogin()
        {
            var url = $"http://localhost:8080/login";

            var result = await ApiCaller.Get(url);

            if (result.Successful)
            {
                try
                {

                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                await DisplayAlert("note", "No notes found", "OK");
            }
        }

        private async void GetNotes()
        {
            var url = $"http://http://localhost:8080/notes/index";
            var result = await ApiCaller.Get(url);

            if (result.Successful)
            {
                try
                {

                }
                catch (Exception ex)
                {
                    await DisplayAlert("note Info", ex.Message, "OK");
                }
            }
            else
            {
                await DisplayAlert("note Info", "No notes found", "OK");
            }
        }
    }
}