// [C#9] ラムダ式の改良

using System;
using System.Timers;

namespace CSharp9Sample
{
    class MouseEventArgs { /* 省略 */ }
    delegate void MouseEventHandler(object sender, MouseEventArgs e);

    class Button : IDisposable
    {
        public event MouseEventHandler Click;

        Timer timer = new Timer { Interval = 1000 };

        public Button()
        {
            timer.Elapsed += (_, _) => Click?.Invoke(this, null);
            timer.Start();
        }

        public void Dispose() => timer.Dispose();
    }

    static class ラムダ式サンプル
    {
        public static void Test()
        {
            Console.WriteLine($"\n******** {nameof(ラムダ式サンプル)} ********");

            static void ShowMessage(string message) => Console.WriteLine(message);
            static void ShowOK() => ShowMessage("LambdaSample: OK.");

            using var button = new Button();
            button.Click += (sender, e) => ShowOK();
            button.Click += (_, __) => ShowOK();
            button.Click += (_, _) => ShowOK();

            var message = $"LambdaSample: The {nameof(button)} was clicked.";
            button.Click += (sender, _) => ShowMessage(message);
            //button.Click += static (sender, _) => ShowMessage(message); // NG: message をキャプチャーできない

            Console.ReadKey();
        }
    }
}
