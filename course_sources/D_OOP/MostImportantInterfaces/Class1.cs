using System;
using System.Collections.Generic;

namespace D_OOP.Homeworks.MostImportantInterfaces
{
    //IEnumerable, //IComparable, IDisposable
    
    //IComparable, IComparer, IEquatable, IEqualityComparer, IStructuralEquatable
    public class Person : IEquatable<Person>, IComparable<Person>
    {
        public string FullName { get; }
        public string Ssn { get; }
        
        public int Age { get; }
        
        public bool Equals(Person other)
        {
            if (other == null)
                return false;

            return Ssn == other.Ssn && FullName == other.FullName;
        }

        public int CompareTo(Person other)
        {
            if (other == null)
                return 1;

            if (Age > other.Age)
            {
                return 1;
            }
            if (Age < other.Age)
            {
                return -1;
            }
            return 0;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Person p = obj as Person;
            if (p == null)
                return false;

            return Equals(p);
        }
        public int GetHashCode(Person obj)
        {
            unchecked
            {
                const int HashingBase = (int) 2166136261;
                const int HashingMultiplier = 16777619;

                int hash = HashingBase;
                hash = (hash * HashingMultiplier) ^
                       (obj.Ssn != null ? obj.Ssn.GetHashCode() : 0);
                hash = (hash * HashingMultiplier) ^
                       (obj.FullName != null ? obj.FullName.GetHashCode() : 0);
                hash = (hash * HashingMultiplier) ^ obj.Age;
                return hash;
            }          
        }
    }

    public class VehicleEqualityComparer : IEqualityComparer<Person>, IComparer<Person>
    {
        public bool Equals(Person x, Person y)
        {
            return Compare(x, y) == 0;
        }

        public int GetHashCode(Person obj)
        {
            return obj.GetHashCode();
        }

        //IComparer
        public int Compare(Person x, Person y)
        {
            if (x == null && y != null)
                return 1;

            if (x != null && y == null)
            {
                return -1;
            }

            if (x == null && y == null)
                return 0;
            
            if (x.Age > y.Age)
            {
                return 1;
            }
            if (x.Age < y.Age)
            {
                return -1;
            }
            return 0;
        }
    }
}