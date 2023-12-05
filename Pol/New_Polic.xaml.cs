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

namespace InsuranceApp.Pol
{
	/// <summary>
	/// Логика взаимодействия для New_Polic.xaml
	/// </summary>
	public partial class New_Polic : Window
	{
		private InsuranceCompanyDBEntities _context;

		private Polic _uc;

		public New_Polic(InsuranceCompanyDBEntities context, Polic policies)
		{
			InitializeComponent();
			_context = context;
			_uc = policies;
		}

		private void New_Pols_Click(object sender, RoutedEventArgs e)
		{
			if ((System.Windows.MessageBox.Show("Вы уверены, что хотите добавить информацию?", "Добавление", MessageBoxButton.YesNo, MessageBoxImage.Warning)) == MessageBoxResult.Yes)
			{
					_context.Policies.Add(new Policies()
					{
						PoliceName = Number.Text,
						PolicyType = (Type.SelectedItem as ComboBoxItem)?.Content?.ToString(),
						StartDate = DateS.SelectedDate,
						EndDate = DateDo.SelectedDate,
						Status = (Status.SelectedItem as ComboBoxItem)?.Content?.ToString(),
					});

					_context.SaveChanges();
					_uc.Update_Polic();
					this.Close();
			}
		}

		private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
		{
			DatePicker datePicker = sender as DatePicker;
			if (datePicker != null && datePicker.SelectedDate != null)
			{
				datePicker.SelectedDate = DateTime.ParseExact(datePicker.SelectedDate.Value.ToString("dd/MM/yyyy"), "dd/MM/yyyy", null);
			}
		}
		private void ComeBack_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

	}
}
