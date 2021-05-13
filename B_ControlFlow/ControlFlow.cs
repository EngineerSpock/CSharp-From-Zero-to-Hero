using System;

namespace ControlFlow
{
    class ControlFlow
    {
        static void Main(string[] args)
        {
            Break();
            //NestedForLoop();
            //Homework4();
            //Console.WriteLine("Hello World!");
            Console.Read();
        }

        static void LogicalOperators()
        {
            //TODO before moving to if-else with loops
            //&&, ||, ! (not)
            Console.WriteLine("What's your age?");
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine("What's your weight in kg?");
            double weight = double.Parse(Console.ReadLine());

            Console.WriteLine("What's your height in cm?");
            double heights = double.Parse(Console.ReadLine());

            double bodyMassIndex = weight / heights * heights;

            bool isTooLow = bodyMassIndex <= 18.5;
            bool isNormal = bodyMassIndex > 18.5 && bodyMassIndex <= 24.99;
            bool isAboveNormal = bodyMassIndex >= 25 && bodyMassIndex <= 30;
            bool isTooFat = bodyMassIndex > 30;

            bool isFat = isAboveNormal || isTooFat;

            if (isFat)
            {
                Console.WriteLine("What a pig!");
            }
            else
            {
                Console.WriteLine("Oh, you're in a good shape!");
            }
            //say that braces are not have to use
            //if there is a one-liner inside

            if (!isFat)
            {
                Console.WriteLine("You're definitely not fat!");
            }

            //if-else
            //difference between if-elseif and multiple ifs
            if (isTooLow)
            {
                Console.WriteLine("Not enough weights.");
            }
            else if (isNormal)
            {
                Console.WriteLine("You're OK");
            }
            else if (isAboveNormal)
            {
                Console.WriteLine("Be careful.");
            }
            else
            {
                Console.WriteLine("You need to lose some weights.");
            }

            if(isFat || isTooFat)
            {
                Console.WriteLine("Anyway it's time to get on diet");
            }

            string description = age > 18 ? "Можно пить!" : "Подрасти пока!";
            Console.WriteLine(description);
        }

        static void MaxNumber1()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            int max = a;
            if (b > a)
                max = b;

            Console.WriteLine(max);
        }

        static void MaxNumber2()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            int max;
            if (a > b)
                max = a;
            else
                max = b;

