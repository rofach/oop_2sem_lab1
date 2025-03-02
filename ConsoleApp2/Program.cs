using System;

delegate double dlgGetSeriesEl(int i);
class Program
{
    

    static void Main(string[] args)
    {
        int decimalPlaces = Convert.ToInt32(Console.ReadLine());
        double precision = Math.Pow(10, -decimalPlaces);

        dlgGetSeriesEl dlgSeriesSum1 = GetSeriesEl1;
        dlgGetSeriesEl dlgSeriesSum2 = GetSeriesEl2;
        dlgGetSeriesEl dlgSeriesSum3 = GetSeriesEl3;

        Console.WriteLine(Calculate(dlgSeriesSum1, precision));
        Console.WriteLine(Calculate(dlgSeriesSum2, precision));
        Console.WriteLine(Calculate(dlgSeriesSum3, precision));
    }

    static double Calculate(dlgGetSeriesEl dlg, double precision)
    {
        double sum = 0;
        int i = 1;
        double current;
        do 
        {
            current = dlg(i);
            sum += current;
            i++;
        }
        while (Math.Abs(current) > precision);

        return sum;
    }

    static double GetSeriesEl1(int i)
    {
        return 1.0 / Math.Pow(2, i - 1);
    }

    static double GetSeriesEl2(int i)
    {
        return 1.0 / Factorial(i);
    }

    static double GetSeriesEl3(int i)
    {
        return Math.Pow(-1, i) * 1.0 / Math.Pow(2, i - 1);
    }

    static double Factorial(int num)
    {
        double factorial = 1;
        for (int i = 1; i <= num; i++)
        {
            factorial *= i;
        }
        return factorial;
    }
}
