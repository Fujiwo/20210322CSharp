using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp9Sample
{
    static class ネイティブサイズ整数サンプル
    {
        public static void Test()
        {
            Console.WriteLine($"\n******** {nameof(ネイティブサイズ整数サンプル)} ********");

            Console.WriteLine($"int  : {typeof(int  ).FullName, -14}, MinValue = {int  .MinValue, 20}, MaxValue = {int  .MaxValue, 20}");
            Console.WriteLine($"nint : {typeof(nint ).FullName, -14}, MinValue = {nint .MinValue, 20}, MaxValue = {nint .MaxValue, 20}");
            Console.WriteLine($"long : {typeof(long ).FullName, -14}, MinValue = {long .MinValue, 20}, MaxValue = {long .MaxValue, 20}");

            Console.WriteLine($"uint : {typeof(uint ).FullName, -14}, MinValue = {uint .MinValue, 20}, MaxValue = {uint .MaxValue, 20}");
            Console.WriteLine($"nuint: {typeof(nuint).FullName, -14}, MinValue = {nuint.MinValue, 20}, MaxValue = {nuint.MaxValue, 20}");
            Console.WriteLine($"ulong: {typeof(ulong).FullName, -14}, MinValue = {ulong.MinValue, 20}, MaxValue = {ulong.MaxValue, 20}");

            /* 32bits (x86)
           int  : System.Int32  , MinValue =          -2147483648, MaxValue =           2147483647
           nint : System.IntPtr , MinValue =          -2147483648, MaxValue =           2147483647
           long : System.Int64  , MinValue = -9223372036854775808, MaxValue =  9223372036854775807
           uint : System.UInt32 , MinValue =                    0, MaxValue =           4294967295
           nuint: System.UIntPtr, MinValue =                    0, MaxValue =           4294967295
           ulong: System.UInt64 , MinValue =                    0, MaxValue = 18446744073709551615
             */

            /* 64bits (x64)
           int  : System.Int32  , MinValue =          -2147483648, MaxValue =           2147483647
           nint : System.IntPtr , MinValue = -9223372036854775808, MaxValue =  9223372036854775807
           long : System.Int64  , MinValue = -9223372036854775808, MaxValue =  9223372036854775807
           uint : System.UInt32 , MinValue =                    0, MaxValue =           4294967295
           nuint: System.UIntPtr, MinValue =                    0, MaxValue = 18446744073709551615
           ulong: System.UInt64 , MinValue =                    0, MaxValue = 18446744073709551615
             */
        }
    }
}
