using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace city_building
{
	public partial class LoadingScreen : Form
	{
		//Delegate for cross thread call to close
		private delegate void CloseDelegate();
		int time = 0;
		//The type of form to be displayed as the splash screen.
		private static LoadingScreen loadingScreen;
		
		static public void ShowLoadingScreen()
		{
			// Make sure it is only launched once.    
			if (loadingScreen != null) return;
			loadingScreen = new LoadingScreen();
			Thread thread = new Thread(new ThreadStart(LoadingScreen.ShowForm));
			thread.IsBackground = true;
			thread.SetApartmentState(ApartmentState.STA);
			thread.Start();
		}

		static private void ShowForm()
		{
			if (loadingScreen != null) Application.Run(loadingScreen);
		}

		static public void CloseForm()
		{
			loadingScreen?.Invoke(new CloseDelegate(LoadingScreen.CloseFormInternal));
		}

		static private void CloseFormInternal()
		{
			if (loadingScreen != null)
			{
				loadingScreen.Close();
				loadingScreen = null;
			};
		}
		public LoadingScreen()
		{
			InitializeComponent();
			
			// choose random integer from 1 to 10
			Random rnd = new Random();
			int r = rnd.Next(1, 5);

			// set hint based on random integer
			switch(r)
			{
				case 1:
					HintRichTextBox.Text = "You can buy resources from the market.";
					break;
				case 2:
					HintRichTextBox.Text = "You can sell resources to the market.";
					break;
				case 3:
					HintRichTextBox.Text = "You can build buildings in the city.";
					break;
				case 4:
					HintRichTextBox.Text = "Rather start with mining, than sell iron for other resources.";
					break;
				case 5:
					HintRichTextBox.Text = "Build a lot towers so you can get strong flow of gold.";
					break;
			}
		
		}

	}
}
