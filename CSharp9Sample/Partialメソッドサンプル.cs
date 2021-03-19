// [C#9] パーシャル メソッドの改良

using System;

namespace CSharp9Sample
{
    static class Partialメソッドサンプル
    {
        public static void Test()
        {
            Console.WriteLine($"\n******** {nameof(Partialメソッドサンプル)} ********");

            PartialClass o = new();
            o.ShowMessage();
        }
    }

    // 手書きのクラス
    partial class PartialClass
    {
        private partial string GetMessage(); // not implemented here.

        public void ShowMessage() => Console.WriteLine(GetMessage());
    }

    // ソースコード ジェネレーターで作成されるクラス
    partial class PartialClass
    {
        private partial string GetMessage() => "Hello source generator!";
    }
}
