﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LeNombreMagiqueApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WinPage : ContentPage
	{
		public WinPage() : this(5)
		{

		}
		public WinPage (int nombreMagique)
		{
			InitializeComponent ();
			NavigationPage.SetHasNavigationBar(this, false);

			mainLayout.Scale = 0.7;
            mainLayout.ScaleTo(1.4, 500, Easing.BounceIn);

			magicNumberLabel.Text = "Le nombre magique était : " + nombreMagique;

            NavigateBackWelcomePage();

        }

		private async Task NavigateBackWelcomePage()
		{
			await Task.Delay(3000);
			await Navigation.PopToRootAsync();
		}
	}
}