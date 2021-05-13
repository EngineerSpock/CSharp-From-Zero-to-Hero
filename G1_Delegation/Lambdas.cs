using System;

namespace Delegation
{
    public class Button
    {
        public double Width;
        public double Height;
        
        public void Click()
        {
            
        }
    }
    
    class Lambdas
    {
        static void LinqExample_ParsingCsv()
        {
            //todo

        }

        static void Main(string[] args)
        {
            Events.MainEventsRun();

            Console.WriteLine(Math.Evaluate("1 2 +"));
            Console.WriteLine(Math.Evaluate("2 1 -"));
            Console.WriteLine(Math.Evaluate("2 5 *"));
            Console.WriteLine(Math.Evaluate("6 2 /"));

            Console.WriteLine();

            Console.WriteLine(InterfaceMath.Evaluate("1 2 +"));
            Console.WriteLine(InterfaceMath.Evaluate("2 1 -"));
            Console.WriteLine(InterfaceMath.Evaluate("2 5 *"));
            Console.WriteLine(InterfaceMath.Evaluate("6 2 /"));

            Console.WriteLine();

            Console.WriteLine(AnonMath.Evaluate("1 2 +"));
            Console.WriteLine(AnonMath.Evaluate("2 1 -"));
            Console.WriteLine(AnonMath.Evaluate("2 5 *"));
            Console.WriteLine(AnonMath.Evaluate("6 2 /"));

            Console.WriteLine();

            Console.WriteLine(LambdaMath.Evaluate("1 2 +"));
            Console.WriteLine(LambdaMath.Evaluate("2 1 -"));
            Console.WriteLine(LambdaMath.Evaluate("2 5 *"));
            Console.WriteLine(LambdaMath.Evaluate("6 2 /"));

            Console.ReadLine();
        }

    }

    public class LambdaMath
    {
        private static Func<double, double, double> GetOperation(char oper)
        {
            switch (oper)
            {
                case '+': return (l, r) => l + r;
                case '-': return (l, r) => l - r;
                case '*': return (l, r) => l * r;
                case '/': return (l, r) => l / r;
            }

            throw new NotSupportedException("The supplied operator is not supported");
        }

        public static double Evaluate(string expr)
        {
            var elements = expr.Split(new[] { ' ' }, 3);
            var l = double.Parse(elements[0]);
            var r = double.Parse(elements[1]);
            var op = elements[2][0];

            return GetOperation(op)(l, r);
        }
    }

    public class InterfaceMath
    {

        private static IMathOperation GetOperation(char oper)
        {
            switch (oper)
            {
                case '+': return new AddOperation();
                case '-': return new SubtractOperation();
                case '*': return new MultiplyOperation();
                case '/': return new DivideOperation();
                default:
                    throw new NotSupportedException("Unknown operator");
            }
        }

        public static double Evaluate(string expression)
        {
            var elements = expression.Split(new[] { ' ' }, 3);
            var l = double.Parse(elements[0]);
            var r = double.Parse(elements[1]);
            var op = elements[2].ToCharArray()[0];

            return GetOperation(op).Compute(l, r);
        }
    }

    public class AnonMath
    {
        public delegate double MathOperation(double left, double right);

        private static MathOperation GetOperation(char oper)
        {
            switch (oper)
            {
                case '+': return delegate (double l, double r) { return l + r; };
                case '-': return delegate (double l, double r) { return l - r; };
                case '*': return delegate (double l, double r) { return l * r; };
                case '/': return delegate (double l, double r) { return l / r; };
            }

            throw new NotSupportedException("The supplied operator is not supported");
        }

        public static double Evaluate(string expr)
        {
            var elements = expr.Split(new[] { ' ' }, 3);
            var l = double.Parse(elements[0]);
            var r = double.Parse(elements[1]);
            var op = elements[2].ToCharArray()[0];

            return GetOperation(op)(l, r);
        }
    }

    public class Math
    {
        public delegate double Operation(double left, double right);

        public static double Add(double left, double right)
        {
            return left + right;
        }

        public static double Subtract(double left, double right)
        {
            return left - right;
        }

        public static double Multiply(double left, double right)
        {
            return left * right;
        }

        public static double Divide(double left, double right)
        {
            return left / right;
        }

        public static Operation GetOperation(char operation)
        {
            switch (operation)
            {
                case '+':
                    return Add;
                case '-':
                    return Subtract;
                case '*':
                    return Multiply;
                case '/':
                    return Divide;
                default:
                    throw new NotSupportedException("Unknown operator");
            }
        }

        public static double Evaluate(string expression)
        {
            string[] parts = expression.Split(new[] { ' ' }, 3);
            double left = double.Parse(parts[0]);
            double right = double.Parse(parts[1]);
            char operation = parts[2].ToCharArray()[0];

            Operation op = GetOperation(operation);
            return op(left, right);
        }
    }

    public interface IMathOperation
    {
        double Compute(double left, double right);
    }

    public class AddOperation : IMathOperation
    {
        double IMathOperation.Compute(double l, double r)
        {
            return l + r;
        }
    }

    public class SubtractOperation : IMathOperation
    {
        double IMathOperation.Compute(double l, double r)
        {
            return l - r;
        }
    }

    public class MultiplyOperation : IMathOperation
    {
        double IMathOperation.Compute(double l, double r)
        {
            return l * r;
        }
    }

    public class DivideOperation : IMathOperation
    {
        double IMathOperation.Compute(double l, double r)
        {
            return l / r;
        }
    }

   
}
