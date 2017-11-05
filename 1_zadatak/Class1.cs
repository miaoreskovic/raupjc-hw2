using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_zadatak
{
    public class Student : IEquatable<Student>
    {
        public string Name { get; set; }
        public string Jmbag { get; set;  }
        public Gender Gender { get; set; }

        public Student(string name, string jmbag)
        {
            this.Name = name;
            this.Jmbag = jmbag;
        }

        public bool Equals(Student other)
        {
            // Would still want to check for null etc. first.
            return 
                this.Name == other.Name &&
                this.Jmbag == other.Jmbag;
        }

        public override int GetHashCode()
        {
            int hashName = Name == null ? 0 : Name.GetHashCode();
            int hashJmbag = Jmbag == null ? 0 : Jmbag.GetHashCode();

            return hashName ^ hashJmbag;
        }

        public static bool operator ==(Student x, Student y)
        {
            if (Equals(x, null))
            {
                return (Equals(y, null));
            }
            else if (Equals(y, null))
            {
                return false;
            }
            else
            {
                if (x.Name == y.Name && x.Jmbag == y.Jmbag) return true;
            }
            return false;
        }

        public static bool operator !=(Student x, Student y)
        {
            return !(x == y);
        }


    }

    public enum Gender
    {
        Male, Female
    }
}
