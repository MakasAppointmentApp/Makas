﻿using MakasUI.Functions;
using MakasUI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MakasUI.Views.CustomerPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GetAppointmentPage : ContentPage
    {
        ViewCell lastCell;

        public GetAppointmentPage(Worker worker, Saloon saloon)
        {
            InitializeComponent();
            datePicker.MinimumDate = DateTime.Now;
            datePicker.MaximumDate = DateTime.Now.AddYears(1);
            ItemFunctions functions = new ItemFunctions();
            functions.backclick(back, Navigation);
            sName.Text = saloon.SaloonName;
            sRate.Text = Convert.ToString(saloon.SaloonRate);
            workerImage.Source = ImageSource.FromStream(() => new MemoryStream(worker.WorkerPhoto)); 
            workerName.Text = worker.WorkerName;
            workerRate.Text = Convert.ToString(worker.WorkerRate);
            var Hours = new List<Hour>
            {
                new Hour { Time = worker.Id.ToString()},
                new Hour { Time = "11:00"},
                new Hour { Time = "12:00"},
                new Hour { Time = "13:00"},
                new Hour { Time = "14:00"},
                new Hour { Time = "15:00"},
                new Hour { Time = "16:00"},
                new Hour { Time = "17:00"},
                new Hour { Time = "18:00"},
                new Hour { Time = "19:00"},
                new Hour { Time = "20:00"},
                new Hour { Time = "21:00"}
            };
            hourList.ItemsSource = Hours;

        }

        private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            var Hours = new List<Hour>
            {
                new Hour { Time = "10:00"},
                new Hour { Time = "11:00"},
                new Hour { Time = "12:00"},
                new Hour { Time = "13:00"},
                new Hour { Time = "14:00"},
                new Hour { Time = "15:00"},
                new Hour { Time = "16:00"},
                new Hour { Time = "17:00"}
            };
            hourList.ItemsSource = Hours;
            //Burada date değiştiğinde backendden yeni date e göre değerler gelecek
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            datePicker.Focus();
        }

        private void ViewCell_Tapped(object sender, EventArgs e)
        {
            if (lastCell != null)
                lastCell.View.BackgroundColor = Color.FromHex("#e8eef1");
            var viewCell = (ViewCell)sender;
            if (viewCell.View != null)
            {
                viewCell.View.BackgroundColor = Color.FromHex("#fa7a5a");
                lastCell = viewCell;
            }
        }
    }
}