using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskGenerator
{
    class TaskConstructor
    {
        public static Task CreateTask(int taskType)
        {
            switch (taskType)
            {
                case 1:
                    int rand = (new Random()).Next(1, 5);
                    switch (rand)
                    {
                        case 1: return CreateTaskType1Subtype1();
                        case 2: return CreateTaskType1Subtype2();
                        case 3: return CreateTaskType1Subtype3();
                        case 4: return CreateTaskType1Subtype4();
                    }
                    break;
                case 2:

                    break;
            }
            return null;
        }

        private static Task CreateTaskType1Subtype1()
        {
            Task task = new Task();
            task.number = "1";
            task.condition = "Наугад выбирается автомобиль с четырехзначным номером. Найти вероятность того, что: ";
            task.questions.Add("Это автомобиль Ф. Киркорова");
            task.questions.Add("Номер не содержит одинаковых цифр.");
            task.answers.Add("1/10000");
            task.answers.Add("5040/10000");
            return task;
        }

        private static Task CreateTaskType1Subtype2()
        {
            Task task = new Task();
            task.number = "1";
            task.condition = "Имеется девять лотерейных билетов, среди которых два выигрышных. Найти вероятность того, что среди пяти наудачу купленных билетов: ";
            task.questions.Add("Один билет выигрышный.");
            task.questions.Add("Нет выигрышных.");
            task.answers.Add("5/9");
            task.answers.Add("1/6");
            return task;
        }
        private static Task CreateTaskType1Subtype3()
        {
            Task task = new Task();
            task.number = "1";
            task.condition = "Цифровой кодовый замок на сейфе имеет на общей оси пять дисков, каждый из которых разделен на десять секторов." +
                " Какова вероятность открыть замок, выбирая код наудачу, если кодовая комбинация: ";
            task.questions.Add("Неизвестна.");
            task.questions.Add("Не содержит одинаковых цифр.");
            task.answers.Add("1/100000");
            task.answers.Add("1/30240");
            return task;
        }
        private static Task CreateTaskType1Subtype4()
        {
            Task task = new Task();
            task.number = "1";
            task.condition = "В зале имеется 20 белых и 10 синих кресел. Случайным образом места занимают 15 человек. Найти вероятность того, что они займут: ";
            task.questions.Add("5 белых и 10 синих кресел");
            task.questions.Add("Хотя бы одно синее кресло.");
            task.answers.Add("C(20,5)/C(30,15)");
            task.answers.Add("1 - C(20,15)/C(30,15) ");
            return task;
        }
    }
}
