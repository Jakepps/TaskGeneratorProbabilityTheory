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

namespace TaskGenerator.Controls.Pages
{
	/// <summary>
	/// Логика взаимодействия для VariantsPage.xaml
	/// </summary>
	public partial class VariantsPage : UserControl
	{
		double m_ScrollStepRatio = 0.0; // normalized step length of the scroll bar
		double m_ScrollPositionRatio = 0.0; //Normalized position of the scroll bar
		public VariantsPage()
		{
			InitializeComponent();
		}

		private void TaskCard_Loaded(object sender, RoutedEventArgs e)
		{

		}
	}
}
