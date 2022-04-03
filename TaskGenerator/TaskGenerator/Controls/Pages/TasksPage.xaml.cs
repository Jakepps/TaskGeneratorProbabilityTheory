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

namespace TaskGenerator.Controls.Pages
{
	/// <summary>
	/// Логика взаимодействия для TasksPage.xaml
	/// </summary>
	public partial class TasksPage : UserControl
	{
		public TasksPage()
		{
			InitializeComponent();
		}

		public void setVariant(Variant v) {
			panel.Children.RemoveRange(1, panel.Children.Count - 1);

			foreach (var task in v.tasks) {
				var taskCard = new TaskCard();
				taskCard.Padding = new Thickness(12, 6, 12, 6);
				taskCard.setTask(task);
				panel.Children.Add(taskCard);
			}
		}
	}
}
