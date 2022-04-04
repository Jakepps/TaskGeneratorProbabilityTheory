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

		public Variant presentedVariant;
		public MainWindow parentWindow;
		public TasksPage()
		{
			InitializeComponent();
		}

		public void setVariant(Variant v) {
			presentedVariant = v;
			panel.Children.RemoveRange(1, panel.Children.Count - 1);

			for(var i = 0; i < v.tasks.Count; i++) {
				var taskCard = new TaskCard();
				taskCard.Padding = new Thickness(12, 6, 12, 6);
				taskCard.setTask(v.tasks[i]);
				taskCard.cardIndex = i;
				if (i == v.tasks.Count - 1)
				{
					taskCard.Padding = new Thickness(12, 6, 12, 12);
				}

				taskCard.taskUpdate += parentWindow.updateTask;
				taskCard.taskSubtypeUpdate += parentWindow.updateTaskSubtype;
				panel.Children.Add(taskCard);
			}
		}

		public void updateCard(int index) {
			//Console.WriteLine()
			presentedVariant.tasks[index].TestPrint();
			((TaskCard)panel.Children[index + 1]).setTask(presentedVariant.tasks[index]);
		}
	}
}
