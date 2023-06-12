using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Дерево
{
    public class FamilyMember
    {
        public string Name { get; set; }
        public List<FamilyMember> Children { get; set; } = new List<FamilyMember>();

        public FamilyMember(string name)
        {
            Name = name;
            Children = new List<FamilyMember>();
        }
    }
}
