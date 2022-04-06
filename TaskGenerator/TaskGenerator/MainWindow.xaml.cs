using System.Windows;
using System.Collections.Generic;
using System;

namespace TaskGenerator
{

    public partial class MainWindow : Window
    {

        public int selectedVariant = 0;

        List<Variant> variantList = new List<Variant>{
            new Variant(1,new List<int> { 1,1 }),
            new Variant(1,new List<int> { 1 }),
            new Variant(1,new List<int> { 1 }),
            new Variant(1,new List<int> { 2,2,2,2 })
        };

        public MainWindow()
        {
            InitializeComponent();

            //Variant var1 = new Variant();
            //var1.number = "1";
            //var1.studentName = "Нальбий Рустамов Хахукович";

            ////for (int i = 0; i < 10; i++)
            ////    var1.tasks.Add(TaskConstructor.CreateTask(1));
            ////var1.GenerateVariant(new List<int> { 1, 1, 1, 1, 1 });
            ////var1.TestPrint();

            //List<int> list = Import.GetTaskTypesFromString("123-1 25,1  2-4,,5--123-   1 24,,   --,124-,-  ,1325  4-,5-,2134-,4");
            //for (int i = 0; i < list.Count; i++)
            //    Console.Write(list[i] + ",");
            //Console.WriteLine();
            //var1.GenerateVariant(list);
            //var1.TestPrint();
            //List<String> students = new List<String>();
            //students.Add("Нальбий Рустамов Хахукович");
            //students.Add("Михайл Артёмов Наголевич");
            //students.Add("Серёга)");


           // List<Variant> variants = Variant.GetVariantsForStudents(students, list);

            //for (int i = 0; i < variants.Count; i++)
            //{
            //    variants[i].TestPrint();
            //}
            
            //List<string> students = Import.namefile();
        
            generator.generateBtn.Click += onClick;
            variants.variantChange += changeVariant;
            tasks.parentWindow = this;
        }

        public void onClick(object sender, RoutedEventArgs e) {
            var count = 0;
            var tasksList = new List<int>(); 
            try {
                count = Convert.ToInt32(generator.countField.Text);
                tasksList = Import.GetTaskTypesFromString(generator.tasksField.Text);
                if (count <= 0) throw new FormatException();
            }
            catch {
                MessageBox.Show("Введены некорректные данные", "Ошибка");
                return;
            }
            selectedVariant = 0;
            variantList = Variant.GenerateSomeVariants(count, tasksList);

            variants.presentVariants(variantList);
            tasks.setVariant(variantList[0], 0);
		}

        public void changeVariant(int v) {
            selectedVariant = v;
            tasks.setVariant(variantList[v], v);
        }

        public void updateTask(int index) {
            variantList[selectedVariant].tasks[index].RegenerateTaskValues();
            tasks.updateCard(index);
		}

        public void updateTaskSubtype(int index)
        {
            variantList[selectedVariant].tasks[index].RegenerateTaskSubtype();
            tasks.updateCard(index);
        }
    }
}
