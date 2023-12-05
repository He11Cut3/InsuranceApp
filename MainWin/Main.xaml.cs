using InsuranceApp.Authorization;
using InsuranceApp.Cli;
using InsuranceApp.Fin;
using InsuranceApp.Loses;
using InsuranceApp.Pol;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace InsuranceApp.MainWin
{
	/// <summary>
	/// Логика взаимодействия для Main.xaml
	/// </summary>
	public partial class Main : Window
	{
		InsuranceCompanyDBEntities _context = new InsuranceCompanyDBEntities();

		public Main()
		{
			InitializeComponent();
		}





		public bool IsDarkTheme { get; set; }
		private readonly PaletteHelper paletteHelper = new PaletteHelper();
		//===================================>

		protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
		{
			base.OnMouseLeftButtonDown(e);
			DragMove();
		}

		private void toggleTheme(object sender, RoutedEventArgs e)
		{
			//Theme Code ========================>
			ITheme theme = paletteHelper.GetTheme();
			if (IsDarkTheme = theme.GetBaseTheme() == BaseTheme.Dark)
			{
				IsDarkTheme = false;
				theme.SetBaseTheme(Theme.Light);
			}
			else
			{
				IsDarkTheme = true;
				theme.SetBaseTheme(Theme.Dark);
			}

			paletteHelper.SetTheme(theme);
			//===================================>
		}

		private void Polis_Click(object sender, RoutedEventArgs e)
		{
			Client_UC.Children.Clear();
			Finance_UC.Children.Clear();
			Police_UC.Children.Clear();
			Losses_UC.Children.Clear();

			Polic polis = new Polic(_context);
			Police_UC.Children.Add(polis);	
		}

		private void Finance_Click(object sender, RoutedEventArgs e)
		{
			Client_UC.Children.Clear();
			Finance_UC.Children.Clear();
			Police_UC.Children.Clear();
			Losses_UC.Children.Clear();

			Financ financ = new Financ(_context);
			Finance_UC.Children.Add(financ);
		}

		private void Losses_Click(object sender, RoutedEventArgs e)
		{
			Client_UC.Children.Clear();
			Finance_UC.Children.Clear();
			Police_UC.Children.Clear();
			Losses_UC.Children.Clear();

			Loss losses = new Loss(_context);
			Losses_UC.Children.Add(losses);
		}

		private void Client_Click(object sender, RoutedEventArgs e)
		{
			Client_UC.Children.Clear();
			Finance_UC.Children.Clear();
			Police_UC.Children.Clear();
			Losses_UC.Children.Clear();

			Client client_UC = new Client(_context);
			Client_UC.Children.Add(client_UC);
		}

		private void ComeBack_Click(object sender, RoutedEventArgs e)
		{
			if ((System.Windows.MessageBox.Show("Вы действительно хотите выйти?", "Выход", MessageBoxButton.YesNo, MessageBoxImage.Warning)) == MessageBoxResult.Yes)
			{
				Authorization_Window authorization_Window = new Authorization_Window();
				this.Close();
				authorization_Window.ShowDialog();
			}
		}

	}
}
