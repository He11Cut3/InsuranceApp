﻿using InsuranceApp.MainWin;
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

namespace InsuranceApp.Authorization
{
	/// <summary>
	/// Логика взаимодействия для Authorization_Window.xaml
	/// </summary>
	public partial class Authorization_Window : Window
	{
		InsuranceCompanyDBEntities _context = new InsuranceCompanyDBEntities();

		public string Login { get; set; }

		public Authorization_Window()
		{
			InitializeComponent();
		}

		//Theme Code ========================>
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

		private void exitApp(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();
		}

		private void loginBtn_Click(object sender, RoutedEventArgs e)
		{
			string login = txtUsername.Text;
			string password = txtPassword.Password;
			var user = _context.Users.FirstOrDefault(u => u.Login == login && u.Password == password);
			if (user == null)
			{
				MessageBox.Show("Пользователь не найден");
			}
			else
			{
				Main main = new Main();
				this.Close();
				main.ShowDialog();
			}
		}
	}
}
