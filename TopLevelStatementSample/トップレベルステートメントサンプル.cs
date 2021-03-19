// [C#9] トップ レベル ステートメント

using System.Linq;
using static System.Console;

WriteLine("\n******** TopLevelStatementSample ********");

Enumerable.Range(1, 100)
          .Select(i => (i % 3, i % 5) switch {
                     (0, 0) => "FizzBuzz"  ,
                     (0, _) => "Fizz"      ,
                     (_, 0) => "Buzz"      ,
                     _      => i.ToString()
                  })
          .ToList()
          .ForEach(WriteLine);