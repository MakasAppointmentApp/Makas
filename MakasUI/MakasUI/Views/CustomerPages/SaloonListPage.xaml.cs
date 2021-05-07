using System;
using MakasUI.Functions;
using MakasUI.Models;
using MakasUI.Models.DtosForCustomer;
using MakasUI.Services.CustomerServices;
using MakasUI.Views.CustomerPages;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MakasUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SaloonListPage : ContentPage
    {
        SearchSaloonsDto _searched;

        GetSaloonsByLocationService service = new GetSaloonsByLocationService();

        public SaloonListPage(SearchSaloonsDto searched)
        {

            InitializeComponent();
            _searched = searched;
            ItemFunctions functions = new ItemFunctions();
            functions.backclick(back, Navigation);


        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var response = await service.ListedSaloonLocationAsync(_searched);
            KuaforListView.ItemsSource = response;
        }


        private async void Go_Profile_Clicked(object sender, EventArgs e)
        {
            ImageButton btn = (ImageButton)sender;

            Saloon ob = btn.CommandParameter as Saloon;

            await Navigation.PushAsync(new SaloonProfilePage(ob));
            //await Navigation.PushAsync(new SaloonProfilePage());
        }
    }
}