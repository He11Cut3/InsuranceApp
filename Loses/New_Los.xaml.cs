using InsuranceApp.Pol;
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

namespace InsuranceApp.Loses
{
	/// <summary>
	/// Логика взаимодействия для New_Los.xaml
	/// </summary>
	public partial class New_Los : Window
	{
		private InsuranceCompanyDBEntities _context;
		private Loss _uc;
		public New_Los(InsuranceCompanyDBEntities insuranceCompanyDBEntities, Loss loss)
		{
			InitializeComponent();
			_context = insuranceCompanyDBEntities;
			_uc = loss;

			// Получение списка полисов из базы данных
			List<Policies> policies = _context.Policies.ToList();

			// Заполнение ComboBox данными о полисах
			Type.ItemsSource = policies;
			Type.DisplayMemberPath = "PoliceName";
		}


		private void New_Loss_Click(object sender, RoutedEventArgs e)
		{
			if ((System.Windows.MessageBox.Show("Вы уверены, что хотите добавить информацию?", "Добавление", MessageBoxButton.YesNo, MessageBoxImage.Warning)) == MessageBoxResult.Yes)
			{
				Policies selectedPolicy = (Policies)Type.SelectedItem;
				_context.Losses.Add(new Losses()
				{
					PolicyID = selectedPolicy.PolicyID,
					ClaimDate = Date.SelectedDate,
					ClaimStatus = Status.Text,
					Description = Description.Text,
				});

				_context.SaveChanges();
				_uc.Update_Loss();
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
