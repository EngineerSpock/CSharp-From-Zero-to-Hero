using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Files
{
    class Files
    {
        static void Main(string[] args)
        {
            UseFileStream();
        }

        /*
         * Stream - класс, который имитирующий поток byte (байтов), выстроенные в ряд. 
         * Например, передача данных в сети, передаваемые данные - 
         * это непрерывный поток байтов от первого байта до последнего байта.
         * https://o7planning.org/ru/10535/csharp-streams-tutorial-binary-streams-in-csharp
         * 
         * Stream является абстрактным классом, он не может инициализировать объект сам, 
         * вы можете инициализировать объект Stream из конструкторов подкласса. 
         * Класс Stream предоставляет базовые методы работы с потоками данных, 
         * а именно метод чтения / записи байта или массив байтов.
         * */
        static void UseFileStream()
        {
            //in a current folder - bin\debug or bin\release
            FileStream fs = new FileStream("test.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);

            try
            {            
                // Этот массив соответствует: {'H','e','l','l','o',' ','W','o','r','l','d','!'}.
                //ascii codes
                //byte[] bytes = {72, 101, 108, 108, 111, 32, 87, 111, 114, 108, 100, 33};
                string str = "Hello, World";
                byte[] strInBytes = Encoding.ASCII.GetBytes(str);

                if (fs.CanWrite)
                {
                    fs.Write(strInBytes, 0, strInBytes.Length);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error:" + e);
            }
            finally
            {
                fs.Close();
            }

            //tell about Flush

            using (Stream readingStream = new FileStream("test.txt", FileMode.Open))
            {
                byte[] temp = new byte[14];
                UTF8Encoding encoding = new UTF8Encoding();

                int len = 0;

                while ((len = readingStream.Read(temp, 0, temp.Length)) > 0)
                {
                    // Конвертировать в строку (String).
                    // ('len' элемент, начинающийся с индекса 0).
                    string s = encoding.GetString(temp, 0, len);

                    //or

                    string str = Encoding.ASCII.GetString(temp);

                    Console.WriteLine(s);
                }
            }

            Console.ReadLine();
        }

        static void FileShortcuts()
        {
            string[] allLines = File.ReadAllLines("test.txt");
            string allText = File.ReadAllText("test.txt");
            IEnumerable<string> lines = File.ReadLines("test.txt", Encoding.ASCII);

            File.WriteAllText("test_2.txt", "My name is John");
            File.WriteAllLines("test_3.txt", new string[] { "My name", "is John" });
            File.WriteAllBytes("test_4.txt", new byte[] { 72, 101, 108, 108, 111 });

            //static methods are better when it's a single time operation and everything gets writted down in a single shot
            //otherwise you may want to keep a stream opened and append to it symbols from time to time and manage the seeker.
        }

        static void FilesManipulation()
        {
            try
            {
                File.Copy("test.txt", "test_copy.txt", overwrite: true);

                //rename
                File.Move("test_copy.txt", "test_copy_renamed.txt");

                File.Delete("test_copy.txt");

                //doesn't guarantee that it really exists due to the fact
                //that it could be removed right after check and before usage
                if (File.Exists("test.txt"))
                {
                    File.AppendAllText("test.txt", "bla");
                }

                File.Replace("test_2.txt", "test_3.txt", "test_backup.txt");

                bool existsDir = Directory.Exists(@"C:\tmp");
                if (existsDir)
                {
                    IEnumerable<string> files = Directory.EnumerateFiles(@"C:\tmp", "*.txt", SearchOption.AllDirectories);
                    foreach(var file in files)
                    {
                        Console.WriteLine(file);
                    }
                }
                //Directory.Delete
                //etc                
            }
            catch(IOException ex)
            {

            }
            
        }

        //static void 
    }
}

/*
 * **Существует алгоритмическая игра «Удвоитель». В этой игре предлагается какое-то число, а человек должен, управляя роботом «Удвоитель», достичь этого числа за минимальное число шагов. Робот умеет выполнять несколько команд: увеличить число на 1, умножить число на 2 и сбросить число до 1. Начальное значение удвоителя равно 1. 
Реализовать класс «Удвоитель». Класс хранит в себе поле current — текущее значение, finish — число, которого нужно достичь, конструктор, в котором задаётся конечное число. Методы: увеличить число на 1, увеличить число в два раза, сброс текущего до 1, свойство Current, которое возвращает текущее значение, свойство Finish, которое возвращает конечное значение.  Создать с помощью этого класса игру, в которой компьютер загадывает число, а человек, выбирая из меню на экране, отдаёт команды удвоителю и старается получить это число за наименьшее число ходов. Если человек получает число больше положенного, игра прекращается.
***Написать игру «Верю. Не верю». В файле хранятся некоторые данные, правда это или нет. Например: «Шариковую ручку изобрели в древнем Египте», «Да».
Компьютер загружает эти данные, случайным образом выбирает 5 вопросов и задаёт их игроку.
Игрок пытается ответить, правда или нет то, что ему загадали, и набирает баллы. Список вопросов ищите во вложении или можно воспользоваться интернетом.
Достаточно решить 3 задачи. Старайтесь разбивать программы на подпрограммы. Переписывайте в начало программы условие и свою фамилию. Все программы сделать в одном решении.
*/
