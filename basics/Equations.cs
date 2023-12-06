using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basics
{
    internal class Equations
    {

        private double number1;
        private double number2;

        public Equations(double firstNumber, double secondNumber)
        {
            number1 = firstNumber;
            number2 = secondNumber;
        }

        public double Add() => number1 + number2;

        public double Sub() => number1 - number2;

        public double Divide()
        {
            if (number2 == 0)
            {
                throw new Exception("You cannot divide by zero");
            }

            return number1 / number2;
        }

        public double Multiply() => number1 * number2;
    }
    
}
