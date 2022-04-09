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
                    Random random = new Random();
                    int numCount2 = 3 + random.Next(0, 4);

                    string numString2 = (numCount2 == 3) ? "3 диска" : (numCount2 == 4) ? "4 диска" : numCount2 == 5 ? "5 дисков" : "6 дисков";
                    task2.condition = "Цифровой кодовый замок на сейфе имеет на общей оси " + numString2 + ", каждый из которых разделен на десять секторов." +
                                    " Какова вероятность открыть замок, выбирая код наудачу, если кодовая комбинация: ";
                    task2.questions.Add("Неизвестна.");
                    task2.questions.Add("Не содержит одинаковых цифр.");
                    int ans1 = (int)Math.Pow(10, numCount2);
                    task2.answers.Add("1/" + ans1);
                    int ans2 = 1;
                    for(int i = 0, x = 10; i < numCount2; i++, x--)
                    {
                        ans2 *= x;
                    }
                    task2.answers.Add("1/" + ans2);
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

                    task1.answers.Add(string.Format("{0:0.000000}", result1));
                    task1.answers.Add(string.Format("{0:0.000000}", result2));
                    return task1;

                case 2:
                    Task task2 = new Task(2, 2);
                    Random random = new Random();
                    int whiteCount = random.Next(15, 30);
                    int blueCount = random.Next(10, 20);
                    int manCount = random.Next(5, whiteCount);
                    
                    int whiteTake = random.Next(1, Math.Min(whiteCount, manCount - 1));
                    
                    //Test for loop
                    while (manCount - whiteTake > blueCount)
                        whiteTake = random.Next(1, Math.Min(whiteCount, manCount - 1));

                    int blueTake = manCount - whiteTake;

                    task2.condition = "В зале имеется "+ whiteCount +" белых и " +blueCount+ " синих кресел." +
                        " Случайным образом места занимают "+manCount+" человек. Найти вероятность того, что они займут: ";
                    task2.questions.Add(whiteTake + " белых и " +blueTake+ " синих кресел");
                    task2.questions.Add("Хотя бы одно синее кресло.");
                    task2.answers.Add("C("+ whiteCount + ","+whiteTake+")*C(" + blueCount + ", " + blueTake+")/C(" + (whiteCount + blueCount) +", "+ manCount + " )" );
                    task2.answers.Add("1 - C("+whiteCount+","+manCount+")/C("+(whiteCount+blueCount)+","+manCount+") ");
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
                    task1.answers.Add(string.Format("{0:0.00}", prob1 * prob2));
                    task1.answers.Add(string.Format("{0:0.00}", 1 - (1 - prob1) * (1 - prob2)));
                    task1.answers.Add(string.Format("{0:0.00}", (1 - prob1) * prob2));

                    return task1;
                case 2:
                    var random = new Random();
                    var ver1 = (random.Next(1, 10)) / 10.0;
                    var ver2 = (random.Next(1, 10)) / 10.0;
                    Task task2 = new Task(4, 2);
                    task2.condition = "Два баскетболиста делают по одному броску мячом по корзине. Для первого спортсмена вероятность попадания равна " + ver1 + ", для второго - " + ver2 + ". Какова вероятность того,что в корзину попадут:";
                    task2.questions.Add("оба игрока.");
                    task2.questions.Add("хотя бы один игрок.");
                    task2.questions.Add("попадет только первый спортсмен?");
                    task2.answers.Add(string.Format("{0:0.00}",ver1 * ver2));
                    task2.answers.Add(string.Format("{0:0.00}",1 - (1 - ver1) * (1 - ver2)));
                    task2.answers.Add(string.Format("{0:0.00}",ver1 * (1 - ver2)));

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
                    task1.condition = "Два гроссмейстера играют две партии в шахматы. Вероятность выигрыша в одной партии для первого шахматиста равна " + prob1 + ", для второго — " + prob2 + "; вероятность ничьей — " + prob3 + "." +
                        "Какова вероятность того, что первый гроссмейстер выиграет матч?";
                    task1.answers.Add(string.Format("{0:0.0000}", (prob1 * prob1 + prob1 * prob3 + prob3 * prob1)));
                    return task1;
                case 2:
                    var random=new Random();
                    var ver1 = random.Next(1, 10) / 10.0;
                    var ver2 = random.Next(1, 15) / 15.0;

                    Task task2 = new Task(5, 2);
                    task2.condition = "Экзаменационный билет по теории вероятностей содержит три вопроса(по одному из трех разделов). Студент знает " + ver1*10 + " из 10 вопросов первого раздела, " + ver2*15 + " из 15 — " +
                        "второго и все 20 вопросов третьего раздела.Преподаватель ставит положительную оценку при ответе хотя бы на два вопроса билета." +
                        "Какова вероятность того,что студент не сдаст экзамен?";
                    task2.answers.Add(string.Format("{0:0.000}",(1-ver1)*(1-ver2)));
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
                    task1.answers.Add(string.Format("{0:0.000000}", ((99.0 - brockenCount) / 99.0)));
                    task1.answers.Add(string.Format("{0:0.000000}", (99.0 - brockenCount + 1) / 99.0));

                    return task1;
                case 2:
                    var random = new Random();
                    var ver1=random.Next(2,10);
                    var ver2= random.Next(1,ver1-1);

                    Task task2 = new Task(6, 2);

                    task2.condition = "Работа некоторого устройства прекращается, если из строя выходит 1 из " + ver1 + ".Последовательная замена " +
                                      "каждого элемента новым производится до тех пор пока устройство не начнет работать. " +
                                      "Какова вероятность того, что придется заменить "+ver2+" элементов ?";
                    double an=1.0;

                    while (ver2 != 0)
                    {
                        an *= ((double)ver2 / (double)ver1);
                        ver1 -= 1;
                        ver2 -= 1;
                    }
                    task2.answers.Add(string.Format("{0:0.000000}", an));
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
                    var prob1 = Convert.ToDouble(rand.Next(1, 10));
                    var prob2 = Convert.ToDouble(rand.Next(1, 10));
                    var prob3 = Convert.ToDouble(rand.Next(1, 10));

                    prob1 /= 10; prob2 /= 10; prob3 /= 10;

                    Task task1 = new Task(7, 1);

                    task1.condition = "В скачках учавствуют три лошади. Первая лошадь вымгрывает скачки с вероятностью " + prob1 + ", вторая - " + prob2 + ", третья - " + prob3 + ". Какова вероятность того, что лошадь, на которую поставил игрок, придет на скачках первой, если он выбирает ее на удачу?";
                    task1.answers.Add(string.Format("{0:0.000000}", (prob1 + prob2 + prob3) / 3.0));

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
                    var rand = new Random();

                    var prob1 = Convert.ToDouble(rand.Next(1, 20));
                    var prob2 = Convert.ToDouble(rand.Next(1, 20));
                    var prob3 = Convert.ToDouble(rand.Next(1, 20));

                    prob1 /= 20; prob2 /= 20; prob3 /= 20;

                    Task task1 = new Task(8, 1);

                    task1.condition = "Электростанция оборудована генератором электрического тока, приводимым во вращение дизельным двигателем." +
                        "Состояние оборудования и воспламенительные свойства дизельного топлива(цетановое число) таковы, " +
                        "что при использовании в качестве топлива соляровых фракций прямой перегонки нефти генератор приходит в аварийное состояние с вероятностью " + 
                        prob1 + ", при использовании керосиновых фракций — с вероятностью " + prob2 + ", а при использовании газойлевых фракций — с вероятностью " + prob3 +
                        ". 26 апреля 1986 г. года электростанция исправно давала ток. Какова вероятность того, что в этот день дизельный двигатель работал на солярке," +
                        " если тот или иной вид топлива используется с равной вероятностью ?";
                    
                    task1.answers.Add(string.Format("{0:0.000000}", (1 - prob1)/((1 - prob1) + (1 - prob2) + (1 - prob3))));
                    return task1;
                case 2:
                    Task task2 = new Task(8, 2);
                    Random random = new Random();

                    int[] percentWork = new int[3];

                    percentWork[0] = random.Next(1, 12 + 1)*5;
                    percentWork[1] = random.Next(1, 17 - percentWork[0]/5 + 1)*5;
                    percentWork[2] = 100 - percentWork[0] - percentWork[1];

                    double[] probFail = new double[4];
                    for (int i = 0; i < 3; i++)
                    {
                        probFail[i] = Convert.ToDouble(random.Next(1, 10)) / 100.0;
                        if (i == 1 && Math.Abs(probFail[i] - probFail[i - 1]) < 0.005) i--;
                        if (i == 2 && (Math.Abs(probFail[i] - probFail[i - 1]) < 0.005 || Math.Abs(probFail[i] - probFail[i - 2]) < 0.005)) i--;
                    }

                    probFail[3] = percentWork[0] * probFail[0] + percentWork[1] * probFail[1] + percentWork[2] * probFail[2];

                    task2.condition = "Три студента — Артём, Рустам и Сергей — на лабораторной работе по физике производят " +
                        percentWork[0] + "%, "+ percentWork[1] + "% и " + percentWork[2] + "% всех измерений, допуская ошибки с вероятностями " +
                        probFail[0] + ", " + probFail[1] + " и "+ probFail[2] + " соответственно. Преподаватель проверяет наугад выбранное " +
                        "измерение и объявляет его ошибочным. Кто из трех студентов вероятнее всего сделал это измерение?";

                    int studentInd = 0; double max = -1;
                    for (int i = 0; i < 3; i++)
                    {
                        if(percentWork[i]*probFail[i]/probFail[3] > max)
                        {
                            max = percentWork[i] * probFail[i] / probFail[3];
                            studentInd = i;
                        }
                    }
                    string student = studentInd == 0 ? "Артём" : studentInd == 1 ? "Рустам" : "Сергей";
                    task2.answers.Add(student);
                    return task2;
            }
            throw new ArgumentException();
        }

        private static Task CreateTaskType9(int subtype)
        {
            switch (subtype)
            {
                case 1:
                    var rand = new Random();
                    var prob1 = rand.Next(1, 4);
                    var prob2 = rand.Next(1, 8);

                    Task task1 = new Task(9, 1);
                    task1.condition = "В скольких партиях с равным по силе противником выигрыш более вероятен: в " + prob1 + " партиях из 4 или в " + prob2 + " из 8?";
                    task1.answers.Add(C(4,prob1) * Math.Pow(0.5, 4) > C(8, prob2) * Math.Pow(0.5, 8) ? "1" : "2");

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
                    Random random = new Random();

                    double probFailure = random.Next(1, 7 + 1) * 5 / 100.0;
                    int amount = random.Next(1, 10)*5;

                    task2.condition = "Вероятность выхода из строя за время Т одного конденсатора равна " + probFailure + "." +
                        " Определить вероятность того, что за время Т из 100 конденсаторов, работающих независимо, выйдут из строя:";
                    task2.questions.Add("не менее "+ amount + " конденсаторов");
                    task2.questions.Add("ровно половина");
                    
                    double x1 = (amount - 100* probFailure)/Math.Sqrt(100 * probFailure * (1 - probFailure));
                    double x2 = (100 - 100 * probFailure) / Math.Sqrt(100 * probFailure * (1 - probFailure));

                    task2.answers.Add(string.Format("Φ({0:0.00}) - Φ({1:0.00})", x2,x1));

                    double k1 = 1.0/Math.Sqrt(100 * probFailure * (1 - probFailure));
                    double k2 = (50 - 100 * probFailure) / Math.Sqrt(100 * probFailure * (1 - probFailure));
                    task2.answers.Add(string.Format("{0:0.00} * φ({1:0.00})", k1,k2));
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
                    Random random = new Random();
                    int allStudentsAmount = random.Next(1, 9 + 1) * 100;
                    int studentsAmount = random.Next(2, 5 + 1);
                    task2.condition = "На факультете обучается " + allStudentsAmount + " студентов. Какова вероятность того, что " +
                        "31 декабря является днем рождения одновременно " + studentsAmount + " студентов данного факультета?";
                    double x = (studentsAmount - allStudentsAmount * (1 / 365.0)) / Math.Sqrt(allStudentsAmount * (1 / 365.0) * (1 - 1 / 365.0));
                    double k = 1 / Math.Sqrt(allStudentsAmount * (1 / 365.0) * (1 - 1 / 365.0));
                    task2.answers.Add(string.Format("1/√("+ allStudentsAmount + "*(1/365)*(1-1/365)) * φ({0:0.00}) ≈ {1:0.00} * φ({0:0.00})", x, k));
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
                    Random random = new Random();
                    double probDefective = random.Next(1,10)*5/100.0;
                    task2.condition = string.Format("Вероятность изготовления нестандартной детали равна {0:0.00}. Из партии контролер проверяет не более четырех деталей. " +
                        "Если деталь оказывается нестандартной, испытания прекращаются, а партия задерживается. Если деталь оказывается стандартной, " +
                        "контролер берет следующую и т. д.", probDefective);
                    task2.questions.Add("Составить ряд распределения числа проверенных деталей.");
                    task2.questions.Add("Найти М(Х), D(X), σ(X), F(X).");

                    double[] p = new double[4];
                    for(int i = 0; i < 4; i++)
                    {
                        p[i] = Math.Pow(1 - probDefective, i) * probDefective;
                    }
                    task2.answers.Add(string.Format("\nP(x=1)={0:0.00} \n" +
                        "P(x=2)={1:0.00}*{0:0.00}={2:0.000} \n" +
                        "P(x=3)={1:0.00}*{1:0.00}*{0:0.00}={3:0.000} \n" +
                        "P(x=4)={1:0.00}*{1:0.00}*{1:0.00}*{0:0.00}={4:0.000}", probDefective, 1- probDefective, p[1], p[2], p[3]));

                    double mx = 0;
                    for (int i = 1; i <= 4; i++)
                        mx += i*p[i-1];

                    double dx = 0;
                    for (int i = 1; i <= 4; i++)
                        dx += i*i * p[i - 1];
                    dx -= mx * mx;

                    double[] fx = new double[4];
                    fx[0] = p[0];
                    for (int i = 1; i < 4; i++)
                        fx[i] = fx[i - 1] + p[i];
                    task2.answers.Add(string.Format("\nM(X)={0:0.000} \nD(X)={1:0.000} \nσ(X)={2:0.000} \nF(X) = \n{3:0.000}, x = 1; \n{4:0.000}, x = 2; \n{5:0.000}, x = 3; \n{6:0.000}, x = 4;",
                        mx, dx, Math.Sqrt(dx), fx[0], fx[1], fx[2], fx[3]));
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
