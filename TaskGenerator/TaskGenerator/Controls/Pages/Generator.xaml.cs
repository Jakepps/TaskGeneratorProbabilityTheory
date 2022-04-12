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
using Microsoft.Win32;
namespace TaskGenerator.Controls.Pages
{
	/// <summary>
	/// Логика взаимодействия для Generator.xaml
	/// </summary>
	public partial class Generator : UserControl
	{
		public Generator()
		{
			InitializeComponent();
		}

		private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void generateBtn_Click(object sender, RoutedEventArgs e)
		{

		}

        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
			OpenFileDialog openFileDialog = new OpenFileDialog();
			//Console.WriteLine("OpenFileDialog");
			openFileDialog.Filter = "Text files (*.doc; *docx; *.txt)|*.doc; *.docx; *.txt";

			if (openFileDialog.ShowDialog() == true)
            {
				importFileLabel.Content = openFileDialog.SafeFileName;
				MainWindow mainWindow = ((MainWindow)Application.Current.MainWindow);
				mainWindow.students = new MainWindow.Students(openFileDialog.FileName);
				int studentsCount = mainWindow.students.Count;
				countField.Text = studentsCount.ToString();
			}
			
			countField.Foreground = new SolidColorBrush(Color.FromArgb(255, 160, 160, 160));
			countField.IsReadOnly = true;
			countField.Focusable = false;
			//countField.IsEnabled = false;
		}

        private void btnDeleteFile_Click(object sender, RoutedEventArgs e)
        {
			importFileLabel.Content = "Отсутствует";
			((MainWindow)Application.Current.MainWindow).students = new MainWindow.Students();

			countField.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
			countField.IsReadOnly = false;
			countField.Focusable = true;

			//countField.IsEnabled = true;
		}
	}
}
