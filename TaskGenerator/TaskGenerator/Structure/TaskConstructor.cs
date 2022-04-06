using System;

namespace TaskGenerator
{
    public static class TaskConstructor
    {
        //subtype 1 - задача из 2-го варианта, subtype 2 - эта же задача из третьего варианта.
        public static Task CreateTask(int type, int subtype = 0)
        {
            int randomSubtype = new Random().Next(1, 3);

            switch (type)
            {
                case 1:
                    return CreateTaskType1(subtype == 0 ? randomSubtype : subtype);
                case 2:
                    return CreateTaskType2(subtype == 0 ? randomSubtype : subtype);
                case 3:
                    return CreateTaskType3(subtype == 0 ? randomSubtype : subtype);
                case 4:
                    return CreateTaskType4(subtype == 0 ? randomSubtype : subtype);
                case 5:
                    return CreateTaskType5(subtype == 0 ? randomSubtype : subtype);
                case 6:
                    return CreateTaskType6(subtype == 0 ? randomSubtype : subtype);
                case 7:
                    return CreateTaskType7(subtype == 0 ? randomSubtype : subtype);
                case 8:
                    return CreateTaskType8(subtype == 0 ? randomSubtype : subtype);
                case 9:
                    return CreateTaskType9(subtype == 0 ? randomSubtype : subtype);
                case 10:
                    return CreateTaskType10(subtype == 0 ? randomSubtype : subtype);
                case 11:
                    return CreateTaskType11(subtype == 0 ? randomSubtype : subtype);
                case 12:
                    return CreateTaskType12(subtype == 0 ? randomSubtype : subtype);
            }
            throw new NotImplementedException();
        }

        private static Task CreateTaskType1(int subtype)
		{
            switch (subtype)
            {
                case 1:
                    var rand = new Random();

                    Task task1 = new Task(1, 1);
                    var numCount = 4 + Convert.ToInt32(Math.Floor(rand.NextDouble() * 3));
                    var sndNum = 1;
                    for (int i = 0; i < numCount; i++)
                    {
                        sndNum *= (10 - i);
                    }
                    var numString = (numCount == 4) ? "четырехзначным" : (numCount == 5) ? "пятизначным" : "шестизначным";
                    task1.condition = "Наугад выбирается автомобиль с " + numString + " номером. Найти вероятность того, что: ";
                    task1.questions.Add("Это автомобиль Ф. Киркорова");
                    task1.questions.Add("Номер не содержит одинаковых цифр.");
                    task1.answers.Add("1/" + (Math.Pow(10, numCount)));
                    task1.answers.Add(sndNum + "/" + (Math.Pow(10, numCount)));
                    return task1;
                case 2:
                    Task task2 = new Task(1, 2);
                    task2.condition = "Цифровой кодовый замок на сейфе имеет на общей оси пять дисков, каждый из которых разделен на десять секторов." +
                                    " Какова вероятность открыть замок, выбирая код наудачу, если кодовая комбинация: ";
                    task2.questions.Add("Неизвестна.");
                    task2.questions.Add("Не содержит одинаковых цифр.");
                    task2.answers.Add("1/100000");
                    task2.answers.Add("1/30240");
                    return task2;
            }
            throw new ArgumentException();
		}

        private static Task CreateTaskType2(int subtype)
        {
            switch (subtype)
            {
                case 1:
                    Task task1 = new Task(2, 1);
                    task1.condition = "Имеется девять лотерейных билетов, среди которых два выигрышных. Найти вероятность того, что среди пяти наудачу купленных билетов: ";
                    task1.questions.Add("Один билет выигрышный.");
                    task1.questions.Add("Нет выигрышных.");
                    task1.answers.Add("5/9");
                    task1.answers.Add("1/6");
                    return task1;

                case 2:
                    Task task2 = new Task(2, 2);
                    task2.condition = "В зале имеется 20 белых и 10 синих кресел. Случайным образом места занимают 15 человек. Найти вероятность того, что они займут: ";
                    task2.questions.Add("5 белых и 10 синих кресел");
                    task2.questions.Add("Хотя бы одно синее кресло.");
                    task2.answers.Add("C(20,5)/C(30,15)");
                    task2.answers.Add("1 - C(20,15)/C(30,15) ");
                    return task2;
            }
            throw new ArgumentException();
        }