            Console.WriteLine(max);
        }

        static void MaxNumber3()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            int max = a > b ? a : b;
            
            Console.WriteLine(max);
        }

        static void ForForeach()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + " ");
            }

            Console.WriteLine();

            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                Console.Write(numbers[i] + " ");
            }

            //we can declare j instead of i
            for (int i = 0; i < numbers.Length; i++)
            {
                if (i % 2 == 0)
                {
                    Console.Write(numbers[i] + " ");
                }                
            }
            Console.WriteLine();

            foreach(int i in numbers)
            {
                Console.Write(numbers[i] + " ");
            }
            Console.WriteLine();
        }        

        static void NestedForLoop()
        {
            int[] numbers = { 1, -2, 4, -7, 5, 3, 2, -1, -3, 2, 7, -1, -3, 1, 7};

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    int atI = numbers[i];
                    int atJ = numbers[j];
                    if (atI + atJ == 0)
                    {
                        Console.WriteLine($"Pair ({atI};{atJ}). Indexes ({i};{j})");
                    }                    
                }
            }

            Console.WriteLine();

            for (int i = 0; i < numbers.Length - 2; i++)
            {
                for (int j = i + 1; j < numbers.Length - 1; j++)
                {
                    for(int k = j + 1; k<numbers.Length; k++)
                    {
                        int atI = numbers[i];
                        int atJ = numbers[j];
                        int atK = numbers[k];
                        if (atI + atJ + atK == 0)
                        {
                            Console.WriteLine($"Pair ({atI};{atJ};{atK}). Indexes ({i};{j};{k})");
                        }
                    }
                    
                }
            }
        }

        static void DoWhile()
        {
            int age = 0;

            while (age < 18)
            {
                Console.WriteLine("What is your age?");
                age = int.Parse(Console.ReadLine());
            }

            do
            {
                Console.WriteLine("What is your age?");
                age = int.Parse(Console.ReadLine());
            }
            while (age < 18);

            //
            int[] numbers = { 1, 2, 3, 4, 5 };
            int i = 0;
            while (i < 5)
            {
                Console.Write(numbers[i]);
                i++;
            }
        }

        static void Break()
        {
            for (int i = 1; i <= 4; i++)
            {
                if (i == 3)
                    break;
                Console.WriteLine("i value: {0}", i);
            }

            Console.ReadLine();

            int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            char[] letters = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j' };

            // Outer loop
            for (int x = 0; x < numbers.Length; x++)
            {
                Console.WriteLine("num = {0}", numbers[x]);

                // Inner loop
                for (int y = 0; y < letters.Length; y++)
                {
                    if (y == x)
                    {
                        // Return control to outer loop
                        break;
                    }
                    Console.Write(" {0} ", letters[y]);
                }
                Console.WriteLine();
            }
        }

        static void Switch()
        {
            //https://stackoverflow.com/questions/395618/is-there-any-significant-difference-between-using-if-else-and-switch-case-in-c
            //optimized
            //not optimized on strings
            //more readable than 15 if-elseif statements

            int weddingYears = int.Parse(Console.ReadLine());

            string name = string.Empty;
            switch (weddingYears)
            {
                case 5:
                    name = "Деревянная свадьба";
                    break;
                case 10:
                    name = "Оловянная свадьба";
                    break;
                case 15:
                    name = "Хрустальная свадьба";
                    break;
                case 20:
                    name = "Фарфоровая свадьба";
                    break;
                case 25:
                    name = "Серебряная  свадьба";
                    break;
                case 30:
                    name = "Жемчужная свадьба";
                    break;
                default:
                    name = "Не знаем такого юбилея!";
                    break;
            }
            Console.WriteLine(name);


            int month = int.Parse(Console.ReadLine());

            string season = string.Empty;

            switch (month)
            {
                case 1:
                case 2:
                case 12:
                    season = "Winter";
                    break;
                case 3:
                case 4:
                case 5:
                    season = "Spring";
                    break;
                case 6:
                case 7:
                case 8:
                    season = "Summer";
                    break;
                case 9:
                case 10:
                case 11:
                    season = "Autumn";
                    break;
            }
            Console.WriteLine(season);
        }

        static void Continue()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            foreach(var n in numbers)
            {
                //if (n % 2 == 0)
                //    Console.WriteLine(n);

                //or

                if (n % 2 != 0)
                    continue;

                Console.WriteLine(n);
            }
        }

        static void DemoDebugging()
        {
            //f9, f10, f11, f5, ctrl+f5
            
            Console.WriteLine("Let's calculate the square of a triangle.");
            Console.WriteLine("Enter the length of side AB:");
            double ab = GetDouble();

            Console.WriteLine("Enter the length of side BC:");
            double bc = GetDouble();

            Console.WriteLine("Enter the length of side AC:");
            double ac = GetDouble();

            double p = (ab + bc + ac) / 2;
            
            //demo exception
            //double p = (ab + bc + ac) / 0;

            double square = Math.Sqrt(p * (p - ab) * (p - bc) * (p - ac));
            Console.WriteLine($"Square of the triangle equals {square}");
        }

        static double GetDouble()
        {
            return double.Parse(Console.ReadLine());
        }
        
        //parse 10 numbers and calc average
        static void Homework1()
        {
            /*
            Напишите программу, которая запрашивает до 10
            целых чисел от пользователя. 
            Проверку на целочисленность делать не надо.
            Если пользователь вводит 0, ввод заканчивается и программа
            высчитывает среднее арифметическое положительных чисел кратных 3.            
           */

            int[] numbers = new int[10];

            int inputCount = 0;
            while(inputCount < 10)
            {
                int number = int.Parse(Console.ReadLine());
                numbers[inputCount] = number;
                inputCount++;

                if (number == 0)
                    break;
            }

            int sum = 0;
            int count = 0;
            foreach(int n in numbers)
            {
                if (n > 0 && n % 3 == 0)
                {
                    sum += n;
                    count++;
                }
            }

            double average = (double)sum / count;
            Console.WriteLine(average);
        }

        //factorial in a loop
        static void Homework2()
        {
            Console.WriteLine("Enter N >= 0");
            int n = int.Parse(Console.ReadLine());

            long factorial = 1;
            for (int i = 1; i <= n; i++)
            {
                factorial *= i;
            }

            Console.WriteLine(factorial);
        }

        //fibonacci numbers in a loop
        static void Homework0()
        {
            Console.WriteLine("Enter the number of Fibonacci numbers you want to calculate.");
            int n = int.Parse(Console.ReadLine());

            int[] fibonacci = new int[n];            

            int a0 = 0;
            int a1 = 1;

            fibonacci[0] = a0;
            fibonacci[1] = a1;

            for (int i = 2; i < n; i++)
            {
                int a = a0 + a1;
                fibonacci[i] = a;

                a0 = a1;
                a1 = a;
            }  
            
            foreach(int cur in fibonacci)
            {
                Console.WriteLine(cur);
            }
        }

        //3 login attempts
        static void Homework4()
        {
            string password = "qwerty";
            string login = "johnsilver";

            //написать программу которая запрашивает логин и пароль
            //если введён правильный, выводит "вход в систему"
            //даёт максимум три попытки
            //если попытки исчерпаны выводит "превышено кол-во попыток"

            int tries = 1;
            while(tries <= 3)
            {
                Console.WriteLine("Enter login");
                string userLogin = Console.ReadLine();
                string userPass = Console.ReadLine();

                if(userLogin == login && password == userPass)
                {
                    Console.WriteLine("Вход в систему");
                }
                tries++;               
            }
            if(tries == 4)
            {
                Console.WriteLine("Превышено кол-во попыток");
            }
        }
    }
}
