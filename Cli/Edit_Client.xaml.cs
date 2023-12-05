using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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

namespace InsuranceApp.Cli
{
	/// <summary>
	/// Логика взаимодействия для Edit_Client.xaml
	/// </summary>
	public partial class Edit_Client : Window
	{

		private InsuranceCompanyDBEntities _context;
		private Client employ;
		private Clients _employees;

		public Edit_Client(InsuranceCompanyDBEntities insuranceCompanyDBEntities, object o, Client clients)
		{
			InitializeComponent();
			_context = insuranceCompanyDBEntities;
			_employees = (o as Button).DataContext as Clients;
			employ = clients;

			FirstName.Text = _employees.FirstName;
			LastName.Text = _employees.LastName;
			Adress.Text = _employees.Address;
			ContactInfo.Text = _employees.ContactInfo;
		}
		private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key >= Key.D0 && e.Key <= Key.D9)
			{
				e.Handled = true;
			}
		}

		private void Edit_Clients_Click(object sender, RoutedEventArgs e)
		{
			if ((MessageBox.Show("Вы уверены, что хотите изменить информацию?", "Изменение", MessageBoxButton.YesNo, MessageBoxImage.Warning)) == MessageBoxResult.Yes)
			{
					_employees.FirstName = FirstName.Text;
					_employees.LastName = LastName.Text;
					_employees.Address = Adress.Text;
					_employees.ContactInfo = ContactInfo.Text;

					_context.SaveChanges();
					employ.Update_Client();
					this.Close();
			}
		}
		private void ComeBack_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
	}
}
