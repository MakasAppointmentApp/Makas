using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MakasUI.Functions;
using MakasUI.Models;
using MakasUI.Models.DtosForSaloon;
using MakasUI.Services.SaloonServices;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MakasUI.Views.SaloonPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePageSaloon : ContentPage
    {
        int saloonId = 2;
        Saloon presentSaloon;
        
        SaloonProfileService service = new SaloonProfileService();
        public ObservableCollection<Worker> WorkersCollection { get; set; }
        public ObservableCollection<AddPriceDto> PricesCollection { get; set; }
        public ProfilePageSaloon()
        {
            InitializeComponent();
            ItemFunctions functions = new ItemFunctions();
            functions.ButtonsLabelClick(commentLabel,commentButton);
            WorkersCollection = new ObservableCollection<Worker>();
            PricesCollection = new ObservableCollection<AddPriceDto>();
            
            
           

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await GetSaloonProfile();
            sName.Text = presentSaloon.SaloonName;
            sRate.Text = presentSaloon.SaloonRate.ToString();
            sImage.Source = ImageSource.FromStream(() => new MemoryStream(presentSaloon.SaloonImage));
            sLocation.Text = presentSaloon.SaloonLocation;
            commentLabel.Text = $"{presentSaloon.Reviews.Count()} Yorum";

        }

        private async Task GetSaloonProfile()
        {
            var saloon = await service.GetSaloonAsync(saloonId);
            foreach (var item in saloon.Prices)
            {
                PricesCollection.Add(new AddPriceDto { PriceName = item.PriceName, PriceAmount = item.PriceAmount });
            }
            foreach (var item in saloon.Workers)
            {
                WorkersCollection.Add(new Worker { WorkerName = item.WorkerName, WorkerPhoto = item.WorkerPhoto, WorkerRate=item.WorkerRate });
            }
            presentSaloon = saloon;
            workers.ItemsSource = WorkersCollection;
            PriceListView.ItemsSource = PricesCollection;
        }

        private async void Comments_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CommentsPage(sName.Text, sRate.Text, presentSaloon.Reviews));
        }

        private async void EditClicked(object sender, EventArgs e)
        {
                
                await Navigation.PushAsync(new EditSaloonPage(sName.Text, sImage.Source, sLocation.Text, presentSaloon.Id));
        }
    }
}