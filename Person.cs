using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Дерево
{
    public class Module
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PatronymicName { get; set; }

        public string Date { get; set; }
        public List<Module> SubModules { get; set; }

        public Module(string firstName, string lastName, string patronymicName, string date)
        {
            FirstName = firstName;
            LastName = lastName;
            PatronymicName = patronymicName;
            Date = date;
            SubModules = new List<Module>();
        }
    }
}
