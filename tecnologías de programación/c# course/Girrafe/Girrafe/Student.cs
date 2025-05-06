using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Girrafe
{
    internal class Student
    {
        public string name;
        public string specialty;
        public double averSchore;

        public Student(string aName, string aSpecialty, double anAverSchore)
        {
            name = aName;
            specialty = aSpecialty;
            averSchore = anAverSchore;
        }

        public bool IsGoodStud()
        {
            if (averSchore > 70)
                return true;
            return false;
        }
    }
}
