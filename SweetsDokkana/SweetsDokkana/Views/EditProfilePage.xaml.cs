﻿using SQLite;
using SweetsDokkana.Models;
using SweetsDokkana.Presistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace SweetsDokkana.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditProfilePage : ContentPage
	{
        SqlHelper sqlHelper = new SqlHelper();

        public EditProfilePage ()
		{
			InitializeComponent ();
		}

        private void BtnUpdate_Clicked(object sender, EventArgs e)
        {

        }
    }
}