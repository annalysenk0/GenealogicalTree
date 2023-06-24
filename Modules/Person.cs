using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenealogicalTree
{
    // Клас визначає структуру об'єкта, що представляє особу.
    // Він має публічні властивості (FirstName, LastName, PatronymicName
    // та Date), які використовуються для зберігання даних про особу.
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PatronymicName { get; set; }
        public string Date { get; set; }

        public Person(string firstName, string lastName, string patronymicName, string date)
        {
            FirstName = firstName;
            LastName = lastName;
            PatronymicName = patronymicName;
            Date = date;
        }
    }
}
