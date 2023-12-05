using InsuranceApp.Cli;
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

namespace InsuranceApp.Pol
{
	/// <summary>
	/// Логика взаимодействия для Polic.xaml
	/// </summary>
	public partial class Polic : UserControl
	{
		InsuranceCompanyDBEntities _context = new InsuranceCompanyDBEntities();
		List<Policies> _list = new List<Policies>();

		public Polic(InsuranceCompanyDBEntities insuranceCompanyDBEntities)
		{
			InitializeComponent();
			_context = insuranceCompanyDBEntities;
			LV_.ItemsSource = _context.Policies.OrderBy(t => t.PolicyID).ToList();
		}

		public void Update_Polic()
		{
			_list = _context.Policies.ToList();
			LV_.ItemsSource = _list;
		}

		private void New_Pol_Click(object sender, RoutedEventArgs e)
		{
			New_Polic new_Polic = new New_Polic(_context, this);
			new_Polic.ShowDialog();
		}

		private void Pol_Edit_Click(object sender, RoutedEventArgs e)
		{
			Edit_Polic edit_Polic = new Edit_Polic(_context, sender, this);
			edit_Polic.ShowDialog();
		}

		private void Pol_Del_Click(object sender, RoutedEventArgs e)
		{
			if ((System.Windows.MessageBox.Show("Вы уверены, что хотите удалить информацию?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Warning)) == MessageBoxResult.Yes)
			{
				var button = sender as Button;
				var item = button.DataContext as Policies;
				_context.Policies.Remove(item);
				_context.SaveChanges();
				Update_Polic();
			}
		}
	}
}
