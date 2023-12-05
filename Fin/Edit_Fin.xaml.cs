using InsuranceApp.Cli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Pkcs;
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

namespace InsuranceApp.Fin
{
	/// <summary>
	/// Логика взаимодействия для Edit_Fin.xaml
	/// </summary>
	public partial class Edit_Fin : Window
	{

		private InsuranceCompanyDBEntities _context;
		private Financ employ;
		private Finances _employees;

		public Edit_Fin(InsuranceCompanyDBEntities insuranceCompanyDBEntities, object o, Financ financ)
		{
			InitializeComponent();
			_context = insuranceCompanyDBEntities;
			_employees = (o as Button).DataContext as Finances;
			employ = financ;

			Type.Text = _employees.OperationType;
			Date.Text = _employees.OperationDate.ToString();
			Amout.Text = _employees.Amount.ToString();
			Description.Text = _employees.Description;
		}

		private void Edit_Fin_but_Click(object sender, RoutedEventArgs e)
		{
			


			if ((MessageBox.Show("Вы уверены, что хотите изменить информацию?", "Изменение", MessageBoxButton.YesNo, MessageBoxImage.Warning)) == MessageBoxResult.Yes)
			{
				if (decimal.TryParse(Amout.Text, out decimal amount))
				{
					_employees.OperationType = (Type.SelectedItem as ComboBoxItem)?.Content?.ToString();
					_employees.OperationDate = Date.SelectedDate;
					_employees.Amount = amount;
					_employees.Description = Description.Text;

					_context.SaveChanges();
					employ.Update_Fin();
					this.Close();
				}

				
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

		private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			// Проверка, является ли введенный текст числом
			if (!IsNumeric(e.Text))
			{
				e.Handled = true; // Если не числовой ввод, игнорировать ввод
			}
		}

		private bool IsNumeric(string text)
		{
			return int.TryParse(text, out _);
		}

		private void ComeBack_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
        }
    }
}
