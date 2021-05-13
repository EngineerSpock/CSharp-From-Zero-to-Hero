using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Basics
{
    class Basics
    {
        static void Main(string[] args)
        {

            CompareStrings();
            //FormatString();
            //Console.WriteLine("Hello World");
            //CheckedOverflow();
            //StaticAndInstanceMembers();
        }

        static void Variables()
        {
            int x = -1;
            int y;
            y = 2;

            //System.Int32 x1 = -1;

            //uint z = -1;
            //uint z = 1;

            //float f = 1.0;
            float f = 1.0f;
            double d = 2.0;

            int x2 = 0;
            int x3 = new int(); //the same as previous

            var a = 1; //int
            var b = 2.0; //double
            
            //Dictionary<int, string> dict = new Dictionary<int, string>();
            var dict = new Dictionary<int, string>();
            //var v = 3;

            //decimal money = 3.0;
            decimal money = 3.0m;

            //double или decimal
            //Из выше перечисленного списка типов данных очевидно, 
            //что если мы хотим использовать в программе числа до 256,
            //то для их хранения мы можем использоват переменные типа byte.
            //При использовании больших значений мы можем взять тип short, int, long.
            //То же самое для дробных чисел - для обычных дробных чисел можно взять тип float, 
            //для очень больших дробных чисел -тип double.
            //Тип decimal здесь стоит особняком в том плане, что несмотря на большую разрядность по 
            //сравнению с типом double, тип double может хранить большее значение.
            //Однако значение decimal может содержать до 28 - 29 знаков после запятой, 
            //тогда как значение типа double -15 - 16 знаков после запятой.
            //Decimal чаще находит применение в финансовых вычислениях, 
            //тогда как double -в математических операциях.

            char character = 'A';
            string name = "John";

            bool canDrive = true;
            bool canDraw = false;

            object obj1 = 1;
            object obj2 = "obj2";

            Console.WriteLine(a);
            Console.WriteLine(name);            
        }

        static void Literals()
        {
            //пройтись по литералам из функции Variables
            int x = 0b11;
            int y = 0b1001;
            int k = 0b10001001;
            int m = 0b1000_1001;

            Console.WriteLine(x);
            Console.WriteLine(y);
            Console.WriteLine(k);
            Console.WriteLine(m);

            x = 0x1F;
            y = 0xFF0D;
            k = 0x1FAB30EF;
            m = 0x1FAB_30EF;

            Console.WriteLine(x);
            Console.WriteLine(y);
            Console.WriteLine(k);
            Console.WriteLine(m);

            Console.WriteLine(4.5e2);   // равно 4.5 * 10^2 = 450
            Console.WriteLine(3.1E-1);  // равно 3.1 * 10^-1 = 0.31

            Console.WriteLine('\x78');    // x
            Console.WriteLine('\x5A');    // Z

            Console.WriteLine('\u0420');    // Р
            Console.WriteLine('\u0421');    // С
        }

        static void Scope()
        {
            //когда будет проходить логические ветвления
            //появится вложенность с фигурными скобками
            var a = 1;
            {
                var b = 2;
                {
                    var c = 3;
                    Console.WriteLine(a);
                    Console.WriteLine(b);
                    Console.WriteLine(c);
                }
                Console.WriteLine(a);
                Console.WriteLine(b);
                //Console.WriteLine(c);
            }
            Console.WriteLine(a);
            //Console.WriteLine(b);
        }

        static void Overflow()
        {
            uint x = uint.MaxValue;

            Console.WriteLine(x);

            x = x + 1;

            Console.WriteLine(x);

            x = x - 1;

            Console.WriteLine(x);
        }

        static void CheckedOverflow()
        {
            checked
            {
                uint x = uint.MaxValue;

                Console.WriteLine(x);

                x = x + 1;

                Console.WriteLine(x);

                x = x - 1;

                Console.WriteLine(x);
            }
        }

        static void MathOperators()
        {
            int x = 1;
            x = x + 1;

            Console.WriteLine(x);

            x++;
            ++x;

            Console.WriteLine(x);

            x = x - 1;
            x--;
            --x;

            Console.WriteLine(x);

            int j = x++; //postfix increment
            Console.WriteLine(j); //j=1, x=2
            Console.WriteLine(x);
            j = ++x; //prefix increment
            Console.WriteLine(j); //j=3, x=3
            Console.WriteLine(x);

            j += 2; //j=j+2;
            Console.WriteLine(j);
            j -= 2;//j=j-2;
            Console.WriteLine(j);
            
            //

            int y = 2;

            int z = x + y;
            int k = x - y;

            int a = z + k - y;

            int b = z * 2;
            int c = k / 2;

            a = 4 % 2;
            b = 5 % 2;

            Console.WriteLine(a);
            Console.WriteLine(b);

            a = a * a;
            //a = a * a * a;
            Console.WriteLine(a);

            a = 2 + 2 * 2;
            Console.WriteLine(a);

            a = (2 + 2) * 2;
            Console.WriteLine(a);

            a *= 2;
            Console.WriteLine(a);
            a /= 2;
            Console.WriteLine(a);
            
            //

            bool areEqual = a == b;
            Console.WriteLine(areEqual);

            bool result = a > b;
            Console.WriteLine(result);

            result = a >= b;
            Console.WriteLine(result);

            result = a < b;
            Console.WriteLine(result);

            result = a <= b;
            Console.WriteLine(result);

            result = a != b;
            Console.WriteLine(result);
            //TODO PRESENTATION 
        }

        static void BitwiseOperators()
        {
            //TODO needs fundamental explanations
        }

        static void StaticAndInstanceMembers()
        {
            string name = "abracadabra";
            bool containsA = name.Contains('a');
            bool containsE = name.Contains('E');

            Console.WriteLine(containsA);
            Console.WriteLine(containsE);

            //examples of static and instance methods 

            string abc = string.Concat("a", "b", "c");
            Console.WriteLine(abc);

            Console.WriteLine(int.MinValue);

            int x = 1;
            string xStr = x.ToString();
            Console.WriteLine(xStr);
            Console.WriteLine(x);
        }

        static void QueryingStrings()
        {
            string name = "abracadabra";
            bool containsA = name.Contains('a');
            bool containsE = name.Contains('E');

            Console.WriteLine(containsA);
            Console.WriteLine(containsE);

            bool endsWithAbra = name.EndsWith("abra");
            Console.WriteLine(endsWithAbra);

            bool startsWithAbra = name.StartsWith("abra");
            Console.WriteLine(startsWithAbra);

            int indexOfA = name.IndexOf('a');
            Console.WriteLine(indexOfA);

            int lastIndexOfR = name.LastIndexOf('r');
            Console.WriteLine(lastIndexOfR);

            Console.WriteLine(name.Length);

            #region NullOrEmpty and WhiteSpace
            string empty = "";
            string whiteSpaced = " ";
            string notEmpty = " b";
            string nullString = null;

            Console.WriteLine("IsNullOrEmpty");
            bool isNullOrEmpty = string.IsNullOrEmpty(nullString);
            Console.WriteLine(isNullOrEmpty);

            isNullOrEmpty = string.IsNullOrEmpty(empty);
            Console.WriteLine(isNullOrEmpty);

            isNullOrEmpty = string.IsNullOrEmpty(whiteSpaced);
            Console.WriteLine(isNullOrEmpty);

            isNullOrEmpty = string.IsNullOrEmpty(notEmpty);
            Console.WriteLine(isNullOrEmpty);

            Console.WriteLine("IsNullOrWhiteSpace");
            bool isNullOrWhiteSpace = string.IsNullOrWhiteSpace(nullString);
            Console.WriteLine(isNullOrWhiteSpace);

            isNullOrWhiteSpace = string.IsNullOrWhiteSpace(empty);
            Console.WriteLine(isNullOrWhiteSpace);

            isNullOrWhiteSpace = string.IsNullOrWhiteSpace(whiteSpaced);
            Console.WriteLine(isNullOrWhiteSpace);

            isNullOrWhiteSpace = string.IsNullOrWhiteSpace(notEmpty);
            Console.WriteLine(isNullOrWhiteSpace);

            #endregion
        }

        static void StringModification()
        {                      
            string str = string.Empty; //same as ""           

            string nameConcat = string.Concat("My ", "name ", "is ", "John");
            nameConcat = string.Join(string.Empty, "My ", "name ", "is ", "John");
            nameConcat = "My " + "name " + "is " + "John";
            
            Console.WriteLine(nameConcat);            

            string newName = nameConcat.Insert(0, "By the way, ");
            Console.WriteLine(newName);          

            nameConcat = nameConcat.Remove(0, 1);
            Console.WriteLine(nameConcat);

            string replaced = nameConcat.Replace('n', 'z');
            Console.WriteLine(replaced);

            string data = "12;28;34;25;64";
            string[] splitData = data.Split(';');
            string first = splitData[0];
            Console.WriteLine(first);
            //nameConcat.EndsWith

            string my = nameConcat.Substring(0, 2);
            Console.WriteLine(my);

            string nameIsJohn = nameConcat.Substring(3);
            Console.WriteLine(nameIsJohn);

            char[] chars = nameConcat.ToCharArray();

            string lower = nameConcat.ToLower();
            Console.WriteLine(lower);

            string upper = nameConcat.ToUpper();
            Console.WriteLine(upper);

            string john = " My name is John ";
            Console.WriteLine(john.Trim());
        }

        static void StringBuilder()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("My ");
            sb.Append("name ");
            sb.Append("is ");
            sb.Append("John");

            Console.WriteLine(sb.ToString());
        }

        static void FormatString()
        {
            string str1 = string.Format("My name is {0} and I'm {1}", "John", 30);
            string str2 = $"My name is {"John"} and I'm {30}";            

            string str3 = "My name is \n John";
            string str4 = "I'm \t 30";
            str3 = $"My name is {Environment.NewLine} John";

            //string str5 = "I'm John and I'm a "good" programmer";
            string str5 = "I'm John and I'm a \"good\" programmer";

            string str6 = "C:\\tmp\\test_file.txt";
            str6 = @"C\tmp\test_file.txt";

            int answer = 42;
            string result = string.Format("{0:d}", answer);
            Console.WriteLine(result); // 42
            string result2 = String.Format("{0:d4}", answer);
            Console.WriteLine(result2); // 0042

            int number = 23;
            result = String.Format("{0:f}", number);
            Console.WriteLine(result); // 23,00

            double number2 = 34.09;
            result2 = String.Format("{0:f4}", number2);
            Console.WriteLine(result2); // 34,0900

            double number3 = 24.08;
            string result3 = string.Format("{0:f1}", number3);
            Console.WriteLine(result2); // 25,1

            Console.OutputEncoding = Encoding.UTF8;

            double money = 12.8;
            result = string.Format("{0:C}", money);
            Console.WriteLine(result); // $ 12.8
            result2 = string.Format("{0:C2}", money);
            Console.WriteLine(result2); // $ 12.80

            Console.WriteLine(money.ToString("C2"));

            //https://metanit.com/sharp/tutorial/7.5.php

            //доллар зависит от культуры
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            //Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ru-RU");
            https://stackoverflow.com/questions/329033/what-is-the-difference-between-currentculture-and-currentuiculture-properties-of
            http://archives.miloush.net/michkap/archive/2007/01/11/1449754.html

            Console.WriteLine(money.ToString("C2"));

        }

        static void CompareStrings()
        {
            string str1 = "abcde";
            string str2 = "abcde";

            bool areEqual = str1 == str2;
            //Console.WriteLine(areEqual);

            //the same as
            areEqual = string.Equals(str1, str2, StringComparison.InvariantCulture);
            //Console.WriteLine(areEqual);

            Console.OutputEncoding = Encoding.UTF8;
            
            // LATIN SMALL LETTER I (U+0069)
            string i1 = "\u0069";
            // LATIN SMALL LETTER DOTLESS I (U+0131)
            string i2 = "\u0131";
            // LATIN CAPITAL LETTER I (U+0049)
            string i3 = "\u0049";

            Console.WriteLine(i1 + " " + i2 + " " + i3);

            areEqual = string.Equals(i1, i2, StringComparison.InvariantCulture);
            Console.WriteLine(areEqual);

            areEqual = string.Equals(i1, i2, StringComparison.Ordinal);
            Console.WriteLine(areEqual);

            areEqual = string.Equals(i1, i2, StringComparison.CurrentCulture);
            Console.WriteLine(areEqual);

            //TODO: finish it
            //https://docs.microsoft.com/en-us/previous-versions/visualstudio/visual-studio-2008/ms230117(v=vs.90)
            //https://docs.microsoft.com/en-us/dotnet/api/system.string.compare?redirectedfrom=MSDN&view=netframework-4.8#System_String_Compare_System_String_System_String_System_StringComparison_
            //https://stackoverflow.com/questions/492799/difference-between-invariantculture-and-ordinal-string-comparison

        }

        static void ConsoleTest()
        {
            Console.WriteLine("Hi, please tell me your name.");

            string name = Console.ReadLine();
            string sentence = $"Your name is {name}";
            Console.WriteLine(sentence);

            string input = Console.ReadLine();
            int age = int.Parse(input);

            sentence = sentence + " " + age.ToString();
            Console.WriteLine(sentence);

            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;

            Console.Write("New Style");

            Console.Write("New Style\n");
            Console.WriteLine();
        }

        static void Casts()
        {
            byte b = 3; // 0000 0011
            int i = b;  // 0000 0000 0000 0000 0000 0000 0000 0011
            long l = i; // 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0011

            float f = i;
            Console.WriteLine(f); //3.0

            //doesn't compile 
            //b = i; //possible data loss, implicit conversion
            //i = f;

            //tell compiler that you're aware of possible data loss
            b = (byte)i; //explicit conversion or casting
            i = (int)f;
            Console.WriteLine(i);

            //losing decimal point
            f = 3.1f;
            i = (int)f;
            Console.WriteLine(i);

            //non-compatible types
            string str = "1";

            //can't do that:
            //i = (int)str;

            //instead:
            i = int.Parse(str);
            Console.WriteLine($"Parsed i={i}");

            int x = 5;
            int result = x / 2;
            Console.WriteLine(result);

            double res = (double) x / 2;
            Console.WriteLine(res);

            //long, bool, float also has Parse method
        }

        static void Comments()
        {
            //a single-line comment

            /* Multi-line comment
             * We can write here many words             
             */

            //describe hows and whys! not whats!
            
            int a = 1;

            //increment a by 1 - bad comment, this code is self-evident
            a++;

            //don't write comments at the right side of a line
            //above is better in general
        }

        static void MathClassAndIntelliSense()
        {
            //show that typing M we have a set of advices
            //we can apply filters
            //auto-complete
            //typing . and show that we have properties and methods
            //Camel Humps when calling BigMull
            Console.WriteLine(Math.Pow(2, 3));
            Console.WriteLine(Math.Sqrt(9));
            Console.WriteLine(Math.Sqrt(8));

            Console.WriteLine(Math.Round(1.7));
            Console.WriteLine(Math.Round(1.4));
            Console.WriteLine(Math.Round(1.5));

            //what happens if we round 1.5
            //also play around with IntelliSense
            //type in Console.WriteLine(Math.Round(1.5,
            //then using down arrow key show that we can move through overloads to see the args
            Console.WriteLine(Math.Round(1.5, MidpointRounding.ToEven));
        }

        static void ArrayIntro()
        {
            int[] a1;
            a1 = new int[10];

            int[] a2 = new int[5];

            int[] a3 = new int[5] { 1, 3, -2, 5, 10 };

            int[] a4 = { 1, 3, 2, 4, 5 };

            Console.WriteLine(a4[0]);

            int number = a4[4];
            Console.WriteLine(number);

            a4[4] = 6;
            Console.WriteLine(number);

            Console.WriteLine(a4.Length);
            Console.WriteLine(a4[a4.Length - 1]);

            string s1 = "abcdefgh";
            char first = s1[0];
            char last = s1[s1.Length - 1];

            Console.WriteLine($"First: {first}. Last: {last}");

            //impossible  s1[0] = 'z';
        }

        static void DateTimeDemo()
        {
            DateTime now = DateTime.Now;
            Console.WriteLine($"It's {now.Date}, {now.Hour}:{now.Minute}");

            //show with R# or Rider
            Console.WriteLine(now.ToString(""));
            
            DateTime dt = new DateTime(2016, 28, 2);
            DateTime newDt = dt.AddDays(1);
            Console.WriteLine(newDt.Date);

            //TimeSpan - это длительность времени
            TimeSpan ts = now - dt; //Subtract method
            Console.WriteLine(ts.Days);
            
            //TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById();
            //DateTimeOffset dto = new DateTimeOffset();
        }

        //name?
        static void Homework1()
        {
            Console.WriteLine("What's you name?");
            string name = Console.ReadLine();
            Console.WriteLine($"Hello, {name}");
        }

        //swap
        static void Homework11()
        {
            Console.WriteLine("Enter an integer");
            int a = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter an integer");
            int b = int.Parse(Console.ReadLine());

            Console.WriteLine($"a={a}, b={b}");

            int c = a;
            a = b;
            b = c;

            Console.WriteLine($"a={a}, b={b}");
        }

        static void Homework12()
        {
            //Написать метод подсчета количества цифр числа.
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(number.ToString().Length);
        }

        //triangle square
        static void Homework2()
        {
            Console.WriteLine("Let's calculate the square of a triangle.");

            Console.WriteLine("Enter the length of side AB:");
            double ab = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter the length of side BC:");
            double bc = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter the length of side AC:");
            double ac = double.Parse(Console.ReadLine());

            double p = (ab + bc + ac) / 2;

            double square = Math.Sqrt(p * (p - ab) * (p - bc) * (p - ac));
            Console.WriteLine($"Square of the triangle equals {square}");
        }

        //quizzer
        static void Homework3()
        {
            Console.WriteLine("What's your last name?");
            string lastName = Console.ReadLine();

            Console.WriteLine("What's your first name?");
            string firstName = Console.ReadLine();

            Console.WriteLine("What's your age?");
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine("What's your weight in kg?");
            double weight = double.Parse(Console.ReadLine());

            Console.WriteLine("What's your height in cm?");
            double heights = double.Parse(Console.ReadLine());

            double bodyMassIndex = weight / heights * heights;

            string profile = 
                  $"Your profile:{Environment.NewLine}" 
                + $"Full Name: {lastName} {firstName}{Environment.NewLine}"
                + $"Age: {age}{Environment.NewLine}"
                + $"Weight: {weight}{Environment.NewLine}"
                + $"Heigths: {heights}{Environment.NewLine}"
                + $"Body Mass Index: {bodyMassIndex}";

            Console.WriteLine(profile);
        }
    }
}
