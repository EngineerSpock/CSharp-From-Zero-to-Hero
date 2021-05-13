using System;
using System.Collections.Generic;
using System.Text;

namespace D_OOP.Homeworks
{
    //todo presentation 011 Hamedani
    public struct PointVal
    {
        public int X;
        public int Y;

        public void LogValues()
        {
            Console.WriteLine($"X={X}; Y={Y}");
        }
    }

    public class PointRef
    {
        public int X;
        public int Y;

        public void LogValues()
        {
            Console.WriteLine($"X={X}; Y={Y}");
        }
    }

    public struct EvilStruct
    {
        public int X;
        public int Y;
        
        public PointRef PointRef;
    }
    

    public class Main2
    {
        public static void PureEvil()
        {
            EvilStruct es1 = new EvilStruct();
            es1.PointRef = new PointRef {X = 1, Y = 2};

            EvilStruct es2 = es1;
            
            Console.WriteLine($"es1.PointRef.X={es1.PointRef.X}, es1.PointRef.Y={es1.PointRef.Y}");
            Console.WriteLine($"es2.PointRef.X={es2.PointRef.X}, es2.PointRef.Y={es2.PointRef.Y}");
            
            es2.PointRef.X = 42;
            es2.PointRef.Y = 45;
            
            Console.WriteLine($"es1.PointRef.X={es1.PointRef.X}, es1.PointRef.Y={es1.PointRef.Y}");
            Console.WriteLine($"es2.PointRef.X={es2.PointRef.X}, es2.PointRef.Y={es2.PointRef.Y}");
        }
        
        public static void Run()
        {
            //Point a = new Point();
            PointVal a;
            a.X = 3;
            a.Y = 5;

            PointVal b = a;
            b.X = 7;
            b.Y = 10;

            a.LogValues();
            b.LogValues();

            //

            PointRef c = new PointRef() { X = 3, Y = 5 };

            //c.X = 3;
            //c.Y = 5;

            PointRef d = c;
            d.X = 7;
            d.Y = 10;

            c.LogValues();
            d.LogValues();
        }

        //modifies list
        //modifications are visible to caller
        public static void AddNumbers(List<int> numbers)
        {
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(3);
        }

        //not visible at a caller's side
        //to make it visible, add ref modifier
        public static void Swap(int a, int b)
        {
            Console.WriteLine($"Original. a={a}, b={b}");

            int tmp = a;
            a = b;
            b = tmp;

            Console.WriteLine($"Swapped. a={a}, b={b}");
        }

        private static void NullRefExceptionNullable()
        {
            //tell about nulls
            PointRef c = null;
            Console.WriteLine(c.X); //exception

            PointVal? nulllableVal = null; //useful when we fetch data from a databse and the field is null in db
            if (nulllableVal.HasValue)
            {
                
            }
            //or
            PointVal defaultVal = nulllableVal.GetValueOrDefault();
        }

        //can be passed any object!
        private static void AsIsCasting(object obj)
        {
            bool isPointRef = obj is PointRef;
            if (isPointRef)
            {
                PointRef instance = (PointRef) obj;
            }
            //or
            PointRef pr = obj as PointRef;
            if (pr != null)
            {
                //do anything
            }
        }
    }
}
