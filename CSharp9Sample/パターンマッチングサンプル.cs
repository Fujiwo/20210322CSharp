// [C#9] パターンマッチングの追加

using System;
using System.Collections.Generic;

namespace CSharp9Sample
{
    static class パターンマッチングサンプル
    {
        static Random random = new Random();

        static void isやandやorや関係演算子を用いたパターンマッチング()
        {
            Console.WriteLine($"\n-------- {nameof(isやandやorや関係演算子を用いたパターンマッチング)} --------");

            static void ShowIsValid(bool isValid) => Console.WriteLine(isValid ? "有効" : "無効");

            static int GetX() => random.Next(10) - 5; // -5～4

            {
                var x = GetX();
                var isValid = x > 0 && x <= 3; // 1～3 // before C# 9
                ShowIsValid(isValid);
            }
            {
                var x = GetX();
                var isValid = x is > 0 and <= 3; // 1～3 // C# 9
                ShowIsValid(isValid);
            }
            {
                var isValid = GetX() is > 0 and <= 3; // 1～3 // C# 9
                ShowIsValid(isValid);
            }
            {
                var isValid = GetX() is 1 or 2 or 3; // 1～3 // C# 9
                ShowIsValid(isValid);
            }
            {
                var isValid = GetX() is 0 or > 2; // 0, 3～ // C# 9
                Console.WriteLine(isValid);
            }
        }

        static void notを用いたパターンマッチング()
        {
            Console.WriteLine($"\n-------- {nameof(notを用いたパターンマッチング)} --------");

            static bool 正の32ビット符号付整数なら表示(object o)
            {
                if (o is not null and int n and > 0) {
                    Console.WriteLine(n);
                    return true;
                }
                return false;
            }

            正の32ビット符号付整数なら表示(null);
            正の32ビット符号付整数なら表示(0);
            正の32ビット符号付整数なら表示(1);
            正の32ビット符号付整数なら表示("2");
        }

        static void 閏年かどうかを調べるパターンマッチングの例()
        {
            Console.WriteLine($"\n-------- {nameof(閏年かどうかを調べるパターンマッチングの例)} --------");

            static bool IsLeapYear(int year) =>
                (year % 400, year % 100, year % 4) is (0, _, _) or (_, not 0, 0);

            Console.WriteLine(IsLeapYear(DateTime.Now.Year) ? "閏年" : "非閏年");
        }

        static void Switchのパターンマッチングその1() // switch
        {
            Console.WriteLine($"\n-------- {nameof(Switchのパターンマッチングその1)} --------");

            static void Switch文のパターンマッチング(object x)
            {
                string message = "";
                switch (x) {
                    case int and <= 0: message = "0以下の32ビット符号付整数"    ; break;
                    case int and >  0: message = "0より大きい32ビット符号付整数"; break;
                    case string      : message = "文字列"                       ; break;
                    case var other   : message = $"{other.GetType().Name}"      ; break;
                    //default          : message = "不明"                         ; break; // ここには来ない
                }
                Console.WriteLine($"{x} は、{message}です。");
            }

            static void Switch式のパターンマッチング(object x)
            {
                var message = x switch {
                    int and <= 0 => "0以下の32ビット符号付整数"    ,
                    int and >  0 => "0より大きい32ビット符号付整数",
                    string       => "文字列"                       ,
                    var other    => $"{other.GetType().Name}"
                    //, _            => "不明" // 破棄したい場合 (ここには来ない)
                };
                Console.WriteLine($"{x} は、{message}です。");
            }

            Switch文のパターンマッチング(0);
            Switch文のパターンマッチング(1);
            Switch文のパターンマッチング("2");
            Switch文のパターンマッチング(2.0);

            Switch式のパターンマッチング(-100 );
            Switch式のパターンマッチング( 100 );
            Switch式のパターンマッチング("100");
            Switch式のパターンマッチング(2.0);
        }

        public class Point
        {
            public int X { get; init; } = 0;
            public int Y { get; init; } = 0;
            public Point(int x = 0, int y = 0) => (X, Y) = (x, y);
            public void Deconstruct(out int x, out int y) => (x, y) = (X, Y);
            public override string ToString() => $"({X}, {Y})";
        }

        static void Switchのパターンマッチングその2() // touple switch
        {
            Console.WriteLine($"\n-------- {nameof(Switchのパターンマッチングその2)} --------");

            static void Switch文でDeconstructを利用したパターンマッチング(Point point)
            {
                string message = "";
                switch (point) {
                    case (0    , 0    )           : message = "X も y も 0"     ; break;
                    case (0    , var y) when y < 0: message = "X は 0 で Y は負"; break;
                    case (0    , _    )           : message = "X は 0 で Y は正"; break;
                    case (var x, 0    ) when x < 0: message = "X は負で Y は 0" ; break;
                    case (_    , 0    )           : message = "X は正で Y は 0" ; break;
                    default                       : message = "X も y も非 0"   ; break;
                }
                Console.WriteLine($"この座標 {point} は、{message} です。");
            }

            static void Switch式でDeconstructを利用したパターンマッチング(Point point)
            {
                var message = point switch {
                    (0    , 0    )            => "X も y も 0"     ,
                    (0    , var y) when y < 0 => "X は 0 で Y は負",
                    (0    , _    )            => "X は 0 で Y は正",
                    (var x, 0    ) when x < 0 => "X は負で Y は 0" ,
                    (_    , 0    )            => "X は正で Y は 0" ,
                    _                         => "X も y も非 0"
                };
                Console.WriteLine($"この座標 {point} は、{message}です。");
            }

            static void Switch式でプロパティを利用したパターンマッチング(Point point) // プロパティ パターン
            {
                var message = point switch {
                    { X: 0    , Y: 0     }            => "X も y も 0"     ,
                    { X: 0    , Y: var y } when y < 0 => "X は 0 で Y は負",
                    { X: 0    , Y: _     }            => "X は 0 で Y は正",
                    { X: var x, Y: 0     } when x < 0 => "X は負で Y は 0" ,
                    { X: _    , Y: 0     }            => "X は正で Y は 0" ,
                    _                                 => "X も y も非 0"
                };
                Console.WriteLine($"この座標 {point} は、{message}です。");
            }

            var points = new List<Point> {
                new Point(),
                new Point(x: -100),
                new Point(x:  100),
                new Point(y: -200),
                new Point(y:  200),
                new Point(x: 100, y: 200)
            };

            points.ForEach(point => Switch文でDeconstructを利用したパターンマッチング(point));
            points.ForEach(point => Switch式でDeconstructを利用したパターンマッチング(point));
            points.ForEach(point => Switch式でプロパティを利用したパターンマッチング(point));
        }

        public static void Test()
        {
            Console.WriteLine($"\n******** {nameof(パターンマッチングサンプル)} ********");

            isやandやorや関係演算子を用いたパターンマッチング();
            notを用いたパターンマッチング();
            閏年かどうかを調べるパターンマッチングの例();
            Switchのパターンマッチングその1();
            Switchのパターンマッチングその2();
        }
    }
}
