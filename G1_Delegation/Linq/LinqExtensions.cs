using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MasterLinq
{
    public static class LinqExtensions
    {
        public static string ConvertTo(this IEnumerable<byte> collection, Encoding encoding)
        {
            return encoding.GetString(collection.ToArray());            
        }

        public static void WriteAllText(this string str, string file)
        {
            File.WriteAllText(file, str);
        }


        public static IEnumerable<T> Filter<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            //var result = new List<T>();
            foreach (var item in collection)
            {
                if (predicate(item))
                {
                    yield return item;
                    //result.Add(item);
                }
            }
            //return result;
        }

        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            if (source == null)
                throw new ArgumentNullException();
            if (action == null)
                throw new ArgumentNullException();

            foreach (var item in source)
            {
                action(item);
            }
        }
    }
}