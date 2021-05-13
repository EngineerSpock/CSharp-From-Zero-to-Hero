using System;
using System.IO;

namespace Exceptions
{

    //how to throw and encapsulation
    public class Character5
    {
        //information hiding
        //consisten state
        public double Health { get; private set; }

        public Character5(string name, int armor)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name arg can't be null");
            }
            
            if(armor < 0 || armor > 100)
            {
                throw new ArgumentException("armor can't less than 0 or greater than 100");
            }
        }

        void Hit(int damage)
        {
            if (IsDead())
            {
                throw new InvalidOperationException("Can't hit a dead character.");
            }

            if (damage > 100)
                throw new ArgumentException("damage can't be greater than 100");

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

    class Program
    {
        
        //concrete exceptions
        //general clause
        //logging
        //fail of runtime
        static void Main(string[] args)
        {
            Console.WriteLine("Please input a number");

            string result = Console.ReadLine();

            //exception
            //int number = int.Parse(result);

            int number = 0;
            try
            {
                number = int.Parse(result);
            }
            catch(FormatException ex)
            {
                Console.WriteLine("A format exception occured.");
                Console.WriteLine("Data below:");
                Console.WriteLine(ex);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Unknown exception");
                Console.WriteLine("The input is invalid.");
                Console.WriteLine(ex);
            }
            //the same:
            //catch
            //{
            //    Console.WriteLine("Unknown exception");
            //    Console.WriteLine("The input is invalid.");
            //}

            //-------------------------------------
            Console.WriteLine(number);

            FileStream file = null;
            try
            {
                file = File.Open("temp.txt", FileMode.Open);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                if (file != null)
                    file.Close(); //IDisposable
            }
        }
    }
}
