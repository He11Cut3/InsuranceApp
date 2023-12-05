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

namespace InsuranceApp.Cli
{
	/// <summary>
	/// Логика взаимодействия для New_Client.xaml
	/// </summary>
	public partial class New_Client : Window
	{
		private InsuranceCompanyDBEntities _context;

		private Client _uc;

		public New_Client(InsuranceCompanyDBEntities context, Client uc)
		{
			InitializeComponent();
			_context = context;
			_uc = uc;
		}

		private void New_Clients_Click(object sender, RoutedEventArgs e)
		{
			if ((System.Windows.MessageBox.Show("Вы уверены, что хотите добавить информацию?", "Добавление", MessageBoxButton.YesNo, MessageBoxImage.Warning)) == MessageBoxResult.Yes)
			{
					_context.Clients.Add(new Clients()
					{
						FirstName = FirstName.Text,
						LastName = LastName.Text,
						Address = Adress.Text,
						ContactInfo = ContactInfo.Text,
					});

					_context.SaveChanges();
					_uc.Update_Client();
					this.Close();
			}
		}

		private void ComeBack_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
	}
}
