using System;

namespace TaskGenerator
{
    public static class TaskConstructor
    {
        //subtype 1 - задача из 2-го варианта, subtype 2 - эта же задача из 3-го варианта.
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
                case 13:
                    return CreateTaskType13(subtype == 0 ? randomSubtype : subtype);
                case 14:
                    return CreateTaskType14(subtype == 0 ? randomSubtype : subtype);
                case 15:
                    return CreateTaskType15(subtype == 0 ? randomSubtype : subtype);
                case 16:
                    return CreateTaskType16(subtype == 0 ? randomSubtype : subtype);
                case 17:
                    return CreateTaskType17(subtype == 0 ? randomSubtype : subtype);
                case 18:
                    return CreateTaskType18(subtype == 0 ? randomSubtype : subtype);
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
                    var rand = new Random();

                    var loteryCount = 6 + Convert.ToInt32(Math.Floor(rand.NextDouble() * 5));
                    var loteryWinCount = 2 + Convert.ToInt32(Math.Floor(rand.NextDouble() * 4));
                    var loteryPickedCount = 2 + Convert.ToInt32(Math.Floor(rand.NextDouble() * (loteryCount - loteryWinCount - 1)));

                    var loteryWinPickedCount = 1 + Convert.ToInt32(Math.Floor(rand.NextDouble() * loteryWinCount));

                    var task1 = new Task(2, 1);
                    task1.condition = "Имеется " + loteryCount + " лотерейных билетов, среди которых " + loteryWinCount + " выйгрышных. Найдите вероятность того, что среди " + loteryPickedCount + " наудачу купленных билетов:";
                    task1.questions.Add("количество выйгрышных билетов равно " + loteryWinPickedCount + ".");
                    task1.questions.Add("нет выйгрышных билетов.");

                    var result1 = (C(loteryWinCount, loteryWinPickedCount) * C(loteryCount - loteryWinCount, loteryPickedCount - loteryWinPickedCount)) / (C(loteryCount, loteryPickedCount));
                    var result2 = (C(loteryWinCount, 0) * C(loteryCount - loteryWinCount, loteryPickedCount)) / C(loteryCount, loteryPickedCount);

                    task1.answers.Add(String.Format("{0:0.000000}", result1));
                    task1.answers.Add(String.Format("{0:0.000000}", result2));
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
                    //todo
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
                    var rand = new Random();

                    var prob1 = (rand.Next(1,10)) / 10.0;
                    var prob2 = (rand.Next(1,10)) / 10.0;

                    Task task1 = new Task(4, 1);
                    task1.condition = "Два поэта-песенника предложили по одной песне исполнителю. Известно, что песни первого поэта эстрадный певец включает в свой репертуар с вероятностью " + prob1 + ", второго - с вероятностью " + prob2 + ". Какова вероятность того, что певец возьмет:";
                    task1.questions.Add("обе песни.");
                    task1.questions.Add("хотя бы одну.");
                    task1.questions.Add("только песню второго поэта.");
                    task1.answers.Add(String.Format("{0:0.00}", prob1 * prob2));
                    task1.answers.Add(String.Format("{0:0.00}", 1 - (1 - prob1) * (1 - prob2)));
                    task1.answers.Add(String.Format("{0:0.00}", (1 - prob1) * prob2));

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
                    var rand = new Random();
                    var prob1 = Convert.ToDouble(rand.Next(1, 8));
                    var prob2 = Convert.ToDouble(rand.Next(1, 10 - Convert.ToInt32(prob1) - 1));
                    var prob3 = Convert.ToDouble(10 - prob1 - prob2);

                    prob1 /= 10; prob2 /= 10; prob3 /= 10;

