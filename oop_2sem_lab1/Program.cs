
namespace oop_2sem_lab1
{
    delegate void dlgStringOp(string str);
    class Program
    {
        static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            Timer timer = new Timer(t);
            Timer timer2 = new Timer(t);
            dlgStringOp print = Print;

            timer.Start(print, "hello");
            timer2.Start(Print2, "olleh");
            Thread.Sleep(4000);
            timer.Stop();
            timer2.Time = 200;
        }

        static void Print(string str)
        {
            Console.WriteLine(str);
        }

        static void Print2(string str)
        {
            Console.WriteLine("============");
            Console.WriteLine(str);
            Console.WriteLine("============");
        }
    }
}