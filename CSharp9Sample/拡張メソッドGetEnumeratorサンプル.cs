// [C#9] 拡張メソッド GetEnumerator

using System;
using System.Collections.Generic;

namespace CSharp9Sample
{
    static class 拡張メソッドGetEnumeratorサンプル
    {
        public static void Test()
        {
            Console.WriteLine($"\n******** {nameof(拡張メソッドGetEnumeratorサンプル)} ********");

            StaffList staffList = new();

            foreach (var staff in staffList)
                Console.WriteLine($"Id: {staff.Id}, Name: {staff.Name}");
        }
    }

    static class StaffListExtensions
    {
        public static IEnumerator<Staff> GetEnumerator(this StaffList @this)
        {
            for (var index = 0; index < @this.Count; index++)
                yield return @this[index];
        }
    }

    class Staff
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    class StaffList
    {
        Staff[] staffs = new[] {
            new Staff { Id = 1, Name = "William Henry Gates III" },
            new Staff { Id = 2, Name = "Steven Anthony Ballmer" },
            new Staff { Id = 3, Name = "Satya Narayana Nadella" },
        };

        public int Count => staffs.Length;

        public Staff this[int index]
        {
            get => staffs[index];
            set => staffs[index] = value;
        }
    }
}
