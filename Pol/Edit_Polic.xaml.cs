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
	/// Логика взаимодействия для Edit_Polic.xaml
	/// </summary>
	public partial class Edit_Polic : Window
	{
		private InsuranceCompanyDBEntities _context;

		private Polic polic;

		private Policies policies;

		public Edit_Polic( InsuranceCompanyDBEntities context, object o, Polic polidc)
		{
			InitializeComponent();
			_context = context;
			policies = (o as Button).DataContext as Policies;
			polic = polidc;

			Number.Text = policies.PoliceName;
			Type.Text = policies.PolicyType;
			DateS.Text = policies.StartDate.ToString();
			DateDo.Text = policies.EndDate.ToString();
			Status.Text = policies.Status;
		}

		private void Edit_Pols_Click(object sender, RoutedEventArgs e)
		{
			if ((MessageBox.Show("Вы уверены, что хотите изменить информацию?", "Изменение", MessageBoxButton.YesNo, MessageBoxImage.Warning)) == MessageBoxResult.Yes)
			{
				policies.PoliceName = Number.Text;
				policies.PolicyType = (Type.SelectedItem as ComboBoxItem)?.Content?.ToString();
				policies.StartDate = DateS.SelectedDate;
				policies.EndDate = DateDo.SelectedDate;
				policies.Status = (Status.SelectedItem as ComboBoxItem)?.Content?.ToString();

				_context.SaveChanges();
				polic.Update_Polic();
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

		private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key >= Key.D0 && e.Key <= Key.D9)
			{
				e.Handled = true;
			}
		}

		private void ComeBack_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
	}
}
