using System;
using System.Collections.Generic;
using System.Text;

namespace D_OOP.Homeworks
{
    //can't have implementation
    //just a bunch of signatures
    //can do
    public interface ICollection
    {
        void Add(object obj);
        void Remove(object obj);
    }

    public class BaseList
    {

    }
    public class BaseCollection
    {

    }

    //show
    //can't inherit from multiple classes
    //but can inherit from one class and multiple interfaces
    //or from just multiple interfaces
    public class MyList : ICollection
        //IDisposable, ISerializable
    {
        public void Add(object obj)
        {
            //implementation
        }

        public void Remove(object obj)
        {
            //implementation
        }
    }

    public static class ICollectionExt
    {
        public static void AddRange(this ICollection collection, IEnumerable<object> objects)
        {
            foreach(var item in objects)
            {
                collection.Add(collection);
            }
        }
    }

    //can do
    class Interfaces
    {
        static void Interface(ICollection collection)
        {
            collection.Add(1);
        }

        static void Main3()
        {
            Rect rect = new Rect { Height = 2, Width = 5 };
            int rectArea = AreaCalculator.CalcSquare(rect);
            Console.WriteLine($"Rectangle area = {rectArea}");

            Rect square = new Square() { Height = 2, Width = 10 };
            //what the hell?
            //we can fix the problem by introducing an interface!
        }
    }

    public class Rect
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }

    public class Square : Rect
    {

    }

    public class AreaCalculator
    {
        public static int CalcSquare(Square square) => square.Height * square.Height;
        public static int CalcSquare(Rect square) => square.Width * square.Height;
    }


}
