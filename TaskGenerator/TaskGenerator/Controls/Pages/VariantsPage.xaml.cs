using System;
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
			variantChange(index);
		}

		private void onExport(object sender, RoutedEventArgs e)
        {
			Console.WriteLine("test");
			var variantList = ((MainWindow)(Application.Current.MainWindow)).variantList;
			//var pizdec = Export.ExportStudents(students, selectedVariant, variantList, "ааа");
			var pizdec = Export.ExportStudents(variantList);
			pizdec.Item1.Save();
			pizdec.Item2.Save();
		}

		public void presentVariants(List<Variant> vars)
		{
			source.Background.Opacity = 1;
			label.Content = "Варианты";
			label.Foreground = Application.Current.Resources["TextBrush"] as SolidColorBrush;
			panel.Children.RemoveRange(1,panel.Children.Count - 1);

			for (int i = 0; i < vars.Count; i++){
				var card = new VariantCard();
				card.Padding = new Thickness(12, 6, 12, 6);
				card.radioBtn.Tag = i;
				if (i == 0) {
					card.radioBtn.IsChecked = true;
				}
				if (i == vars.Count - 1) {
					card.Padding = new Thickness(12, 6, 12, 12);
				}
				card.radioBtn.Checked += onSelect;
				panel.Children.Add(card);
				card.setName(vars[i]);
			}

			bg.Background = Application.Current.Resources["BackgroundBrush"] as SolidColorBrush;
			exportBtn.Visibility = Visibility.Visible;

		}
	}
}
