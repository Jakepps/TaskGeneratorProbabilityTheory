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

namespace TaskGenerator.Controls
{
	/// <summary>
	/// Логика взаимодействия для TaskCard.xaml
	/// </summary>
	public partial class TaskCard : UserControl
	{
		public TaskCard()
		{
			InitializeComponent();
		}

		public void setTask(Task t) {
			var title = (TextBlock)FindName("taskNum");
			var condition = (TextBlock)FindName("condition");
			var answer = (TextBlock)FindName("answer");

			title.Text = "Задача " + t.type;
			condition.Text = t.condition;
			answer.Text = t.answers[0];
		}
	}
}
