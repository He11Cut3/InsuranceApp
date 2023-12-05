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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InsuranceApp.Loses
{
	/// <summary>
	/// Логика взаимодействия для Loss.xaml
	/// </summary>
	public partial class Loss : UserControl
	{
		InsuranceCompanyDBEntities _context = new InsuranceCompanyDBEntities();
		
		List<Losses> _list = new List<Losses>();

		public Loss(InsuranceCompanyDBEntities context)
		{
			InitializeComponent();
			_context = context;
			var query = from loss in _context.Losses
						join policy in _context.Policies on loss.PolicyID equals policy.PolicyID
						select new LossViewModel
						{
							ClaimID = loss.ClaimID,
							PolicyName = policy.PoliceName,
							ClaimDate = loss.ClaimDate,
							Description = loss.Description,
							ClaimStatus = loss.ClaimStatus
						};

			LV_.ItemsSource = query.ToList();

		}

		public void Update_Loss()
		{
			var query = from loss in _context.Losses
						join policy in _context.Policies on loss.PolicyID equals policy.PolicyID
						select new LossViewModel
						{
							ClaimID = loss.ClaimID,
							PolicyName = policy.PoliceName,
							ClaimDate = loss.ClaimDate,
							Description = loss.Description,
							ClaimStatus = loss.ClaimStatus
						};

			LV_.ItemsSource = query.ToList();
		}


		private void New_Los_Click(object sender, RoutedEventArgs e)
		{
			New_Los new_Los = new New_Los(_context, this);
			new_Los.ShowDialog();
        }

		private void Los_Edit_Click(object sender, RoutedEventArgs e)
		{
			var button = sender as Button;
			var item = button?.DataContext as LossViewModel;

			if (item != null)
			{
				Edit_Los edit_Los = new Edit_Los(_context, item, this);
				edit_Los.ShowDialog();
			}
			else
			{
				MessageBox.Show("Ошибка редактирования: объект не найден или равен null.");
			}
		}

		private void Los_Del_Click(object sender, RoutedEventArgs e)
		{
			if ((MessageBox.Show("Вы уверены, что хотите удалить информацию?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Warning)) == MessageBoxResult.Yes)
			{
				var button = sender as Button;
				var item = button?.DataContext as LossViewModel;

				if (item != null)
				{
					var lossToRemove = _context.Losses.FirstOrDefault(loss => loss.ClaimID == item.ClaimID);

					if (lossToRemove != null)
					{
						_context.Losses.Remove(lossToRemove);
						_context.SaveChanges();
						Update_Loss();
					}
					else
					{
						MessageBox.Show("Ошибка удаления: объект не найден в базе данных.");
					}
				}
				else
				{
					MessageBox.Show("Ошибка удаления: объект не найден или равен null.");
				}
			}
		}
	}
}
