using System;


public class CalculatorConsoleInfo
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

public class Equations
{
    public int number1;
    public int number2;

    public Equations(int firstNumber, int secondNumber)
    {
        number1 = firstNumber;
        number2 = secondNumber;
    }

    public int Add()
    {
        return number1 + number2;
    }

    public int Sub()
    {
        return number1 - number2;
    }

    public int Divide()
    {
        return number1 / number2;
    }

    public int Multiply()
    {
        return number1 * number2;
    }
}

class Calculator
{
    public static int ReadIntData()
    {
        int parsedData = 0;

        try
        {
            parsedData = int.Parse(Console.ReadLine());
        }
        catch (Exception)
        {
            CalculatorConsoleInfo.ReadDataErrMsg();
            return ReadIntData();
        }
        return parsedData;
    }

    public static int GetAnotherNumber(int secondNumber)
    {
        Console.WriteLine("Podaj kolejna liczbe:");
        return ReadIntData();
    }

    public static void SetCalcMethod(int pickedOption, int secondNumber, int firstNumber, int result)
    {
        switch (pickedOption)
        {
            case 1:
                {
                    secondNumber = GetAnotherNumber(secondNumber);
                    Equations NewEquations = new(firstNumber, secondNumber);
                    result = NewEquations.Add();
                    Console.Clear();
                    Console.WriteLine("Wynik:" + result);
                    break;
                }
            case 2:
                {
                    secondNumber = GetAnotherNumber(secondNumber);
                    Equations NewEquations = new(firstNumber, secondNumber);
                    result = NewEquations.Sub();
                    Console.Clear();
                    Console.WriteLine("Wynik:" + result);
                    break;
                }
            case 3:
                {
                    secondNumber = GetAnotherNumber(secondNumber);
                    Equations NewEquations = new(firstNumber, secondNumber);
                    result = NewEquations.Divide();
                    Console.Clear();
                    Console.WriteLine("Wynik:" + result);
                    break;
                }
            case 4:
                {
                    secondNumber = GetAnotherNumber(secondNumber);
                    Equations NewEquations = new(firstNumber, secondNumber);
                    result = NewEquations.Multiply();
                    Console.Clear();
                    Console.WriteLine("Wynik: " + result);
                    break;
                }
            case 5:
                {
                    Environment.Exit(0);
                    break;
                }
            default:
                {
                    Console.Write("\nNiepoprawna opcja\n");
                    CalculatorConsoleInfo.CalcMethodConsoleInfo();
                    pickedOption = ReadIntData();
                    SetCalcMethod(pickedOption, secondNumber, firstNumber, result);
                    break;
                }
        }
    }

    static public void CalculatorLogic(bool firstEquation = true, int oldResult = 0)
    {
        int pickedOption = 0;
        int firstNumber = 0;
        int secondNumber = 0;
        int result = oldResult;

        if (firstEquation)
        {
            Console.WriteLine("Podaj pierwsza liczbe\n");

            firstNumber = ReadIntData();
        }
        else
        {
            firstNumber = result;
        }

        CalculatorConsoleInfo.CalcMethodConsoleInfo();
        pickedOption = ReadIntData();

        SetCalcMethod(pickedOption, secondNumber, firstNumber, result);

        CalculatorLogic(firstEquation: false, oldResult: result);
    }
    static void Main()
    {
        CalculatorLogic();
    }
}