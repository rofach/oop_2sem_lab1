// Decompiled with JetBrains decompiler
// Type: _2a.Program
// Assembly: 2a, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5A8484FB-CA08-4A26-A850-D518098BA054
// Assembly location: D:\Users\rofach\Downloads\ДелегатиЗавдання1 (2).exe

using System;

#nullable disable
namespace _2a
{
    delegate double DlgFunc(double num);
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Вводьте послідовність виду 0 х, 1 х або 2 х (де х - число)");
            Console.WriteLine("0 -- sqrt(abs(x))");
            Console.WriteLine("1 -- x^3");
            Console.WriteLine("2 -- x + 3,5");
            DlgFunc[] dlgArr = 
            {
            x => Math.Sqrt(Math.Abs(x)),
            x => Math.Pow(x, 3.0),
            x => x + 3.5
            };
            
            while (true)
            {
                try
                {
                    string[] input = Console.ReadLine().Trim().Split();
                    Console.WriteLine(dlgArr[int.Parse(input[0])](double.Parse(input[1])));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Сталася помилка {ex.Message}");
                    Console.WriteLine("Щоб вийти, натисніть будь-яку кнопку");
                    Console.ReadKey();
                    break;
                }
            }
            
        }
    }
}
