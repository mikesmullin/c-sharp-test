using System.IO;
using System;
using System.Timers;

class Program
{
    static void Main()
    {
        delay(1000, () => Console.WriteLine("hi"));
        interval(1300, () => Console.WriteLine("bye"));
        Console.WriteLine("Hello, World!");

        Console.ReadLine(); // wait for enter
    }

    static void delay(int ms, Action fn) {
        Timer tmr = new Timer(ms);
        tmr.Elapsed += (sender, args) => { fn(); tmr.Stop(); };
        tmr.Start();
    }

    static void interval(int ms, Action fn) {
        Timer tmr = new Timer(ms);
        tmr.Elapsed += (sender, args) => fn();
        tmr.Start();
    }
}

