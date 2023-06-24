using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenealogicalTree
{
    // Клас відповідає за збереження даних про члена сім'ї,
    // має властивості: персональні дані та список дітей. 
    public class FamilyMember
    {
        public string FullName { get; set; }
        public List<FamilyMember> Children { get; set; } = new List<FamilyMember>();

        public FamilyMember(string fullName)
        {
            FullName = fullName;
            Children = new List<FamilyMember>();
        }
    }
}
