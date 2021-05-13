using System;
using System.Collections.Generic;
using System.Text;

namespace D_OOP.Homeworks
{
    public class Main3
    {
        static void Run()
        {
            Console.WriteLine("Driving a car");
            Car c1 = new Car();
            c1.Drive();

            Console.WriteLine("Driving a sport car");
            SportCar c2 = new SportCar();
            //drive is available c2.Drive();
            c2.Boost();

            Console.WriteLine("Driving a truck");

            Truck c3 = new Truck();
            c3.MoveOn();

            Console.WriteLine("--------------------------");

            Shape[] shapes = new Shape[2];
            shapes[0] = new Triangle(10, 20, 30);
            shapes[1] = new Rectangle(5, 10);

            foreach(Shape shape in shapes)
            {
                shape.Draw();
                Console.WriteLine(shape.Perimeter());
            }
        }

        //allows to work with a hierarchy of classes
        //in a uniform way declared by parent
        static void Connect(BankTerminal terminal)
        {
            terminal.Connect();
        }
        
        static double Area(Shape shape)
        {
            return shape.Area();
        }
    }

    //polimorphysm
    public class BankTerminal
    {
        protected string id;
        public virtual void Connect()
        {
            Console.WriteLine("General Connecting Protocol");
        }
    }

    public class ModelXTerminal : BankTerminal
    {
        //base
        public ModelXTerminal(string id)
        {
            base.id = id;
        }
        public override void Connect()
        {
            base.Connect(); //not obliged to call
            Console.WriteLine("Additional actions for Model X");
        }
    }

    public class ModelYTerminal : BankTerminal
    {
        public ModelYTerminal(string id)
        {
            base.id = id;
        }
        public override void Connect()
        {
            base.Connect(); //not obliged to call
            Console.WriteLine("Additional actions for Model Y");
        }
    }

    //not obliged to mark as abstract
    public abstract class Shape
    {
        public Shape()
        {
            Console.WriteLine("Shape Created");
        }

        public abstract void Draw();

        public abstract double Area();

        public abstract double Perimeter();

        //if class is abstract then you can't create an instance
        //but you can mark methods as abstract and implement other's
        //if class is not abstract (Draw can have implementation for examples
        //while others are abstract
    }

    //create rectangle and show that base ctor runs as well
    public class Rectangle : Shape
    {
        private readonly double width;
        private readonly double height;

        public Rectangle(double width, double height) //this is hidden: base()
        {
            this.width = width;
            this.height = height;

            Console.WriteLine("Rectangle created.");
        }

        //what if we want to overrive the bahavior
        public override double Area()
        {
            return width * height;
        }

        public override void Draw()
        {
            Console.WriteLine("Drawing Rectangle");
        }

        public override double Perimeter()
        {
            return 2*(width + height);
        }
    }

    public class Triangle : Shape
    {
        private readonly double ab;
        private readonly double bc;
        private readonly double ac;

        public Triangle(double ab, double bc, double ac)
        {
            this.ab = ab;
            this.bc = bc;
            this.ac = ac;
        }

        public override double Area()
        {
            double s = (ab + bc + ac) / 2;
            return Math.Sqrt(s * (s - ab) * (s - bc) * (s - ac));
        }

        public override void Draw()
        {
            Console.WriteLine("Drwaing Triangle");
        }

        public override double Perimeter()
        {
            return ab + bc + ac;
        }
    }

    //reusability
    public class Car
    {
        public int Speed { get; protected set; } = 100;

        //at least protected for accessing from children
        public void Drive()
        {
            //implementing work with engine 
            Console.WriteLine("Driving");
        }
    }
    public class SportCar : Car
    {
        public void Boost()
        {
            Console.WriteLine($"Current Speed = {Speed}");
            base.Drive();
            Console.WriteLine("Boost");
        }
    }
    public class Truck : Car
    {
        public void MoveOn()
        {
            Console.WriteLine($"Current Speed = {Speed}");
            base.Drive();
            Console.WriteLine("Move on");
        }
    }


    //is-a
    //has-a
    public class Radio
    {
        public void PlayMusic()
        {

        }
    }

    public class Car2
    {
        //has-a
        private Radio radio = new Radio();
        public int Speed { get; protected set; } = 100;

        //at least protected for accessing from children
        public void Drive()
        {
            //implementing work with engine 
            Console.WriteLine("Driving");
        }
    }

    //sealed classes
}