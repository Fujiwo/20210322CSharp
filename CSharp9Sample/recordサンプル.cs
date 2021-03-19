// [C#9] record

using System;
using System.Text;

namespace CSharp9Sample
{
    internal class CStaff : IEquatable<CStaff>
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        protected CStaff(CStaff original)
            => (Id, Name) = (original.Id, original.Name);

        public CStaff(int id, string name)
            => (Id, Name) = (id, name);

        public void Deconstruct(out int Id, out string Name)
            => (Id, Name) = (this.Id, this.Name);

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("{ ");
            stringBuilder.Append(nameof(Id));
            stringBuilder.Append(" = ");
            stringBuilder.Append(Id.ToString());
            stringBuilder.Append(", ");
            stringBuilder.Append(nameof(Name));
            stringBuilder.Append(" = ");
            stringBuilder.Append(Name);
            stringBuilder.Append(" }");
            return stringBuilder.ToString();
        }

        public static bool operator ==(CStaff r1, CStaff r2)
            => (object)r1 == r2 || ((object)r1 != null && r1.Equals(r2));

        public static bool operator !=(CStaff r1, CStaff r2)
            => !(r1 == r2);

        public override int GetHashCode()
            => Id.GetHashCode() * -1521134295 + Name.GetHashCode();

        public override bool Equals(object obj)
            => Equals(obj as CStaff);

        public virtual bool Equals(CStaff other)
            => (object)other != null && Id.Equals(other.Id) && Name.Equals(other.Name);

        public virtual CStaff Clone() => new CStaff(Id, Name);
    }

    public record RStaff(int Id, string Name);

    public record RStaff2
    {
        public int Id { get; init; }
        public string Name { get; init; } = "";
    }

    public record RStaff3
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = "";

        public RStaff3(int id, string name) => (Id, Name) = (id, name);
    }

    static class recordサンプル
    {
        public static void Test()
        {
            Console.WriteLine($"\n******** {nameof(recordサンプル)} ********");

            var cstaff1 = new CStaff(id: 100, name: "William Henry Gates III");

            var rstaff1  = new RStaff(Id: 100, Name: "William Henry Gates III");
            //rstaff1.Id   = 101;                   // NG
            //rstaff1.Name = "Mr. " + rstaff1.Name; // NG
            var rstaff2 = rstaff1 with { Id = 101 };
        }
    }
}
