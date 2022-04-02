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

namespace TaskGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Variant var1 = new Variant();
            var1.number = "1";
            var1.studentName = "Нальбий Рустамов Хахукович";

            for (int i = 0; i < 10; i++)
                var1.tasks.Add(TaskConstructor.CreateTask(1));

            var1.testPrint();
        }
    }
}
