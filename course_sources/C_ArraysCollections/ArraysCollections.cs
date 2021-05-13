using System;
using System.Collections.Generic;
using System.Linq;

namespace ArraysCollections
{
    class ArraysCollections
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        private static void ArraysDemo()
        {
            int[] a1;
            a1 = new int[10];

            int[] a2 = new int[5];

            int[] a3 = new int[5] { 1, 3, -2, 5, 10 };

            int[] a4 = { 1, 3, 2, 4, 5 };

            Console.WriteLine();

            Array myArray = new int[5];

            Array myArray2 = Array.CreateInstance(typeof(int), 5);
            myArray2.SetValue(1, 0);

            Console.Read();
        }
        
        private static void ArrayMethods()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int index = Array.BinarySearch(numbers, 7);
            Console.WriteLine(index);

            int[] copy = new int[10];
            Array.Copy(numbers, copy, numbers.Length);

            int[] anotherCopy = new int[10];
            copy.CopyTo(anotherCopy, 0);

            //Array.IndexOf and LastIndexOf the same as in case of copy.IndexOf and actually was already studied

            Array.Reverse(copy);
            foreach (var c in copy)
            {
                Console.WriteLine(c);
            }

            Array.Sort(copy);
            foreach (var c in copy)
            {
                Console.WriteLine(c);
            }

            Array.Clear(numbers, 0, numbers.Length);            
        }


        private static void ListDemo()
        {           
            var intList = new List<int>() { 1, 4, 2, 7, 5, 9, 12, 3, 2, 1 };
            intList.Add(7);

            int[] intArray = { 1, 2, 3 };
            intList.AddRange(intArray);

            if(intList.Remove(1)) //first occurence
            {
                //do
            }
            intList.RemoveAt(0);

            intList.Reverse();

            bool contains = intList.Contains(3);
           
            //system.linq
            int min = intList.Min();
            int max = intList.Max();

            int indexOf = intList.IndexOf(2);
            int lastIndexOf = intList.LastIndexOf(2);

            for (int i = 0; i < intList.Count; i++)
            {
                Console.Write($"{intList[i]} ");
            }
            Console.WriteLine();

            foreach (var item in intList)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }

        private static void DictDemo()
        {
            //adding
            var people = new Dictionary<int, string>();
            people.Add(1, "John");
            people.Add(2, "Bob");
            people.Add(2, "Alice");

            //the same
            people = new Dictionary<int, string>()
            {
                {1, "John" },
                {2, "Bob" },
                {3, "Alice" },
            };

            string name = people[1];
            Console.WriteLine(name);

            //iterating over keys
            Console.WriteLine("Iterating over keys");
            Dictionary<int, string>.KeyCollection keys = people.Keys;
            foreach (var item in keys)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            //iterating over values
            Console.WriteLine("Iterating over values");
            Dictionary<int, string>.ValueCollection values = people.Values;
            foreach (var item in values)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            //iterating over key-value pairs
            Console.WriteLine("Iterating over key-value pairs");
            foreach (KeyValuePair<int, string> pair in people)
            {
                Console.WriteLine($"Key:{pair.Key}. Value:{pair.Value}");
            }
            Console.WriteLine();

            //properties and methods

            Console.WriteLine(people.Count);

            bool containsKey = people.ContainsKey(2);

            //much slower, dicts are suited for fast key-searching
            bool containsValue = people.ContainsValue("John");

            Console.WriteLine($"Contains key:{containsKey}. Contains Value:{containsValue}");

            people.Remove(1);

            if(people.TryAdd(2, "Elias"))
            {
                Console.WriteLine("Added Successfully");
            }
            else
            {
                Console.WriteLine("Failed to add");
            }
            if(people.TryGetValue(2, out string val))
            {
                Console.WriteLine($"Key 2, Val={val}");
            }
            else
            {
                Console.WriteLine($"Failed to get");
            }

            people.Clear();
        }

        private static void StackDemo()
        {
            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);

            Console.WriteLine($"Should print out 4:{stack.Peek()}");

            stack.Pop();

            Console.WriteLine($"Should print out 3:{stack.Peek()}");

            Console.WriteLine("Iterate over the stack.");
            foreach (var cur in stack)
            {
                Console.WriteLine(cur);
            }
        }

        private static void QueueDemo()
        {
            var queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);

            Console.WriteLine($"Should print out 4:{queue.Peek()}");

            Console.WriteLine($"Dequeued:{queue.Dequeue()}");

            Console.WriteLine($"Should print out 3:{queue.Peek()}");

            Console.WriteLine("Iterate over the queue.");
            foreach (var cur in queue)
            {
                Console.WriteLine(cur);
            }
        }

        private static void MultiDimArrays()
        {
            int[,] r1 = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };
            int[,] r2 = { { 1, 2, 3 }, { 4, 5, 6 } };

            for (int i = 0; i < r2.GetLength(0); i++)
            {
                for (int j = 0; j < r2.GetLength(1); j++)
                {
                    Console.WriteLine($"{r2[i, j]}");
                }
                Console.WriteLine();
            }
        }

        private static void JaggedArraysDemo()
        {
            int[][] jaggedArray = new int[4][];
            jaggedArray[0] = new int[1];
            jaggedArray[1] = new int[3];
            jaggedArray[2] = new int[2];
            jaggedArray[3] = new int[4];

            Console.WriteLine("Enter the numbers for a jagged arary.");

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    string st = Console.ReadLine();
                    jaggedArray[i][j] = int.Parse(st);
                }
            }

            Console.WriteLine("");
            Console.WriteLine("Printing the Elements:");

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write(jaggedArray[i][j]);
                    Console.Write("\0");
                }

                Console.WriteLine("");
            }
        }

        private static void Test1BasedArray()
        {
            Array myArray = Array.CreateInstance(typeof(int), new[] { 4 }, new[] { 1 });

            myArray.SetValue(2019, 1);
            myArray.SetValue(2020, 2);
            myArray.SetValue(2021, 3);
            myArray.SetValue(2022, 4);

            Console.WriteLine($"Starting index:{myArray.GetLowerBound(0)}");
            Console.WriteLine($"Ending index:{myArray.GetUpperBound(0)}");

            //for (int i = myArray.GetLowerBound(0); i <= myArray.GetUpperBound(0); i++)
            for (int i = 1; i < 5; i++)
            {
                Console.WriteLine($"{myArray.GetValue(i)} at index {i}");
            }
        }

      
        static void Homework1()
        {
            //частотность
            //todo
        }

        static void Homework2()
        {
            //min sum line in a matrix
            //todo
        }
    }
}
