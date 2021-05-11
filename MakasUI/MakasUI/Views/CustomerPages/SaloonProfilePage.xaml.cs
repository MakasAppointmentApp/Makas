using MakasUI.Functions;
using MakasUI.Models;
using MakasUI.Models.DtosForSaloon;
using MakasUI.Services.SaloonServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MakasUI.Views.CustomerPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SaloonProfilePage : ContentPage
    {
        Saloon presentSaloon;
        bool isFavorited;
        SaloonRestService service = new SaloonRestService();
        public ObservableCollection<Worker> WorkersCollection { get; set; }
        public ObservableCollection<AddPriceDto> PricesCollection { get; set; }
        private int _saloonId;
        public SaloonProfilePage(int Id)
        {
            _saloonId = Id;
            InitializeComponent();
            ItemFunctions functions = new ItemFunctions();
            functions.backclick(back, Navigation);
            functions.ButtonsLabelClick(labelComment, butComment);
            functions.ButtonsLabelClick(labelFav, butFav);
            WorkersCollection = new ObservableCollection<Worker>();
            PricesCollection = new ObservableCollection<AddPriceDto>();
        }
        private async Task GetSaloonProfile()
        {
            var saloon = await service.GetSaloonAsync(_saloonId);
            PricesCollection.Clear();
            WorkersCollection.Clear();
            foreach (var item in saloon.Prices)
            {
                PricesCollection.Add(new AddPriceDto { PriceName = item.PriceName, PriceAmount = item.PriceAmount });
            }
            foreach (var item in saloon.Workers)
            {
                WorkersCollection.Add(new Worker { WorkerName = item.WorkerName, WorkerPhoto = item.WorkerPhoto, WorkerRate = item.WorkerRate });
            }
            presentSaloon = saloon;
            workers.ItemsSource = WorkersCollection;
            PriceListView.ItemsSource = PricesCollection;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await GetSaloonProfile();
            await isFavorite();
            sName.Text = presentSaloon.SaloonName;
            sRate.Text = presentSaloon.SaloonRate.ToString();
            sImage.Source = ImageSource.FromStream(() => new MemoryStream(presentSaloon.SaloonImage));
            addressLabel.Text = presentSaloon.SaloonLocation;
            labelComment.Text = $"{presentSaloon.Reviews.Count()} Yorum";

            if (isFavorited==true)
            {
                butFav.Source = "heartFilled.png";
            }
            else
            {
                butFav.Source = "heartEmpty.png";
            }
        }
        private async void Comments_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CommentsPage(sName.Text, sRate.Text, presentSaloon.Reviews));
        }
        private async void Get_Appointment_Clicked(object sender, EventArgs e)
        {

            var button = sender as Button;
            var model = button.BindingContext as Worker;
            var worker = WorkersCollection.FirstOrDefault(a => a.WorkerName == model.WorkerName && a.WorkerRate == model.WorkerRate);
            model.Id = worker.Id;
            await button.ScaleTo(1.2, 250, Easing.SpringIn);
            var saloon = new Saloon { Id=presentSaloon.Id,SaloonName = sName.Text, SaloonRate = Convert.ToDouble(sRate.Text) };
            await Navigation.PushAsync(new GetAppointmentPage(model, saloon));
            await button.ScaleTo(1.0, 50, Easing.SpringOut);
        }

        private async void Map_Button_Clicked(object sender, EventArgs e)
        {
            if (Device.RuntimePlatform == Device.iOS)
            {

                await Launcher.OpenAsync("http://maps.apple.com/?q=" + addressLabel.Text);
            }
            else if (Device.RuntimePlatform == Device.Android)
            {
                // open the maps app directly
                await Launcher.OpenAsync("geo:0,0?q=" + addressLabel.Text);
            }
        }
        private async Task isFavorite()
        {
            var app = Application.Current as App;
            bool isFav = await App.customerManager.IsFavoriteByCustomer(presentSaloon.Id, Convert.ToInt32(app.USER_ID));
            isFavorited = isFav;
        }
    }
}