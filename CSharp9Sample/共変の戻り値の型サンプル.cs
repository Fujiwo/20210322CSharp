// [C#9] 共変の戻り値の型の改良

using System;
using System.Collections.Generic;

namespace CSharp9Sample
{
    static class 共変の戻り値の型サンプル
    {
        class Base
        {
            public virtual IEnumerable<int> GetCollection() { return null; }
        }

        interface IBase
        {
            IEnumerable<int> GetCollection() { return null; }
        }

        class Derived : Base, IBase
        {
            // 共変の戻り値の型が使用可
            public override List<int> GetCollection() { return new List<int>(); } // C#9
        }

        public static void Test()
        {
            Console.WriteLine($"\n******** {nameof(共変の戻り値の型サンプル)} ********");

            static void Show(IEnumerable<int> collection)
            {
                foreach (var element in collection)
                    Console.WriteLine(element);
            }

            IEnumerable<int> list = true ? new List<int>() : new int[0]; // C#9
            Show(list);
        }
    }
}
