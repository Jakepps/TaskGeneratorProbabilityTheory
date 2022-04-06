using System;

namespace TaskGenerator
{
    public static class TaskConstructor
    {
        public static Task CreateTask(int type, int subtype = 1)
        {
            switch (type)
            {
                case 1:
                    return CreateTaskType1(subtype == 0 ? new Random().Next(1, 5) : subtype);
                    break;
                case 2:
                    return CreateTaskType2Subtype1();
                    break;
                case 3:
                    return new Task(3);
                    break;
                case 4:
                    return new Task(4);
                    break;
                case 5:
                    return new Task(5);
                    break;
                case 6:
                    return new Task(6);
                    break;
                case 7:
                    return new Task(7);
                    break;
                case 8:
                    return new Task(8);
                    break;
                case 9:
                    return new Task(9);
                    break;
                case 10:
                    return new Task(10);
                    break;
                case 11:
                    return new Task(11);
                    break;
            }
            throw new NotImplementedException();
        }

        public static Task CreateTaskType1(int subtype)
        {
            switch (subtype)
            {
                case 1: return CreateTaskType1Subtype1();
                case 2: return CreateTaskType1Subtype2();
                case 3: return CreateTaskType1Subtype3();
                case 4: return CreateTaskType1Subtype4();
            }
            throw new NotImplementedException();
        }

        private static Task CreateTaskType1Subtype1()
		{
            var rand = new Random();

            Task task = new Task(1, 1);
            var numCount = 4 + Convert.ToInt32(Math.Floor(rand.NextDouble() * 3));
            var sndNum = 1;
            for(int i = 0; i < numCount; i++) {
                sndNum *= (10 - i);
			}

            var numString = (numCount == 4) ? "четырехзначным" : (numCount == 5) ? "пятизначным" : "шестизначным";
			task.condition = "Наугад выбирается автомобиль с " + numString + " номером. Найти вероятность того, что: ";
			task.questions.Add("Это автомобиль Ф. Киркорова");
			task.questions.Add("Номер не содержит одинаковых цифр.");
			task.answers.Add("1/" + (Math.Pow(10, numCount)));
            task.answers.Add(sndNum + "/" + (Math.Pow(10, numCount)));
			return task;
		}

        private static Task CreateTaskType2Subtype1()
        {
            var rand = new Random();

            var loteryCount = 6 + Convert.ToInt32(Math.Floor(rand.NextDouble() * 5));
            var loteryWinCount = 2 + Convert.ToInt32(Math.Floor(rand.NextDouble() * 4));
            var loteryPickedCount = 2 + Convert.ToInt32(Math.Floor(rand.NextDouble() * (loteryCount - loteryWinCount - 1)));

            var loteryWinPickedCount = 1 + Convert.ToInt32(Math.Floor(rand.NextDouble() * loteryWinCount));

            var task = new Task(2, 1);
            task.condition = "Имеется " + loteryCount + " лотерейных билетов, среди которых " + loteryWinCount + " выйгрышных. Найдите вероятность того, что среди " + loteryPickedCount + " наудачу купленных билетов:";
            task.questions.Add("количество выйгрышных билетов равно " + loteryWinPickedCount + ".");
            task.questions.Add("нет выйгрышных билетов.");

            var result1 = (C(loteryWinCount, loteryWinPickedCount) * C(loteryCount - loteryWinCount, loteryPickedCount - loteryWinPickedCount)) / (C(loteryCount, loteryPickedCount));
            var result2 = (C(loteryWinCount, 0) * C(loteryCount - loteryWinCount, loteryPickedCount)) / C(loteryCount, loteryPickedCount);

            task.answers.Add(String.Format("{0:0.000000}", result1));
            task.answers.Add(String.Format("{0:0.000000}", result2));
            return task;
        }

        private static Task CreateTaskType1Subtype2()
		{
			Task task = new Task(1, 2);
			task.condition = "Имеется девять лотерейных билетов, среди которых два выигрышных. Найти вероятность того, что среди пяти наудачу купленных билетов: ";
			task.questions.Add("Один билет выигрышный.");
			task.questions.Add("Нет выигрышных.");
			task.answers.Add("5/9");
			task.answers.Add("1/6");
			return task;
		}
		private static Task CreateTaskType1Subtype3()
		{
			Task task = new Task(1, 3);
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
			Task task = new Task(1, 4);
			task.condition = "В зале имеется 20 белых и 10 синих кресел. Случайным образом места занимают 15 человек. Найти вероятность того, что они займут: ";
			task.questions.Add("5 белых и 10 синих кресел");
			task.questions.Add("Хотя бы одно синее кресло.");
			task.answers.Add("C(20,5)/C(30,15)");
			task.answers.Add("1 - C(20,15)/C(30,15) ");
			return task;
		}

        private static Task CreateTaskType2Subtype3()
        {
            Task task = new Task(2, 3);
            Random random = new Random();
            float a = random.NextSingle() / 2f;
            float b = 0.5f - a;
            float c = 0.5f;
            task.condition = "Два гроссмейстера играют две партии в шахматы. Вероятность выигрыша в одной партии для первого шахматиста равна " + a + ", для второго — " + b + "; вероятность ничьей — 0,5. ";
            task.questions.Add("Какова вероятность того, что первый гроссмейстер выиграет матч?");
            task.answers.Add((a*a + a*c + c*a) + "");
            return task;
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
