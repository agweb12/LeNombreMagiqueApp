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
	public partial class StarsView : ContentView
	{
		public StarsView ()
		{
			InitializeComponent ();
#pragma warning disable CS4014 // Dans la mesure où cet appel n'est pas attendu, l'exécution de la méthode actuelle continue avant la fin de l'appel
            InfiniteRotation(star1, 5000);
            InfiniteRotation(star2, 7000);
            InfiniteRotation(star3, 9000);
#pragma warning restore CS4014 // Dans la mesure où cet appel n'est pas attendu, l'exécution de la méthode actuelle continue avant la fin de l'appel

        }

        private async Task InfiniteRotation(View view, uint length)
        {
            bool always = true;
            while (always)
            {
                await view.RotateTo(360, length);
                view.Rotation = 0;
            }

        }
    }
}