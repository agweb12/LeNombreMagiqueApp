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
	public partial class GamePage : ContentPage
	{
		const int NB_MAGIQUE_MIN = 1;
		const int NB_MAGIQUE_MAX =  10;

		int NombreMagique = 0;
		public GamePage ()
		{
			InitializeComponent ();
            //POUR RETIRER LA NAVIGATION PAGE AUTOMATIQUEMENT GENERER PAR LA FONCTION NAVIGATION :
            NavigationPage.SetHasNavigationBar(this, false);


            NombreMagique = new Random().Next(NB_MAGIQUE_MIN, NB_MAGIQUE_MAX);
			minMaxLabel.Text = "Devinez le nombre entre " + NB_MAGIQUE_MIN + " ET " + NB_MAGIQUE_MAX;
        }

        private void ButtonDevinerClicked(object sender, EventArgs e)
        {
			if (String.IsNullOrWhiteSpace(numberEntry.Text))
			{
				DisplayAlert("STOP", "Vous devez rentrer un nombre", "Fermer");
                numberEntry.Focus();
                return;
			}

			int nbUtilisateur = 0;

            try
			{
				nbUtilisateur = Int32.Parse(numberEntry.Text);
            }
			catch(Exception)
			{
				DisplayAlert("STOP", "Vous devez rentrer uniquement des chiffres", "Fermer");
				numberEntry.Text = "";
                numberEntry.Focus();
                return;
			}
			if((nbUtilisateur < NB_MAGIQUE_MIN) || (nbUtilisateur > NB_MAGIQUE_MAX))
			{
                DisplayAlert("STOP", "Vous devez rentrer un nombre entre " + NB_MAGIQUE_MIN + " et " + NB_MAGIQUE_MAX, "Fermer");
                numberEntry.Text = "";
                numberEntry.Focus();
                return;
            }
			if(NombreMagique > nbUtilisateur)
			{
				DisplayAlert("Oops", "Le nombre magique est supérieur à " + nbUtilisateur, "Réessayer");
                numberEntry.Text = "";
                numberEntry.Focus();
                return;
			}
			if(NombreMagique < nbUtilisateur)
			{
				DisplayAlert("Oops", "Le nombre magique est INFERIEUR à " + nbUtilisateur, "Réessayer");
                numberEntry.Text = "";
                numberEntry.Focus();
                return;
			}
			if(NombreMagique == nbUtilisateur)
			{
                WinAction();
                return;
			}

		}

		private async Task WinAction()
		{
			await Navigation.PushAsync(new WinPage(NombreMagique));
            //await DisplayAlert("Gagné", "Tu as trouvé le nombre magique : " + NombreMagique, "Recommence");
			//await this.Navigation.PopAsync();
        }
    }
}