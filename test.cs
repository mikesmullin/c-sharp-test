using System.IO;
using System;
using System.Timers;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
      notMain();
      Console.ReadLine(); // wait for enter
    }

    static async void notMain() {
        Task a = delay(1000, () => Console.WriteLine("a"));
        //interval(1300, () => Console.WriteLine("bye"));
        //Task b = delay(2000, () => Console.WriteLine("b"));

        await a;

        Console.WriteLine("Hello, World!");

        //await b;

        Console.WriteLine("Done.");

    }

    static Task delay(int ms, Action fn) {
        Timer tmr = new Timer(ms);
        Task t = new Task(() => {
          fn();
          tmr.Stop();
        });
        tmr.Elapsed += (sender, args) => { t.Start(); };
        tmr.Start();
        return t;
    }

    static void interval(int ms, Action fn) {
        Timer tmr = new Timer(ms);
        tmr.Elapsed += (sender, args) => fn();
        tmr.Start();
    }
}

