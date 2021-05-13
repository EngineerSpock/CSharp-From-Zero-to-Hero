using System;
using System.Collections.Generic;

public class RoleOfIEnumerable
{
    public static void Demo()
    {
        IEnumerable<string> names = new List<string>()
        {
            "John",
            "Bob",
            "Alice"
        };

        IEnumerator<string> enumerator = names.GetEnumerator();
        while (enumerator.MoveNext())
        {
            Console.WriteLine(enumerator.Current);
        }
    }
}