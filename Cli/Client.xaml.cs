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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InsuranceApp.Cli
{
	/// <summary>
	/// Логика взаимодействия для Client.xaml
	/// </summary>
	public partial class Client : UserControl
	{
		InsuranceCompanyDBEntities _context = new InsuranceCompanyDBEntities();
		List<Clients> _list = new List<Clients>();

		public Client(InsuranceCompanyDBEntities insuranceCompanyDBEntities)
		{
			InitializeComponent();
			_context = insuranceCompanyDBEntities;
			LV_.ItemsSource = _context.Clients.OrderBy(t => t.ClientID).ToList();
		}

		public void Update_Client()
		{
			_list = _context.Clients.ToList();
			LV_.ItemsSource = _list;
		}

		private void New_Client_Click(object sender, RoutedEventArgs e)
		{
			New_Client new_Client = new New_Client(_context, this);
			new_Client.ShowDialog();
        }

		private void Client_Del_Click(object sender, RoutedEventArgs e)
		{
			if ((System.Windows.MessageBox.Show("Вы уверены, что хотите удалить информацию?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Warning)) == MessageBoxResult.Yes)
			{
				var button = sender as Button;
				var item = button.DataContext as Clients;
				_context.Clients.Remove(item);
				_context.SaveChanges();
				Update_Client();
			}
		}

		private void Client_Edit_Click(object sender, RoutedEventArgs e)
		{
			Edit_Client edit_Del_Employ = new Edit_Client(_context, sender, this);
			edit_Del_Employ.ShowDialog();
		}
	}
}
