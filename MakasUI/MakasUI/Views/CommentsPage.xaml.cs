using MakasUI.Functions;
using MakasUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MakasUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CommentsPage : ContentPage
    {

        public CommentsPage()
        {
            InitializeComponent();
            ItemFunctions functions = new ItemFunctions();
            functions.backclick(back, Navigation);
        
        }
        public CommentsPage(string saloonName, string saloonRate, List<Review> comments)
        {
            InitializeComponent();
            this.sName.Text = saloonName;
            this.sRate.Text = saloonRate;

            ItemFunctions functions = new ItemFunctions();
            functions.backclick(back, Navigation);
            CommentsListView.ItemsSource = comments;
        }

    }
}