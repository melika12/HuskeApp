using huskeApi.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            var name = username.Text;
            var pwd = password.Text;
            var data = "{\"name\": \"" + name + "\"password\": \"" + pwd + "\"}";
            //DIN IP SKAL STÅ HER UNDER MED MINDRE API'EN KØRE I SKYEN!!!!!!!!!!!!!!!!!!!!!!!!!!!
            var result = await ApiCaller.Post("http://192.168.1.54:8080/login", data);
            if (result.Successful)
            {
                await Navigation.PushModalAsync(new note());
            }
            else
            {
                password.Text = "blablabla";
            }
        }
    }
}