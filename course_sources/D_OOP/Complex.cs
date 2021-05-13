using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    public class Complex
    {
        public Complex()
        {
            Imaginary = 0;
            Real = 0;
        }

        public Complex(double imaginary, double real)
        {
            this.Imaginary = imaginary;
            this.Real = real;
        }

        public Complex Plus(Complex other)
        {
            Complex result = new Complex();
            result.Imaginary = other.Imaginary + Imaginary;
            result.Real = other.Real + Real;
            return result;
        }

        public Complex Minus(Complex other)
        {
            Complex result = new Complex();
            result.Imaginary = other.Imaginary - Imaginary;
            result.Real = other.Real - Real;
            return result;
        }

        // Свойства - это механизм доступа к данным класса.
        public double Imaginary { get; private set; }
        public double Real { get; private set; }
    }
}