using System;
using System.Collections.Generic;
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
                case 19:
                    return CreateTaskType19(subtype == 0 ? randomSubtype : subtype);
                case 20:
                    return CreateTaskType20(subtype == 0 ? randomSubtype : subtype);
                case 21:
                    return CreateTaskType21(subtype == 0 ? randomSubtype : subtype);
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
                    Task task1 = new Task(3, 1);

                    task1.condition = "Эксперимент состоит в бросании игральной кости. Пусть событие А — появление больше 4 очков, событие В — появление больше 3 и меньше 6 очков, событие С — появление больше 3 очков.Выразите событие С через события А и В. Постройте множество элементарных исходов и выявите состав подмножеств, соответствующих событиям:";
                    task1.questions.Add("A ∪ B");
                    task1.questions.Add("A ∩ ¬B");

                    task1.answers.Add("C = A ∪ B");
                    task1.answers.Add("Ω = {1,2,3,4,5,6}, A ∪ B = {4,5,6}, A ∩ ¬B = {6}");

                    return task1;
                case 2:
                    Task task2 = new Task(3, 2);
                    task2.condition = "Пусть А, В, С — случайные события, выраженные подмножествами одного и того же множества элементарных событий. В алгебре событий {А, В, С} запишите следующее:";
                    task2.questions.Add("Из данных событий произошло только А");
                    task2.questions.Add("Произошло хотя бы одно из данных событий");
                    task2.questions.Add("Произошло более одного из данных событий.");
                    task2.answers.Add("A•¬B•¬C");
                    task2.answers.Add("¬(¬A•¬B•¬C)");
                    task2.answers.Add("¬(¬A•¬B•¬C + A•¬B•¬C + ¬A•B•¬C + ¬A•¬B•C)");
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
                    var ver2=random.Next(1,ver1-1);

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
                    var random = new Random();
                    var ver1 = Convert.ToDouble(random.Next(1, 8));
                    var ver2 = Convert.ToDouble(random.Next(1, 10 - Convert.ToInt32(ver1) - 1));
                    var ver3 = Convert.ToDouble(10 - ver1 - ver2);
                    var ver4= Convert.ToDouble(random.Next(1, 10)) / 10;
                    var ver5= Convert.ToDouble(random.Next(1, 10)) / 10;
                    ver1 /= 10; ver2 /= 10; ver3 /= 10;
                    Task task2 = new Task(7, 2);
                    task2.condition = "В ночь перед экзаменом по математике студенту Дудкину с вероятностью " + ver1 + "  снится экзаменатор, с вероятностью " + ver2 + "— тройной интеграл и с вероятностью " +
                                       ver3 + " то же,что и всегда.Если Дудкину снится преподаватель, то экзамен он сдает с вероятностью " + ver4 + ", если тройной интеграл," +
                                       "то успех на экзамене ожидает его с вероятностью " + ver5 + ". Если же Дудкину снится то же, что и всегда, то экзамен он точно «заваливает». Какова вероятность, что Дудкин сдаст " +
                                       "математику в ближайшую сессию?";
                    task2.answers.Add((string.Format("{0:0.00}", ver1 * ver4 + ver2 * ver5)));
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
                    var random = new Random();
                    var ver1 = Convert.ToDouble(random.Next(1, 10))/10;
                    var ver2=0.0;
                    do
                    {
                        ver2 =Convert.ToDouble(random.Next(4, 100));
                    }
                    while (ver2 % 2 != 0);
                    Task task2 = new Task(9, 2);
                    task2.condition = "Вероятность выхода из строя за время Т одного (любого) элемента равна " +
                        ver1 + ". Определить вероятность того, что за время Т из " + (int)ver2 + " элементов из строя выйдет:";
                    task2.questions.Add("половина");
                    task2.questions.Add("меньше половины");
                    double ver3 = 1 - ver1;
                    double x = ((ver2 / 2) * ver1 * ver3) / Math.Sqrt(ver2 * ver1 * ver3);
                    double p = 1.0 / Math.Sqrt(ver2 * ver1 * ver3);
                    task2.answers.Add(string.Format("{0:0.00}*ф({1:0.00})", p, x));
                    double x1 = (1 - ver1 * ver3) / Math.Sqrt(ver2 * ver1 * ver3);
                    double x2 = ((ver2 / 2 - 1) - ver1 * ver3) / Math.Sqrt(ver2 * ver1 * ver3);
                    task2.answers.Add(string.Format("ф({0:0.00})-ф({1:0.00})", x2, x1));
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
                    Random rand = new Random();

                    var testCount = rand.Next(7,10) * 100;
                    var prob = rand.Next(5, 15) / 20.0;
                    var equalCount = rand.Next(5,10) * 50;

                    var startCount = rand.Next(2, 6) * 50;
                    var endCount = rand.Next(6, 11) * 50;

                    task1.condition = "В каждом из " + testCount + " независимых испытаний событие А происходит с постоянной вероятностью " + prob + ". Найти вероятность того, что событие А происходит:";
                    task1.questions.Add("меньше чем " + endCount + " и больше чем " + startCount + " раз.");
                    task1.questions.Add("точно " + equalCount + " раз.");

                    var x = (equalCount - testCount * prob) / Math.Sqrt(testCount * prob * (1 - prob));

                    var x11 = (startCount - testCount * prob) / Math.Sqrt(testCount * prob * (1 - prob));
                    var x22 = (endCount - testCount * prob) / Math.Sqrt(testCount * prob * (1 - prob));

                    task1.answers.Add("Ф(" + String.Format("{0:0.0000}", x22) + ") - Ф(" + String.Format("{0:0.0000}", x11) + ")");
                    task1.answers.Add("Φ(" + String.Format("{0:0.0000}",x) + ")");

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
                    var rand = new Random();
                    var count = rand.Next(1, 4);
                    count = count == 1 ? 120 : count == 2 ? 180 : 240;

                    task1.condition = "Среднее число вызовов, поступающих на АТС в минуту, равно " + count + ".Найти вероятность того, что за две секунды на АТС поступит менее двух вызовов.";

                    var lambda = count / 60.0 * 2.0;
                    var p0 = Math.Pow(lambda, 0) * Math.Exp(-lambda) / Factorial(0);
                    var p1 = Math.Pow(lambda, 1) * Math.Exp(-lambda) / Factorial(1);

                    var result = p1 + p0;
                    task1.answers.Add(String.Format("{0:0.0000}", result));
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
                    var rand = new Random();

                    var prob =  rand.Next(3, 7) / 10.0;

                    task1.condition = "Вероятность поражения цели при одном выстреле равна " + prob + ".";
                    task1.questions.Add("Составить ряд распределения числа выстрелов, производимых до первого поражения цели, если у стрелка четыре патрона.");
                    task1.questions.Add("Найти M(X), D(X), σ(X), F(X) числа выстрелов до первого поражения цели.");
                    task1.questions.Add("Построить график F(X).");

                    var k1 = prob;
                    var k2 = (1 - prob) * prob;
                    var k3 = (1 - prob) * (1 - prob) * prob;
                    var k4 = (1 - prob) * (1 - prob) * (1 - prob) * prob;

                    var MX = 1 * k1 + 2 * k2 + 3 * k3 + 4 * k4;
                    var DX = 1 * k1 + 4 * k2 + 9 * k3 + 16 * k4 - Math.Pow(MX, 2);

                    //Console.WriteLine(String.Format("{0:0.0000} {1:0.0000} {2:0.0000} {3:0.0000}", k1, k2, k3, k4));

                    task1.answers.Add( "\n" + 
                        "P(x = 1) = " + String.Format("{0:0.0000}",k1) + "\n" +
                        "P(x = 2) = " + String.Format("{0:0.0000}", k2) + "\n" +
                        "P(x = 3) = " + String.Format("{0:0.0000}", k3) + "\n" +
                        "P(x = 4) = " + String.Format("{0:0.0000}", k4)
                    );
                    task1.answers.Add( "\n" + 
                        "M(X) = " + String.Format("{0:0.0000}", MX) + "\n" +
                        "D(X) = " + String.Format("{0:0.0000}", DX) + "\n" +
                        "σ(X) = " + String.Format("{0:0.0000}", Math.Sqrt(DX)) + "\n" +
                        "F(X) = \n" +
                        "    | 0, x = 0\n" +
                        "    | " + String.Format("{0:0.0000}", k1) + ", x = 1\n" +
                        "    | " + String.Format("{0:0.0000}", k1 + k2) + ", x = 2\n" +
                        "    | " + String.Format("{0:0.0000}", k1 + k2 + k3) + ", x = 3\n" +
                        "    | " + String.Format("{0:0.0000}", k1 + k2 + k3 + k4) + ", x = 4"
                    );
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
                    var rand = new Random();
                    var count = rand.Next(3, 5);

                    task1.condition = "Игральная кость брошена " + count + " раза.";
                    task1.questions.Add("Составить ряд распределения числа выпадений шестерки.");
                    task1.questions.Add("Найти M(X) и D(X) этой случайной величины.");

                    var probs = new List<String>();

                    for(int i = 0; i <= count; i++)
                    {
                        probs.Add("P(x = " + i + ") = " + (int)Math.Pow(5, count - i) * C(count, i) + "/" + (int)Math.Pow(6, count) + "\n");
                    }

                    var result = "";

                    probs.ForEach(value => result += value);

                    var mx = 0.0;
                    var dx = 0.0;

                    for (int i = 0; i <= count; i++)
                    {
                        mx += (Math.Pow(5, count - i) * C(count, i)) / (Math.Pow(6, count)) * i;
                        dx += (Math.Pow(5, count - i) * C(count, i)) / (Math.Pow(6, count)) * Math.Pow(i,2);
                    }

                    dx -= Math.Pow(mx, 2);

                    task1.answers.Add(result);
                    task1.answers.Add(String.Format("\nM(X)={0:0.0000}\nD(X)={1:0.0000}",mx,dx));

                    return task1;
                case 2:
                    Task task2 = new Task(13, 2);
                    Random random = new Random();
                    int childAmount = random.Next(3, 6 + 1);
                    task2.condition = "Предполагая одинаковой вероятность рождения мальчика и девочки, составить ряд распределения случайной величины X, " +
                        "которая выражает число мальчиков в семье, имеющей " + childAmount + " детей. Найти M(X) и D(X) этой случайной величины.";

                    double[] p = new double[childAmount + 1];
                    for (int i = 0; i < p.Length; i++)
                        p[i] = C(childAmount, i) * Math.Pow(0.5, childAmount);

                    string str = "";
                    for (int i = 0; i < p.Length; i++)
                        str += "P(x=" + i + ")=C(" + childAmount + "," + i + ")*0.5^" + childAmount + "=" + p[i] + "\n";
                    task2.answers.Add(str);
                    double mx2 = 0;
                    for (int i = 1; i <= 4; i++)
                        mx2 += i * p[i - 1];

                    double dx2 = 0;
                    for (int i = 1; i <= 4; i++)
                        dx2 += i * i * p[i - 1];

                    dx2 -= mx2 * mx2;
                    task2.answers.Add(string.Format("\nM(X)={0:0.000} \nD(X)={1:0.000}",mx2, dx2));


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
                    var rand = new Random();
                    var count = rand.Next(2,5) * 500;

                    task1.condition = "Устройство содержит " + count + " ламп.Вероятность выхода из строя одной лампы в течение одного часа работы устройства равна 0,001.";
                    task1.questions.Add("Составить ряд распределения числа ламп, вышедших из строя в течение одного часа работы устройства.");
                    task1.questions.Add("Найти M(X) этой случайной величины.");

                    var a = count * 0.001;

                    task1.answers.Add(String.Format("Pn(m) = (({0:0.0})^m) / (m!) * e^(-{0:0.0})", a));
                    task1.answers.Add(String.Format("M(X) = {0:0.0}", a));

                    return task1;
                case 2:
                    Task task2 = new Task(14, 2);
                    Random random = new Random();
                    int lampAmount = random.Next(10, 30) * 100;
                    double probDamage = random.Next(1, 10) * 10 / 1000.0;
                    task2.condition = "Торговая база получила " + lampAmount + " электрических лампочек. Вероятность повреждения электролампочки в пути равна " + probDamage + ". ";
                    task2.questions.Add("Составить ряд распределения числа лампочек, поврежденных в пути.");
                    task2.questions.Add("Найти M(X) этой случайной величины.");
                    task2.answers.Add(string.Format("Pn(m) = {0:0}^m/m! * e^(-{0:0})", lampAmount * probDamage));
                    task2.answers.Add(string.Format("M(X) = {0:0.0}", lampAmount * probDamage));
                    return task2;
            }
            throw new ArgumentException();
        }

        private static Task CreateTaskType15(int subtype)
        {
            Task task2 = new Task(15, 2);
            Random random = new Random();

            task2.tables = new List<string[,]>();

            int[] x = new int[3];
            double[] px = new double[3];

            x[0] = random.Next(-5, 0);
            x[1] = random.Next(1, 4);
            x[2] = random.Next(5, 9);

            px[0] = random.Next(1, 8)*10/100.0;
            px[1] = random.Next(1, 10 - (int)(px[0]*10)) * 10 / 100.0;
            px[2] = Math.Round((1 - px[0] - px[1])*10)/10.0;

            task2.tables.Add(new string[3, 2]);
            for (int i = 0; i < 3; i++)
            {
                task2.tables[task2.tables.Count - 1][i, 0] = x[i] +"";
                task2.tables[task2.tables.Count - 1][i, 1] = (Math.Round(px[i] * 10) / 10) + "";
            }
            task2.tables[task2.tables.Count - 1][2, 1] = "p";

            int[] y = new int[2];
            double[] py = new double[2];
            y[0] = random.Next(-2, 0);
            y[1] = random.Next(1, 5);

            py[0] = random.Next(1, 9) * 10 / 100.0;
            py[1] = Math.Round((1 - py[0]) * 10) / 10.0;

            task2.tables.Add(new string[2, 2]);
            for (int i = 0; i < 2; i++)
            {
                task2.tables[task2.tables.Count - 1][i, 0] = y[i] + "";
                task2.tables[task2.tables.Count - 1][i, 1] = (Math.Round(py[i] * 10) /10) + "";
            }

            task2.condition = "Независимые случайные величины X и Y заданы таблицами распределений. \n" +
                "x: " + x[0] + ", " + x[1] + ", " + x[2] + ". \n" +
                "p: " + px[0] + ", " + px[1] + ", p. \n\n" +
                "y: " + y[0] + ", " + y[1] + ". \n" +
                "p: " + py[0] + ", " + py[1] + ". \n" +
                "Найти: ";

            task2.questions.Add("M(X), M(Y), D(X), D(Y);");
            task2.questions.Add("Таблицы распределения случайных величин Z1 = 2X + Y, Z2 = X * Y; ");
            task2.questions.Add("M(Z1), M(Z2), D(Z1), D(Z2) непосредственно по таблицам распределений и на основании свойств математического ожидания и дисперсии.");

            double mx = 0;
            double dx = 0;
            for (int i = 0; i < 3; i++)
            {
                mx += x[i] * px[i];
                dx += x[i] * x[i] * px[i];
            }
            dx -= mx * mx;

            double my = 0;
            double dy = 0;
            for (int i = 0; i < 2; i++)
            {
                my += y[i] * py[i];
                dy += y[i] * y[i] * py[i];
            }
            dy -= my * my;
                    

            task2.answers.Add(string.Format("\nM(X)={0:0.000} \nM(Y)={1:0.000} \nD(X)={2:0.000} \nD(Y)={3:0.000}", mx, my, dx, dy));

            int[] z1 = new int[6];
            double[] pz1 = new double[6];
            for(int i = 0, j = 0; i < 3; i++, j+=2)
            {
                z1[j] = 2 * x[i] + y[0];
                z1[j+1] = 2 * x[i] + y[1];

                pz1[j] = px[i] * py[0];
                pz1[j + 1] = px[i] * py[1];
            }

            task2.tables.Add(new string[6, 2]);
            for (int i = 0; i < 6; i++)
            {
                task2.tables[task2.tables.Count - 1][i, 0] = z1[i] + "";
                task2.tables[task2.tables.Count - 1][i, 1] = (Math.Round(pz1[i] * 100) / 100) + "";
            }



            int[] z2 = new int[6];
            double[] pz2 = new double[6];
            for (int i = 0, j = 0; i < 3; i++, j += 2)
            {
                z2[j] = x[i] * y[0];
                z2[j + 1] = x[i] * y[1];

                pz2[j] = px[i] * py[0];
                pz2[j + 1] = px[i] * py[1];
            }

            task2.tables.Add(new string[6, 2]);
            for (int i = 0; i < 6; i++)
            {
                task2.tables[task2.tables.Count - 1][i, 0] = z2[i] + "";
                task2.tables[task2.tables.Count - 1][i, 1] = (Math.Round(pz2[i] * 100) / 100) + "";
            }



            task2.answers.Add(string.Format("\nz1: {0:0}, {1:0}, {2:0}, {3:0}, {4:0}, {5:0}", z1[0], z1[1], z1[2], z1[3], z1[4], z1[5]) +
                                string.Format("\np: {0:0.00}, {1:0.00}, {2:0.00}, {3:0.00}, {4:0.00}, {5:0.00}\n", pz1[0], pz1[1], pz1[2], pz1[3], pz1[4], pz1[5]) +
                                string.Format("\nz2: {0:0}, {1:0}, {2:0}, {3:0}, {4:0}, {5:0}", z2[0], z2[1], z2[2], z2[3], z2[4], z2[5]) +
                                string.Format("\np: {0:0.00}, {1:0.00}, {2:0.00}, {3:0.00}, {4:0.00}, {5:0.00}", pz2[0], pz2[1], pz2[2], pz2[3], pz2[4], pz2[5]));

            double mz1 = 0;
            double dz1 = 0;
            double mz2 = 0;
            double dz2 = 0;
            for (int i = 0; i < 6; i++)
            {
                mz1 += z1[i] * pz1[i];
                dz1 += z1[i] * z1[i] * pz1[i];

                mz2 += z2[i] * pz2[i];
                dz2 += z2[i] * z2[i] * pz2[i];
            }
            dz1 -= mz1 * mz1;
            dz2 -= mz2 * mz2;

            task2.answers.Add(string.Format("\nM(Z1)={0:0.000} \nM(Z2)={1:0.000} \nD(Z1)={2:0.000} \nD(Z2)={3:0.000}", mz1, mz2, dz1, dz2));

            
            for (int i = 0; i < task2.tables.Count; i++)
            {
                for (int j = 0; j < task2.tables[i].Length / 2; j++)
                {
                    Console.Write(task2.tables[i][j, 0] + " ");
                }
                Console.WriteLine();
                for (int j = 0; j < task2.tables[i].Length / 2; j++)
                {
                    Console.Write(task2.tables[i][j, 1] + " ");
                }
                Console.WriteLine();
                Console.WriteLine("-----------");
            }
            return task2;
        }

        private static Task CreateTaskType16(int subtype)
        {
            switch (subtype)
            {
                case 1:
                    Task task1 = new Task(16, 1);
                    var rand = new Random();

                    var a = rand.Next(0,3);
                    var b = rand.Next(3, 6);

                    var alpha = a == 0 ? "0" : a == 1 ? "π/6" : "π/4";
                    var beta = b == 3 ? "π/3" : b == 4 ? "π/2" : "π";

                    var alphaF = a == 0 ? 0 : a == 1 ? Math.PI/6.0 : Math.PI/4.0;
                    var betaF = b == 3 ? Math.PI / 3.0 : b == 4 ? Math.PI / 2.0 : Math.PI;

                    task1.condition = "Дана функция распределения F(x) непрерывной случайной величины X:\n" + 
                        "F(x) =\n" +
                        "    ⎧ 0, x ≤ 0\n" +
                        "    ⎨ (1/2) * (1 - cos x), 0 < x ≤ π\n" +
                        "    ⎩ 1, x > π\n" +
                        "α = " + alpha + ", β = " + beta + "\n" + 
                        "Требуется:";
                    task1.questions.Add("Hайти плотность вероятности f(x).");
                    task1.questions.Add("Построить графики F(x) и f(x).");
                    task1.questions.Add("Найти P(α < X < β) для данных α,β.");

                    task1.answers.Add("\nf(x) = \n    ⎧ 0, x ≤ 0\n    ⎨ sin(x) / 2, 0 < x ≤ π\n    ⎩ 0, x > π");
                    task1.answers.Add("");
                    task1.answers.Add(String.Format("P(α < X < β) = {0:0.0000}", ((1.0/2.0) * (1 - Math.Cos(betaF))) - ((1.0/2.0) * (1 - Math.Cos(alphaF)))));
                    return task1;
                case 2:
                    Task task2 = new Task(16, 2);
                    var random = new Random();

                    var alpha2 = random.Next(1, 5);
                    var beta2 = random.Next(6, 11);

                    task2.condition = "Дана функция распределения F(x) непрерывной случайной величины X:\n" +
                        "F(x) =\n" +
                        "    ⎧ 0, x ≤ 0\n" +
                        "    ⎨ x^2/100, 0 < x ≤ 10\n" +
                        "    ⎩ 1, x > 10\n" +
                        "α = " + alpha2 + ", β = " + beta2 + "\n" +
                        "Требуется:";
                    task2.questions.Add("Hайти плотность вероятности f(x).");
                    task2.questions.Add("Построить графики F(x) и f(x).");
                    task2.questions.Add("Найти P(α < X < β) для данных α,β.");

                    task2.answers.Add("\nf(x) = \n    ⎧ 0, x ≤ 0\n    ⎨ x/50, 0 < x ≤ 10\n    ⎩ 0, x > 10");
                    task2.answers.Add("");
                    task2.answers.Add(String.Format("P(α < X < β) = {0:0.0000}", (beta2 * beta2/100.0) - (alpha2* alpha2/100.0)));
                    return task2;
            }
            throw new ArgumentException();
        }

        static double fun(double x)
        {
            return x * x * x / 3.0 - 3 * x * x + 8 * x;
        }
        private static Task CreateTaskType17(int subtype)
        {
            switch (subtype)
            {
                case 1:
                    Task task1 = new Task(17, 1);
                    var rand = new Random();

                    var variant = rand.Next(1, 4);
                    var start = variant == 1 ? 2 : variant == 2 ? 2 : 3;
                    var end = variant == 1 ? 4 : variant == 2 ? 3 : 4;

                    task1.condition = "Дана плотность вероятности f(X) непрерывной случайной величины X:\nf(x)=\n" +
                        "    ⎧ 0, x < " + start + "\n" +
                        "    ⎨ a(x-2)(x-4), " + start + " ≤ x < " + end + "\n" +
                        "    ⎩ 0, x > " + end;
                    task1.questions.Add("Найти параметр a.");
                    task1.questions.Add("Построить функцию распределения F(X)");
                    task1.questions.Add("Построить графики f(X) и F(X)");

                    //var fun = (double x) => x * x * x / 3.0 - 3 * x * x + 8 * x;
                    var aa = 1 / (fun(end) - fun(start));

                    


                    task1.answers.Add("a = " + String.Format("{0:0.00}", aa));
                    task1.answers.Add("F(X) = " + String.Format("{0:0.00}x³ - {1:0.00}x² + {2:0.00}x",
                        aa / 3.0,
                        3 * aa,
                        8 * aa
                        ));

                    return task1;
                case 2:
                    Random random = new Random();
                    var b=random.Next(2, 10);
                    var a=random.Next(1, b-1);
                    Task task2 = new Task(17, 2);
                    task2.condition = "Дана функция распределения F(x) непрерывной случайной величины X:\nf(x)=\n"+
                                     "        ⎧ 0, x<" + a + '\n' +
                                     "        ⎨ a(4x+3), " + a + "≤x≤" + b + '\n' +
                                     "        ⎩ 0, x>" + b;
                    task2.questions.Add("найти параметр a;");
                    task2.questions.Add("найти функцию распределения F(x);");
                    task2.questions.Add("построить графики f(x) и F(x)");
                    double ot = 1/(2 *(double)b * (double)b + 3 * (double)b - (2 * (double)a * (double)a + 3 * (double)a));
                    task2.answers.Add(string.Format("A={0:0.0000}",ot));
                    double f1 = ot * 2;
                    double f2 = ot * 3;
                    double f3 = 2 * a * a * ot + 3 * a * ot;
                    task2.answers.Add(string.Format("{0:0.000}x²+3{1:0.000}x-{2:0.000}", f1, f2, f3));
                    return task2;
            }
            throw new ArgumentException();
        }

        static double fun2(double x)
        {
            return -(x * x) / 2.0 + 2 * x;
        }

        private static Task CreateTaskType18(int subtype)
        {
            switch (subtype)
            {
                case 1:
                    Task task1 = new Task(18, 1);
                    var rand = new Random();

                    var aa = rand.Next(0,11) / -10.0;
                    var bb = rand.Next(0,3) * 0.5 + 1;
                    
                    task1.condition = "Дана плотность вероятности f(x) непрерывной случайной величины X, имеющая две ненулевые составляющие формулы:\nf(x)=\n" +
                        "    ⎧ 0, x ≤ 0\n" +
                        "    ⎨ x, 0 < x ≤ 1 \n" +
                        "    ⎨ -x + 2, 1 < x ≤ 2\n" +
                        "    ⎩ 0, x > 2\n" +
                        "α=" + aa + " ,β=" + bb + "\n" +
                        "Требуется:";
                    task1.questions.Add("проверить свойство -∞∫∞(f(x)dx)=1");
                    task1.questions.Add("найти функцию распределния F(x)");
                    task1.questions.Add("найти P(α≤x≤β) для данных α,β");
                    task1.questions.Add("найти M(X),D(x),σ(X)");
                    task1.questions.Add("построить график f(x)");

                    task1.answers.Add("Условие выполняется.");
                    task1.answers.Add("F(X) =\n" +
                        "    ⎧ 0, x ≤ 0\n" +
                        "    ⎨ (x²)/2, 0 < x ≤ 1 \n" +
                        "    ⎨ -(x²)/2 + 2x, 1 < x ≤ 2\n" +
                        "    ⎩ 1, x > 2");

                    

                    var ans = 1 / 2.0 + fun2(bb) - fun2(1);
                    task1.answers.Add("P(α≤x≤β) = " + String.Format("{0:0.0000}", ans));

                    var mx = 1;
                    var dx = 1 / 4.0 + 11/12.0 - 1;
                    var delta = Math.Sqrt(dx);
                    task1.answers.Add(String.Format("M(X)={0:0.0000}; D(X)={1:0.0000}; σ(X)={2:0.0000}", mx, dx, delta));


                    return task1;
                case 2:
                    Task task2 = new Task(18, 2);
                    Random random = new Random();
                    var a = Math.Round(random.NextDouble() * 20.0 + 1.0)/10;
                    var b = random.Next(1, 10);
                    
                    task2.condition = "Дана плотность вероятности f(x) непрерывной случайной величины X:\nf(x)=\n" +
                                     "        ⎧ 0, x≤0" + '\n' +
                                     "        ⎨ 2x/3, 0≤x≤1"+'\n' +
                                     "        ⎨ 3-x/3, 1≤x≤3" + '\n'+
                                     "        ⎩ 0, x>3"+'\n'+
                                     "α="+a+",β="+b;

                    
                    task2.questions.Add("проверить свойство -∞∫∞(f(x)dx)=1");
                    task2.questions.Add("найти функцию распределния F(x)");
                    task2.questions.Add("найти P(α≤x≤β) для данных α,β");
                    task2.questions.Add("найти M(X),D(x),σ(X)");
                    task2.questions.Add("построить график f(x)");
                    task2.answers.Add("1/3+2/3=1 =>Условие выполнено");
                    task2.answers.Add("f(x)="+'\n' +
                                      "     ⎧ 0, x≤0" + '\n' +
                                      "     ⎨ x²/3, 0≤x≤1" + '\n' +
                                      "     ⎨ (-3-x²)/6+x, 1≤x≤3" + '\n' +
                                      "     ⎩ 1, x>3");

                    double ot3 = 3 * (double)b * (double)b * (double)b - 3 * a * a * a - 9 * (double)b * (double)b + 9 * a * a + 9 * a + 9 * (double)b;
                    task2.answers.Add(String.Format("{0:0.000}",ot3));

                    double x1 = 4.0 / 3.0, x2 = 7.0 / 18.0, x3 = Math.Sqrt(7.0 / 18.0);
                    task2.answers.Add(string.Format("M(X)={0:0.000},\nD(X)={1:0.000},\nσ(X)={2:0.000}", x1, x2, x3));
                    return task2;
            }
            throw new ArgumentException();
        }

        private static Task CreateTaskType19(int subtype)
        {
            switch (subtype)
            {
                case 1:
                    Task task1 = new Task(19, 1);

                    var rand = new Random();

                    var lambda = rand.Next(6) + 5; 

                    task1.condition = "Срок службы прибора — случайная величина X, распределенная по экспоненциальному закону с параметром λ = " + lambda + ". Необходимо:";
                    task1.questions.Add("Указать плотность вероятности f(x) и числовые характеристики этой случайной величины.");
                    task1.questions.Add("Построить кривую распределения.");

                    task1.answers.Add("f(x)=\n" +
                        "    ⎧ " + lambda + " * exp(-" + lambda + "x), x >= 0\n" +
                        "    ⎩ 0, x < 0\n\n" +
                        String.Format("M(X) = {0:0.0000}; D(X) = {1:0.0000}", (1.0 / lambda), (1.0 / (lambda * lambda))));
                        
                    return task1;
                case 2:
                    Task task2 = new Task(19, 2);
                    Random random = new Random();
                    int hours = random.Next(1, 6 + 1);
                    int minutes = random.Next(1, 20 + 1);
                    task2.condition = "Интервал движения теплоходов «Москва» на реке Иртыш составляет "+ hours + " ч. " +
                        "Дачники подходят к пристани в некоторый момент, не зная расписания. Какова вероятность того, " +
                        "что они опоздали на очередной теплоход не более чем на "+ minutes +" мин?";
                    task2.answers.Add(string.Format(minutes + "/" + (hours*60) + " ≈ {0:0.000}", minutes/(hours * 60.0)));
                    return task2;
            }
            throw new ArgumentException();
        }

        private static Task CreateTaskType20(int subtype)
        {
            switch (subtype)
            {
                case 1:
                    Task task1 = new Task(20, 1);
                    return task1;
                case 2:
                    Task task2 = new Task(20, 2);

                    return task2;
            }
            throw new ArgumentException();
        }

        private static Task CreateTaskType21(int subtype)
        {
            switch (subtype)
            {
                case 1:
                    Task task1 = new Task(21, 1);
                    return task1;
                case 2:
                    var rand = new Random();
                    Task task2 = new Task(21, 2);

                    var gamma = rand.Next(8) * 5 + 15;
                    var error = rand.Next(8) * 5 + 15;

                    task2.condition = "Случайные ошибки измерения подчинены нормальному закону со средним квадратическим отклонением " + gamma + " мм и математическим ожиданием, равным нулю.Найти вероятность того, что измерение будет произведено с ошибкой, не превосходящей по абсолютной величине " + error + " мм.";

                    task2.answers.Add(String.Format("2Ф({0:0.0000})", Convert.ToDouble(error) / Convert.ToDouble(gamma)));

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
