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
	/// Логика взаимодействия для Edit_Los.xaml
	/// </summary>
	public partial class Edit_Los : Window
	{
		private InsuranceCompanyDBEntities _context;

		private Losses polic;
		LossViewModel lossViewModel;
		private Loss policies;

		public Edit_Los(InsuranceCompanyDBEntities insuranceCompanyDBEntities, LossViewModel loss, Loss loss1)
		{
			InitializeComponent();
			_context = insuranceCompanyDBEntities;
			lossViewModel = loss;
			policies = loss1;


			// Получение списка полисов из базы данных
			List<Policies> poliscies = _context.Policies.ToList();

			// Заполнение ComboBox данными о полисах
			Type.ItemsSource = poliscies;
			Type.DisplayMemberPath = "PoliceName";

			Date.Text = lossViewModel.ClaimDate.ToString();
			Status.Text = lossViewModel.ClaimStatus.ToString();
			Description.Text = lossViewModel.Description.ToString();


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


		private void Edit_Loss_Click(object sender, RoutedEventArgs e)
		{
			Policies selectedPolicy = (Policies)Type.SelectedItem;

			// Проверяем, выбран ли какой-то элемент в ComboBox
			if (selectedPolicy == null)
			{
				MessageBox.Show("Пожалуйста, выберите полис.", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
				return; // Прерываем выполнение метода, так как полис не выбран
			}

			if ((MessageBox.Show("Вы уверены, что хотите изменить информацию?", "Изменение", MessageBoxButton.YesNo, MessageBoxImage.Warning)) == MessageBoxResult.Yes)
			{
				var editedLoss = _context.Losses.FirstOrDefault(loss => loss.ClaimID == lossViewModel.ClaimID);

				// Устанавливаем значения только если они не равны null
				editedLoss.PolicyID = selectedPolicy?.PolicyID;
				editedLoss.ClaimDate = Date.SelectedDate;
				editedLoss.ClaimStatus = (Status.SelectedItem as ComboBoxItem)?.Content?.ToString();
				editedLoss.Description = Description.Text;

				_context.SaveChanges();
				policies.Update_Loss();
				this.Close();
			}
		}
	}
}
