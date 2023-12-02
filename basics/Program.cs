using System;


class CalculatorConsoleInfo
{
    public static void CalcMethodConsoleInfo()
    {
        Console.WriteLine("Wybierz typ liczenia:\n");
        Console.WriteLine("1. Dodawanie\n2. Odejmowanie\n3. Mnożenie\n4. Dzielenie\n5. Wyjście");
    }

    public static void ReadDataErrMsg()
    {
        Console.WriteLine("\nNieprawidłowa liczba\n");
        Console.WriteLine("Podaj poprawna wartość:\n");
    }
}

class Equations
{
    public double number1;
    public double number2;

    public Equations(double firstNumber, double secondNumber)
    {
        number1 = firstNumber;
        number2 = secondNumber;
    }

    public double Add()
    {
        return number1 + number2;
    }

    public double Sub()
    {
        return number1 - number2;
    }

    public double Divide()
    {
        return number1 / number2;
    }

    public double Multiply()
    {
        return number1 * number2;
    }
}

class Calculator
{
    public static double ReadIntData()
    {
        double parsedData = 0;

        try
        {
            parsedData = double.Parse(Console.ReadLine());
        }
        catch (Exception)
        {
            CalculatorConsoleInfo.ReadDataErrMsg();
            return ReadIntData();
        }

        return parsedData;
    }

    public static double GetAnotherNumber()
    {
        Console.WriteLine("Podaj kolejna liczbe:");
        return ReadIntData();
    }

    public static double SetCalcMethod(int pickedOption, double secondNumber, double firstNumber, double result)
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
                    return NewEquations.Divide();
                }
            case 4:
                {
                    secondNumber = GetAnotherNumber();
                    Equations NewEquations = new(firstNumber, secondNumber);
                    return NewEquations.Multiply();
                }
            case 5:
                {
                    Environment.Exit(0);
                    return 0;
                }
            default:
                {
                    Console.Write("\nNiepoprawna opcja\n");
                    CalculatorConsoleInfo.CalcMethodConsoleInfo();
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

        Console.WriteLine("firstnumber: " + firstNumber);

        if (firstEquation)
        {
            Console.WriteLine("Podaj pierwsza liczbe\n");

            firstNumber = ReadIntData();
        }

        CalculatorConsoleInfo.CalcMethodConsoleInfo();
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