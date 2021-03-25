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

        public CommentsPage(string saloonName, string saloonRate)
        {

            InitializeComponent();
            this.sName.Text = saloonName;          
            this.sRate.Text = saloonRate;

            ItemFunctions functions = new ItemFunctions();
            functions.backclick(back, Navigation);
        
            var Comments = new List<Comment>
            { 
            new Comment {CustomerComment = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", Date = "3", CustomerName = "AliOsman", CustomerRate = 4 },
            new Comment { CustomerComment = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequnon proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", Date = "4", CustomerName = "MuhammedG", CustomerRate = 6 },
            new Comment { CustomerComment = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor lpa qui officia deserunt mollit anim id est laborum.", Date = "5", CustomerName = "Meorbag", CustomerRate = 2 },
            new Comment { CustomerComment = "Muhteşem bir mekan çalışanları çok kaliteli :)", Date = "6", CustomerName = "Danny", CustomerRate = 9 }

            };
            CommentsListView.ItemsSource  = Comments;
        }

    }
}