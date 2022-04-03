﻿using System.Windows;
using System.Collections.Generic;
using System;

namespace TaskGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Variant> variantList = new List<Variant>{
            new Variant(new List<int> { 1,1 }),
            new Variant(new List<int> { 1 }),
            new Variant(new List<int> { 1 }),
            new Variant(new List<int> { 2,2,2,2 })
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

            List<int> list = Import.GetTaskTypesFromString("we1, 2, 4wef- 6, wef9 Barak Obame is bullshit man, 10-11");
            //for (int i = 0; i < list.Count; i++)
            //    Console.Write(list[i] + ",");
            //Console.WriteLine();
            //var1.GenerateVariant(list);
            //var1.TestPrint();
            List<String> students = new List<String>();
            students.Add("Нальбий Рустамов Хахукович");
            //students.Add("Михайл Артёмов Наголевич");
            //students.Add("Серёга)");


           // List<Variant> variants = Variant.GetVariantsForStudents(students, list);

            //for (int i = 0; i < variants.Count; i++)
            //{
            //    variants[i].TestPrint();
            //}
           
            generator.generateBtn.Click += onClick;
            variants.variantChange += changeVariant;
        }

        public void onClick(object sender, RoutedEventArgs e) {
            variants.presentVariants(variantList);
            tasks.setVariant(variantList[0]);
		}

        public void changeVariant(int v) {
            tasks.setVariant(variantList[v - 1]);
        }


    }
}