                    Task task1 = new Task(5, 1);
                    task1.condition = "Два гроссмейстера играют две партии в шахматы. Вероятность выигрыша в одной партии для первого шахматиста равна " + prob1 + ", для второго — " + prob2 + "; вероятность ничьей — " + prob3 + ".";
                    task1.questions.Add("Какова вероятность того, что первый гроссмейстер выиграет матч?");
                    task1.answers.Add(String.Format("{0:0.0000}", (prob1 * prob1 + prob1 * prob3 + prob3 * prob1)));
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
                    var rand = new Random();
                    var brockenCount = rand.Next(1, 5) * 5;

                    Task task1 = new Task(6, 1);

                    task1.condition = "В ящике 100 деталей, из которых " + brockenCount + " бракованных. Из него поочередно извлекается по одной детали (с возвратом и без возврата ). Найти вероятность того, что во второй раз будет вынута стандартная деталь при условии, что в первый раз извлечена деталь:";
                    task1.questions.Add("стандартная.");
                    task1.questions.Add("бракованная.");
                    task1.answers.Add(String.Format("{0:0.000000}", ((99.0 - brockenCount) / 99.0)));
                    task1.answers.Add(String.Format("{0:0.000000}", (99.0 - brockenCount + 1) / 99.0));

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
                    var rand = new Random();
                    var prob1 = Convert.ToDouble(rand.Next(1, 9));
                    var prob2 = Convert.ToDouble(rand.Next(1, 10 - Convert.ToInt32(prob1)));
                    var prob3 = 10 - prob1 - prob2;

                    prob1 /= 10; prob2 /= 10; prob3 /= 10;

                    Task task1 = new Task(7, 1);

                    task1.condition = "В скачках учавствуют три лошади. Первая лошадь вымгрывает скачки с вероятностью " + prob1 + ", вторая - " + prob2 + ", третья - " + prob3 + ". Какова вероятность того, что лошадь, на которую поставил игрок, придет на скачках первой, если он выбирает ее на удачу?";
                    task1.answers.Add(String.Format("{0:0.000000}", (prob1 + prob2 + prob3) / 3.0));

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

        private static Task CreateTaskType13(int subtype)
        {
            switch (subtype)
            {
                case 1:
                    Task task1 = new Task(13, 1);

                    return task1;
                case 2:
                    Task task2 = new Task(13, 2);

                    return task2;
            }
            throw new ArgumentException();
        }

        private static Task CreateTaskType14(int subtype)
        {
            switch (subtype)
            {
                case 1:
                    Task task1 = new Task(14, 1);

                    return task1;
                case 2:
                    Task task2 = new Task(14, 2);

                    return task2;
            }
            throw new ArgumentException();
        }

        private static Task CreateTaskType15(int subtype)
        {
            switch (subtype)
            {
                case 1:
                    Task task1 = new Task(15, 1);

                    return task1;
                case 2:
                    Task task2 = new Task(15, 2);

                    return task2;
            }
            throw new ArgumentException();
        }

        private static Task CreateTaskType16(int subtype)
        {
            switch (subtype)
            {
                case 1:
                    Task task1 = new Task(16, 1);

                    return task1;
                case 2:
                    Task task2 = new Task(16, 2);

                    return task2;
            }
            throw new ArgumentException();
        }

        private static Task CreateTaskType17(int subtype)
        {
            switch (subtype)
            {
                case 1:
                    Task task1 = new Task(17, 1);

                    return task1;
                case 2:
                    Task task2 = new Task(17, 2);

                    return task2;
            }
            throw new ArgumentException();
        }

        private static Task CreateTaskType18(int subtype)
        {
            switch (subtype)
            {
                case 1:
                    Task task1 = new Task(18, 1);

                    return task1;
                case 2:
                    Task task2 = new Task(18, 2);

                    return task2;
            }
            throw new ArgumentException();
        }



        private static int Factorial(int n) {
            if (n <= 0) return 1;
            return n * Factorial(n - 1);
		}
        private static double C(int p, int q) {
            return Convert.ToDouble(Factorial(p)) / Convert.ToDouble((Factorial(q) * Factorial(p - q)));
		}
    }
}
