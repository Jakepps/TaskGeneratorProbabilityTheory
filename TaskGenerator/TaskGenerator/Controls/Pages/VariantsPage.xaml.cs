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
using Microsoft.WindowsAPICodePack.Dialogs;
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
			CommonOpenFileDialog dlg = new CommonOpenFileDialog();
			dlg.Title = "Выбор папки для сохранения файла";
			dlg.IsFolderPicker = true;
			dlg.AddToMostRecentlyUsedList = false;
			dlg.AllowNonFileSystemItems = false;
			dlg.EnsureFileExists = true;
			dlg.EnsurePathExists = true;
			dlg.EnsureReadOnly = false;
			dlg.EnsureValidNames = true;
			dlg.Multiselect = false;
			dlg.ShowPlacesList = true;

			if (dlg.ShowDialog() == CommonFileDialogResult.Ok)
			{
				Console.WriteLine(dlg.FileName);
				var variantList = ((MainWindow)(Application.Current.MainWindow)).variantList;
				Export.ExportVariants(variantList, dlg.FileName);
				
			}
			//var pizdec = Export.ExportStudents(students, selectedVariant, variantList, "ааа");
			//var pizdec = Export.ExportVariants(variantList);
			//pizdec.Item1.Save();
			//pizdec.Item2.Save();



			////var pizdec = Export.ExportStudents(students, selectedVariant, variantList, "ааа");


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
