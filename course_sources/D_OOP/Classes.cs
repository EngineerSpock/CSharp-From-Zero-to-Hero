using System;
using D_OOP.Homeworks;

namespace OOP
{
    class Classes
    {
        static void Main(string[] args)
        {
            Main2.PureEvil();
            
            //todo explain named params
            GuessNumberGame game = new GuessNumberGame(100, 6, GuessingPlayer.Human);
            game.Start();
            Console.ReadLine();            
        }
    }

    /* 1. о классах как сущностях реального мира 
     * 2. обладает полями (характеристиками)
     * 2а. можно присвоить начальное значение
     * 3. имеет методы, имеем доступ к полям
     * 4. может быть создан и вызван метод
     */
    public class Character
    {
        int Health = 100;

        void Hit(int damage)
        {
            Health -= damage;
        }
    }

    //access modifiers
    public class Character2
    {
        //int health;
        //the same as private int health;
        //can't be accessed out of class, so:

        public int Health = 100;

        //now Health can be accessed
        //also can be internal and protected
        //internal can be accessed from outer scope but not other assembly
        //protected can be accessed from inheritors (learn more)
        //the same concerns methods
        //by default methods and fields are private

        void Hit(int damage)
        {
            Health -= damage;
        }
    }

    //props
    public class Character3
    {
        //the problem is that Health can be modified from outer scope
        //public int Health;

        //what to do if we want to provide read-access and close write access?
        //properties!
        //public int Health { get; private set; } = 100;
        //get and set can be decorated by access modifiers
        //we never make get private
        //show case when set is public (we don't need "public" keyword!)

        //read-only prop with only getter (say that we can't modify such a property - only in a constructor)

        void Hit(int damage)
        {
            Health -= damage;
        }

        //what is a property in essence?
        //btw property initializer syntax when create an instance!
        private int health = 100;
        public int Health
        {
            get
            {
                return health;
            }
            private set
            {
                health = value;
            }
        }
    }

    //props
    public class Character4
    {
        //the problem is that Health can be modified from outer scope
        //public int Health;

        //what to do if we want to provide read-access and close write access?
        //properties!
        public int Health { get; private set; } = 100;
        //get and set can be decorated by access modifiers
        //we never make get private
        //show case when set is public (we don't need "public" keyword!)

        //read-only prop with only getter (say that we can't modify such a property - only in a constructor)

        void Hit(int damage)
        {
            Health -= damage;
        }
    }

    //overload
    //default params
    
    //implemenetation in a setter
    public class Character5
    {
        public double Health { get; private set; }

        void Hit(int damage)
        {
            Health -= damage;
            if (Health < 0)
                Health = 0;
        }        
        //overload
        void Hit(double damage)
        {
            Health -= damage;
            if (Health < 0)
                Health = 0;
        }

        bool IsDead()
        {
            if (Health == 0)
                return true;
            else
                return false;
        }
    }

    public class Calculator
    {
        public double TriangleSquare(double ab, double bc, double ac)
        {
            double p = (ab + bc + ac) / 2;
            double square = Math.Sqrt(p * (p - ab) * (p - bc) * (p - ac));

            return square;

            //the same as return Math.Sqrt(p * (p - ab) * (p - bc) * (p - ac));
        }

        public double Average(int[] numbers)
        {
            int sum = 0;
            int count = 0;
            foreach (int n in numbers)
            {
                sum += n;
                count++;
            }

            double average = sum / count;
            return average;
        }

        public double Average2(params int[] numbers)
        {
            int sum = 0;
            int count = 0;
            foreach (int n in numbers)
            {
                sum += n;
                count++;
            }

            double average = sum / count;
            return average;
        }

        public bool TryDivide(double divisible, double divisor, out double result)
        {
            result = 0;
            if (divisor == 0)
                return false;

            result = divisible / divisor;
            return true;
        }

        //static method modifier - why we need to instantiate Calculator? It doesn't have state!
        //static class
        //static property can be as well as a field.
        //calling statics and static context!

        //then get to ValRefTypes.cs
        //then get back here to explain ctors        
    }

    //explain:
    //ctor: 0 to many args
    //default ctor with no args
    //more than one ctor
    //need to protect state - Character without race? Human without name?
    //ctor in struct
    //inheritance with structs
    public class Character6
    {
        public int Health { get; private set; }
        public string Race { get; }
        public int Armor { get; private set; }

        public Character6(string race, int armor = 30)
        {
            Race = race;
            Armor = armor;
        }

        void Hit(int damage)
        {
            Health -= damage;
            if (Health < 0)
                Health = 0;
        }

        bool IsDead()
        {
            if (Health == 0)
                return true;
            else
                return false;
        }
    }

    //this
    public class Point2D
    {
        private int x;
        private int y;

        public Point2D(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    //readonly and const
    public class Character7
    {
        public int Health { get; private set; } = 100;
        public string Race { get; }

        public readonly int armor;

        public Character7(string race, int armor = 30)
        {
            Race = race;
            this.armor = armor;
        }

        public const int Speed = 10;
    }

    //todo advanced: flagged enum    

    //public enum Race : int
    //{
    //    Elf = 0,
    //    Ork,
    //    Terrain
    //}

    public enum Race : int
    {
        Elf = 45,
        Ork = 50,
        Terrain = 40
    }

    public class Character8
    {
        public int Health { get; private set; }
        public Race Race { get; }
        public int Armor { get; private set; }

        public Character8(Race race)
        {
            Race = race;

            //Armor = (int)race;

            switch (race)
            {
                case Race.Ork:
                    Armor = 50;
                    break;
                case Race.Elf:
                    Armor = 45;
                    break;
                case Race.Terrain:
                    Armor = 40;
                    break;
                default:
                    Armor = 0;
                    break;
            }

            //or

            if(Race == Race.Ork)
            {
                Armor = 50;
            }      
            else if(Race == Race.Elf)
            {
                Armor = 45;
            }
            else if (Race== Race.Terrain)
            {
                Armor = 40;
            }
            else
            {
                Armor = 0;
            } 
        }

    }
}
