using HuskeApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace HuskeApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}