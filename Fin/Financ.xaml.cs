﻿using InsuranceApp.Cli;
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

namespace InsuranceApp.Fin
{
	/// <summary>
	/// Логика взаимодействия для Financ.xaml
	/// </summary>
	public partial class Financ : UserControl
	{
		InsuranceCompanyDBEntities _context = new InsuranceCompanyDBEntities();
		List<Finances> _list = new List<Finances>();

		public Financ(InsuranceCompanyDBEntities insuranceCompanyDBEntities)
		{
			InitializeComponent();
			_context = insuranceCompanyDBEntities;
			LV_.ItemsSource = _context.Finances.OrderBy(t => t.OperationID).ToList();
		}
		public void Update_Fin()
		{
			_list = _context.Finances.ToList();
			LV_.ItemsSource = _list;
		}

		private void New_Fin_Click(object sender, RoutedEventArgs e)
		{
			New_Fin new_Fin = new New_Fin(_context, this);
			new_Fin.ShowDialog();
		}

		private void Fin_Edit_Click(object sender, RoutedEventArgs e)
		{
			Edit_Fin edit_Fin = new Edit_Fin(_context, sender, this);
			edit_Fin.ShowDialog();
		}

		private void Fin_Del_Click(object sender, RoutedEventArgs e)
		{
			if ((System.Windows.MessageBox.Show("Вы уверены, что хотите удалить информацию?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Warning)) == MessageBoxResult.Yes)
			{
				var button = sender as Button;
				var item = button.DataContext as Finances;
				_context.Finances.Remove(item);
				_context.SaveChanges();
				Update_Fin();
			}
		}
	}
}
