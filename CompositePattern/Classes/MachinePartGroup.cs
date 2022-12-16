using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern.Classes
{
	public class MachinePartGroup
	{
        public virtual string Name { get; set; } = "Group";
        public string PartName;
        public string PartSerial;
        private Lazy<List<MachinePartGroup>> children = new Lazy<List<MachinePartGroup>>();
        public List<MachinePartGroup> Children => children.Value;

        private void Print(StringBuilder sb, int depth)
        {
            sb.Append(new string('*', depth))
              .Append(string.IsNullOrWhiteSpace(PartName) ? string.Empty : $"** {Name} >  PartName: {PartName} - #Serial: {PartSerial}"   )
              .AppendLine($"{Name}");
            foreach (var child in Children)
                child.Print(sb, depth + 1);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            Print(sb, 0);
            return sb.ToString();
        }

    }
}
