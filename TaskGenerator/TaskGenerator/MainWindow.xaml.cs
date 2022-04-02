using System.Windows;
using System.Collections.Generic;
using System;

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

            //for (int i = 0; i < 10; i++)
            //    var1.tasks.Add(TaskConstructor.CreateTask(1));
            //var1.GenerateVariant(new List<int> { 1, 1, 1, 1, 1 });
            //var1.TestPrint();

            List<int> list = Variant.GetTaskTypesFromString("we1, 1, 1, 2, 4wef- 6, wef9 Barak Obame is bullshit man, 10-11, 1");
            for (int i = 0; i < list.Count; i++)
                Console.Write(list[i] + ",");
            Console.WriteLine();
            var1.GenerateVariant(list);
            var1.TestPrint();
        }
    }
}
