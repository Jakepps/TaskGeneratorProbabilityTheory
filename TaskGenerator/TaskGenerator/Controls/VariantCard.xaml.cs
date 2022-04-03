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
	/// Логика взаимодействия для VariantCard.xaml
	/// </summary>

	public partial class VariantCard : UserControl
	{
		public VariantCard()
		{
			InitializeComponent();
		}

		private void RadioButton_Checked(object sender, RoutedEventArgs e)
		{

		}

		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();


			//C//onsole.WriteLine(radioBtn.Template);
		}

		public void setName(string name) {
			this.OnApplyTemplate();

			radioBtn.ApplyTemplate();
			((Label)radioBtn.Template.FindName("varName", radioBtn)).Content = name;
			Console.WriteLine();
		}

		private void radioBtn_Click(object sender, RoutedEventArgs e)
		{
			//radioBtn.ApplyTemplate();
			///Console.WriteLine(radioBtn.ContentTemplate.FindName("bord", radioBtn));
			//Console.WriteLine(radioBtn.Template.FindName("varName", radioBtn));
		}
	}
}
