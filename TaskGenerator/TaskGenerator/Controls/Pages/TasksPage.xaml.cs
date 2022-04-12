using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace TaskGenerator.Controls.Pages
{
	/// <summary>
	/// Логика взаимодействия для TasksPage.xaml
	/// </summary>
	public partial class TasksPage : UserControl
	{

		public Variant presentedVariant;
		public MainWindow parentWindow;

		public ObservableCollection<Task> tasks = new ObservableCollection<Task>();
		public TasksPage()
		{
			InitializeComponent();
			DataContext = tasks;
		}

		public void setVariant(Variant v, int index) {
			source.Background.Opacity = 1;
			presentedVariant = v;

			variant.Content = "Вариант " + (index + 1);

			Console.WriteLine(v.tasks.Count);
			Console.WriteLine(tasks.Count);

			for (int i = tasks.Count; i < v.tasks.Count; i++) {
				tasks.Add(v.tasks[i]);	
			}

			var count = tasks.Count;
			for (int i = v.tasks.Count; i < count; i++)
			{
				tasks.Remove(tasks.Last());
			}

			for (int i = 0; i < v.tasks.Count; i++) {
				tasks[i] = v.tasks[i];
			}
		}

		public void updateCard(int index) {
			//presentedVariant.tasks[index].TestPrint();
			tasks.RemoveAt(index);
			tasks.Insert(index, presentedVariant.tasks[index]);
		}
	}
}
