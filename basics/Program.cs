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
        Console.WriteLine("\nNieprawidłowa liczba\n");
        Console.WriteLine("Podaj poprawna wartość:\n");
    }
}

class Equations
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

    public double Divide() => number1 / number2;

    public double Multiply() => number1 * number2;
}

class Calculator
{
    private static double ReadIntData()
    {
        double parsedData = 0;

        try
        {
            parsedData = double.Parse(Console.ReadLine());
        }
        catch (Exception)
        {
            CalculatorConsoleInfo.DisplayInvalidInputMessage();
            return ReadIntData();
        }

        return parsedData;
    }

    private static double GetAnotherNumber()
    {
        Console.WriteLine("Podaj kolejna liczbe:");
        return ReadIntData();
    }

    private static double SetCalcMethod(int pickedOption, double secondNumber, double firstNumber, double result)
    {
        switch (pickedOption)
        {
            case 1:
                {
                    secondNumber = GetAnotherNumber();
                    Equations NewEquations = new(firstNumber, secondNumber);
                    return NewEquations.Add();
                }
            case 2:
                {
                    secondNumber = GetAnotherNumber();
                    Equations NewEquations = new(firstNumber, secondNumber);
                    return NewEquations.Sub();
                }
            case 3:
                {
                    secondNumber = GetAnotherNumber();
                    Equations NewEquations = new(firstNumber, secondNumber);
                    return NewEquations.Multiply();
                }
            case 4:
                {
                    secondNumber = GetAnotherNumber();
                    Equations NewEquations = new(firstNumber, secondNumber);
                    return NewEquations.Divide();
                }
            case 5:
                {
                    Environment.Exit(0);
                    return 0;
                }
            default:
                {
                    Console.Write("\nNiepoprawna opcja\n");
                    CalculatorConsoleInfo.DisplayCalculationOptions();
                    pickedOption = Convert.ToInt32(ReadIntData());
                    SetCalcMethod(pickedOption, secondNumber, firstNumber, result);
                    return 0;
                }
        }
    }

    static public void CalculatorLogic(bool firstEquation = true, double oldResult = 0)
    {
        double firstNumber = oldResult;
        double secondNumber = 0;
        double result = 0;

        if (firstEquation)
        {
            Console.WriteLine("Podaj pierwsza liczbe\n");

            firstNumber = ReadIntData();
        }

        CalculatorConsoleInfo.DisplayCalculationOptions();
        int pickedOption = Convert.ToInt32(ReadIntData());

        result = SetCalcMethod(pickedOption, secondNumber, firstNumber, result);
        Console.Clear();
        Console.WriteLine("Wynik:" + result);

        CalculatorLogic(firstEquation: false, oldResult: result);
    }
    static void Main()
    {
        CalculatorLogic();
    }
}