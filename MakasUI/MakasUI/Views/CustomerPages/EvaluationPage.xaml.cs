﻿using MakasUI.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MakasUI.Views.CustomerPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EvaluationPage : ContentPage
    {
         
        public EvaluationPage()
        {
            InitializeComponent();                     
            ItemFunctions functions = new ItemFunctions();
            functions.backclick(back, Navigation);

        }
    }
}