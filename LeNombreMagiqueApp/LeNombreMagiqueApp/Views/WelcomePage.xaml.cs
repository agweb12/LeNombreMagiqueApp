using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LeNombreMagiqueApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WelcomePage : ContentPage
	{
		public WelcomePage ()
		{
			InitializeComponent ();
			//POUR RETIRER LA NAVIGATION PAGE AUTOMATIQUEMENT GENERER PAR LA FONCTION NAVIGATION :
			NavigationPage.SetHasNavigationBar(this, false);

#pragma warning disable CS4014 // Dans la mesure où cet appel n'est pas attendu, l'exécution de la méthode actuelle continue avant la fin de l'appel
            InfiniteScale(playButton, 500);
#pragma warning restore CS4014 // Dans la mesure où cet appel n'est pas attendu, l'exécution de la méthode actuelle continue avant la fin de l'appel
        }

        private async Task InfiniteScale(View view, uint length)
        {
            bool always = true;
            while (always)
            {
                await view.ScaleTo(1.1, length);
                await view.ScaleTo(1.0, length);
            }

        }

        private void ButtonJouerClicked(object sender, EventArgs e)
		{
			this.Navigation.PushAsync(new GamePage());
		}


    }
}