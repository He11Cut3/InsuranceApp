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
	/// Логика взаимодействия для New_Fin.xaml
	/// </summary>
	public partial class New_Fin : Window
	{
		private InsuranceCompanyDBEntities _context;

		private Financ _uc;

		public New_Fin(InsuranceCompanyDBEntities insuranceCompanyDBEntities, Financ financ)
		{
			InitializeComponent();
			_context = insuranceCompanyDBEntities;
			_uc = financ;
		}

		private void New_Fin_Click(object sender, RoutedEventArgs e)
		{
			if ((System.Windows.MessageBox.Show("Вы уверены, что хотите добавить информацию?", "Добавление", MessageBoxButton.YesNo, MessageBoxImage.Warning)) == MessageBoxResult.Yes)
			{
				if (decimal.TryParse(Amout.Text, out decimal amount))
				{
					_context.Finances.Add(new Finances()
					{
						OperationType = (Type.SelectedItem as ComboBoxItem)?.Content?.ToString(),
						OperationDate = Date.SelectedDate,
						Amount = amount,
						Description = Description.Text,
					});

					_context.SaveChanges();
					_uc.Update_Fin();
					this.Close();
				}
				else
				{
					MessageBox.Show("Введите корректное значение для суммы операции.");
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
