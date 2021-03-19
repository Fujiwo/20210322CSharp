// [C#9] ソースコード ジェネレーター

using System;
using AutoNotify;

namespace HelloSourceGeneratorSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var id = Sample.Id;
            Console.WriteLine(id);

            PartialClass partialClass = new();
            partialClass.ShowMessage();

            SourceTreeGenerated.SourceTree.Show();

            Point point = new();

            point.PropertyChanged += (point, _) =>
            {
                var p = point as Point;
                Console.WriteLine($"The point has changed: {p?.X}");
            };
            point.X = 100;
            point.X = 200;
            point.X = 300;
        }
    }

    partial class PartialClass
    {
        private partial string GetMessage();

        public void ShowMessage()
        {
            Console.WriteLine(GetMessage());
        }
    }

    partial class Point
    {
        [AutoNotify]
        private int _x;
    }
}
