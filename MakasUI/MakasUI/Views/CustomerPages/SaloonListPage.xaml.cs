using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MakasUI.Functions;
using MakasUI.Models;
using MakasUI.Models.DtosForCustomer;
using MakasUI.Services.CustomerServices;
using MakasUI.ViewModels;
using MakasUI.Views.CustomerPages;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MakasUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SaloonListPage : ContentPage
    {
        SearchSaloonsDto _searched;
        SaloonListViewModel viewModel = new SaloonListViewModel();

        public SaloonListPage(SearchSaloonsDto searched)
        {

            InitializeComponent();
            _searched = searched;
            ItemFunctions functions = new ItemFunctions();
            functions.backclick(back, Navigation);


            KuaforListView.ItemsSource = viewModel.ListedSaloon;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await viewModel.getItems(_searched);
        }
        

        private async void Go_Profile_Clicked(object sender, EventArgs e)
        {
            ImageButton btn = (ImageButton)sender;
            int Id = (int)btn.CommandParameter;
            await Navigation.PushAsync(new SaloonProfilePage(Id));
        }
    }
}