using System.ComponentModel;
using Xamarin.Forms;
using huskeApp.ViewModels;

namespace huskeApp.Views
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