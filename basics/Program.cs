using System;

class CalculatorConsoleInfo
{
    public static void DisplayCalculationOptions()
    {
        Console.WriteLine("Wybierz typ liczenia:\n");
        Console.WriteLine("1. Dodawanie\n2. Odejmowanie\n3. Mnożenie\n4. Dzielenie\n5. Wyjście");
    }

    public static void DisplayInvalidInputMessage()
    {
        Console.WriteLine("\n!! Wartość Musi być liczbą !!\n");
        Console.WriteLine("Podaj poprawna wartość:\n");
    }
}

namespace basics
{
    class Calculator
    {
        private static double ReadDoubleInput()
        {
            double parsedData = 0;
    
            while(!double.TryParse(Console.ReadLine(), out parsedData))
            {
                Console.Clear();
                CalculatorConsoleInfo.DisplayInvalidInputMessage();
            }
    
            return parsedData;
        }
    
        private static int ReadIntOptionInput()
        {
            int parsedData = 0;
    
            while (!int.TryParse(Console.ReadLine(), out parsedData))
            {
                Console.Clear();
                CalculatorConsoleInfo.DisplayInvalidInputMessage();
                CalculatorConsoleInfo.DisplayCalculationOptions();
            }
    
            return parsedData;
        }
    
        private static double GetAnotherNumber()
        {
            Console.WriteLine("Podaj kolejna liczbe:");
            return ReadDoubleInput();
        }
    
        private static int SelectOperation()
        {
            CalculatorConsoleInfo.DisplayCalculationOptions();
            return ReadIntOptionInput();
        }
    
        private static double PerformCalculation(int selectedOperation, double firstNumber, double secondNumber = double.NaN)
        {
    
            static Equations setEquation(double firstNumber, double secondNumber)
            {
    
               if (double.IsNaN(secondNumber))
                {
                    secondNumber = GetAnotherNumber();
                }   
                return new Equations(firstNumber, secondNumber);
            };
    
            switch (selectedOperation)
            {
                case 1:
                    {
                        var equations = setEquation(firstNumber, secondNumber);
                        return equations.Add();
                    }
                case 2:
                    {
                        var equations = setEquation(firstNumber, secondNumber);
                        return equations.Sub();
                    }
                case 3:
                    {
                        var equations = setEquation(firstNumber, secondNumber);
                        return equations.Multiply();
                    }
                case 4:
                    {
                        try
                        {
                            var equations = setEquation(firstNumber, secondNumber);
                            return equations.Divide();
                        } 
                        catch (Exception)
                        {
                            Console.WriteLine("Nie możesz dzielić przez zero");
                            return PerformCalculation(selectedOperation, firstNumber, secondNumber);
                        }
                    }
                case 5:
                    {
                        Environment.Exit(0);
                        return 0;
                    }
                default:
                    {
                        Console.Write("\nNiepoprawna opcja\n");
                        selectedOperation = SelectOperation();
                        return PerformCalculation(selectedOperation, firstNumber, secondNumber);
                    }
            }
        }
    
        static void CalculatorLogic(bool firstEquation = true, double oldResult = 0)
        {
            double firstNumber = oldResult;
            double result = 0;
    
            if (firstEquation)
            {
                Console.WriteLine("Podaj pierwsza liczbe\n");
    
                firstNumber = ReadDoubleInput();
            }
    
            var selectedOperation = SelectOperation();
    
            result = PerformCalculation(selectedOperation, firstNumber);
    
            Console.Clear();
            Console.WriteLine("Wynik:" + result);
    
            CalculatorLogic(firstEquation: false, oldResult: result);
        }
        static void Main()
        {
            CalculatorLogic();
        }
    }
}