        private static Task CreateTaskType3(int subtype)
        {
            switch (subtype)
            {
                case 1:
                    Task task1 = new Task(3, 1);

                    return task1;
                case 2:
                    Task task2 = new Task(3, 2);

                    return task2;
            }
            throw new ArgumentException();
        }

        private static Task CreateTaskType4(int subtype)
        {
            switch (subtype)
            {
                case 1:
                    Task task1 = new Task(4, 1);

                    return task1;
                case 2:
                    Task task2 = new Task(4, 2);

                    return task2;
            }
            throw new ArgumentException();
        }

        private static Task CreateTaskType5(int subtype)
        {
            switch (subtype)
            {
                case 1:
                    //TODO: Переделать для нормального отображания, улучшить рандом.
                    Task task1 = new Task(5, 1);
                    Random random = new Random();
                    float a = random.NextSingle() / 2f;
                    float b = 0.5f - a;
                    float c = 0.5f;
                    task1.condition = "Два гроссмейстера играют две партии в шахматы. Вероятность выигрыша в одной партии для первого шахматиста равна " + a + ", для второго — " + b + "; вероятность ничьей — 0,5. ";
                    task1.questions.Add("Какова вероятность того, что первый гроссмейстер выиграет матч?");
                    task1.answers.Add((a * a + a * c + c * a) + "");
                    return task1;
                case 2:
                    Task task2 = new Task(5, 2);

                    return task2;
            }
            throw new ArgumentException();
        }

        private static Task CreateTaskType6(int subtype)
        {
            switch (subtype)
            {
                case 1:
                    Task task1 = new Task(6, 1);

                    return task1;
                case 2:
                    Task task2 = new Task(6, 2);

                    return task2;
            }
            throw new ArgumentException();
        }

        private static Task CreateTaskType7(int subtype)
        {
            switch (subtype)
            {
                case 1:
                    Task task1 = new Task(7, 1);

                    return task1;
                case 2:
                    Task task2 = new Task(7, 2);

                    return task2;
            }
            throw new ArgumentException();
        }

        private static Task CreateTaskType8(int subtype)
        {
            switch (subtype)
            {
                case 1:
                    Task task1 = new Task(8, 1);

                    return task1;
                case 2:
                    Task task2 = new Task(8, 2);

                    return task2;
            }
            throw new ArgumentException();
        }

        private static Task CreateTaskType9(int subtype)
        {
            switch (subtype)
            {
                case 1:
                    Task task1 = new Task(9, 1);

                    return task1;
                case 2:
                    Task task2 = new Task(9, 2);

                    return task2;
            }
            throw new ArgumentException();
        }

        private static Task CreateTaskType10(int subtype)
        {
            switch (subtype)
            {
                case 1:
                    Task task1 = new Task(10, 1);

                    return task1;
                case 2:
                    Task task2 = new Task(10, 2);

                    return task2;
            }
            throw new ArgumentException();
        }

        private static Task CreateTaskType11(int subtype)
        {
            switch (subtype)
            {
                case 1:
                    Task task1 = new Task(11, 1);

                    return task1;
                case 2:
                    Task task2 = new Task(11, 2);

                    return task2;
            }
            throw new ArgumentException();
        }

        private static Task CreateTaskType12(int subtype)
        {
            switch (subtype)
            {
                case 1:
                    Task task1 = new Task(12, 1);

                    return task1;
                case 2:
                    Task task2 = new Task(12, 2);

                    return task2;
            }
            throw new ArgumentException();
        }
    }
}
