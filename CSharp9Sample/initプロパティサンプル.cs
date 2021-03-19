// [C#9] init-only プロパティ

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp9Sample
{
    static class initプロパティサンプル
    {
        class Point1 // readonly フィールド
        {
            readonly double x = 0.0;
            public double X { get => x; }
            readonly double y = 0.0;
            public double Y { get => y; }

            public Point1() { }
            // コンストラクター内でだけ代入可能
            public Point1(double x, double y) => (this.x, this.y) = (x, y);
        }

        class Point2 // get-only プロパティ (C# 6)
        {
            public double X { get; } = 0.0;
            public double Y { get; } = 0.0;

            public Point2() {}
            // コンストラクター内でだけ代入可能
            public Point2(double x, double y) => (X, Y) = (x, y);
        }

        class Point3 // init-only プロパティ (C# 9)
        {
            public double X { get; init; } = 0.0;
            public double Y { get; init; } = 0.0;

            public Point3() {}
            public Point3(double x, double y) => (X, Y) = (x, y);
        }

        record Point4(double X = 0.0, double Y = 0.0); // record (C# 9)

        class Point5
        {
            public double X { get; init; } = 0.0;
            public double Y { get; init; } = 0.0;

            public double Value { init => X = Y = value; } // OK: 他のプロパティの init から初期化
        }

        public static void Test()
        {
            Console.WriteLine($"\n******** {nameof(initプロパティサンプル)} ********");

            //var point1 = new Point1 { X = 1.0, Y = 2.0 }; // NG: readonly フィールド
            //var point2 = new Point2 { X = 1.0, Y = 2.0 }; // NG: get-only プロパティ (C# 6)
            var point3 = new Point3 { X = 1.0, Y = 2.0 }; // OK: init-only プロパティ (C# 9)

            var point4 = new Point4(X: 1.0, Y: 2.0);
            var point4_2 = point4 with { Y = 3.0 }; // OK: init-only プロパティ (C# 9)
        }
    }
}
