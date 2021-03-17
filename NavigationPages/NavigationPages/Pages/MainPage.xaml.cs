using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NavigationPages.Pages
{
	/// <summary>
	/// Логика взаимодействия для MainPage.xaml
	/// </summary>
	public partial class MainPage : Page
	{
		private Frame FrmMain;

		public MainPage()
		{
			InitializeComponent();

			FrmMain = (Application.Current.MainWindow as MainWindow).FrmMain;

			Loaded += (object sender, RoutedEventArgs e) =>
			{
				Debug.WriteLine("Call: " + Title);
				if (FrmMain.BackStack != null)
					foreach (JournalEntry page in FrmMain.BackStack)
						Debug.WriteLine("BackStack: " + page.Name);
				Debug.WriteLine("Current: " + Title);
				if (FrmMain.ForwardStack != null)
					foreach (JournalEntry page in FrmMain.ForwardStack)
						Debug.WriteLine("BackStack: " + page.Name);
			};

			BtnBack.Click += (object sender, RoutedEventArgs e) =>
			{
				if (FrmMain.CanGoBack)
					FrmMain.GoBack();
				else
					MessageBox.Show("Stack empty.", "Warning");
			};

			BtnForward.Click += (object sender, RoutedEventArgs e) =>
			{
				FrmMain.Navigate(new ContentPage());
			};
		}
	}
}
