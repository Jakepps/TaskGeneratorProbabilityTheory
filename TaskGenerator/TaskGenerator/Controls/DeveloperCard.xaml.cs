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
    /// Логика взаимодействия для DeveloperCard.xaml
    /// </summary>
    public partial class DeveloperCard : UserControl
    {

		public static readonly DependencyProperty DeveloperName =
		DependencyProperty.Register("name", typeof(string), typeof(TaskCard), new UIPropertyMetadata("Кто-то", OnIntValuePropertyChanged));

		private static void OnIntValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			
		}

		public string name
		{
			get
			{
				return (string)GetValue(DeveloperName);
			}
			set
			{
				devName.Content=value;
				SetValue(DeveloperName, value);
			}
		}


		public static readonly DependencyProperty Work1 =
		DependencyProperty.Register("work1", typeof(string), typeof(TaskCard), new UIPropertyMetadata("Кто-то", OnIntValuePropertyChanged));

		public string work1
		{
			get
			{
				return (string)GetValue(Work1);
			}
			set
			{
				firstWork.Content = value;
				SetValue(Work1, value);
			}
		}

		public static readonly DependencyProperty Work2 =
		DependencyProperty.Register("work2", typeof(string), typeof(TaskCard), new UIPropertyMetadata("Кто-то", OnIntValuePropertyChanged));

		public string work2
		{
			get
			{
				return (string)GetValue(Work2);
			}
			set
			{
				secondName.Content = value;
				SetValue(Work2, value);
			}
		}

		public static readonly DependencyProperty Avatar =
		DependencyProperty.Register("avatar", typeof(ImageSource), typeof(TaskCard), new UIPropertyMetadata(null, OnIntValuePropertyChanged));

		public ImageSource avatar
		{
			get
			{
				return (ImageSource)GetValue(Avatar);
			}
			set
			{
				preview.ImageSource = value;
				SetValue(Avatar, value);
			}
		}

		public DeveloperCard()
        {
            InitializeComponent();
        }
    }
}
