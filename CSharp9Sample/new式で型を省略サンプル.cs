using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp9Sample
{
    static class new式で型を省略サンプル
    {
        class Staff
        {
            public int Id { get; set; }
            public string Name { get; set; } = "";
        }

        class StaffList
        {
            // フィールド
            List<Staff> staffs = new(); // C#9

            // プロパティ
            public Staff Staff { get; set; }  = new(); // C#9

            void F1()
            {
                // 変数
                Staff staff1 = new(); // C#9
                Staff staff2 = new() { Id = 100, Name = "William Henry Gates III" }; // C#9
            }

            void F2()
            {
                // 引数
                Add(new()); // C#9
            }

            void Add(Staff staff)
            {
            }

        }

        public static void Test()
        {
            Console.WriteLine($"\n******** {nameof(new式で型を省略サンプル)} ********");
        }
    }
}
