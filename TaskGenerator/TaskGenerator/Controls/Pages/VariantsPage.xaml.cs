﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TaskGenerator;

namespace TaskGenerator.Controls.Pages
{
	/// <summary>
	/// Логика взаимодействия для VariantsPage.xaml
	/// </summary>
	public partial class VariantsPage : UserControl
	{
		public VariantsPage()
		{
			InitializeComponent();
		}

		public delegate void onVariantChange(int v);

		public event onVariantChange variantChange;

		private void TaskCard_Loaded(object sender, RoutedEventArgs e)
		{

		}


		private void onSelect(object sender, RoutedEventArgs e)
		{
			var index = (int)(((RadioButton)sender).Tag);
			Console.WriteLine(index);
			variantChange(index + 1);
		}



		public void presentVariants(List<Variant> vars)
		{
			panel.Children.RemoveRange(1,panel.Children.Count - 1);

			for (int i = 0; i < vars.Count; i++){
				var card = new VariantCard();
				card.Padding = new Thickness(12, 6, 12, 6);
				card.radioBtn.Tag = i;
				if (i == 0) {
					card.radioBtn.IsChecked = true;
				}
				card.radioBtn.Checked += onSelect;
				panel.Children.Add(card);
				card.setName("Вариант " + (i + 1));

			}
		}
	}


}
