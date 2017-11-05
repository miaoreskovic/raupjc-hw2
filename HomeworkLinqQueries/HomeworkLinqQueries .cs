using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using _1_zadatak;

namespace HomeworkLinqQueries
{
    public class University
    {
        public string Name { get; set; }
        public Student[] Students { get; set; }
    }
    public class HomeworkLinqQueries
    {
        public static string[] Linq1(int[] intArray)
        {
            //"Broj x pojavljuje se n puta."
            int counter = 0;
            var groups = intArray.GroupBy(number => number);
            String[] strArray = new string[groups.Count()];
            foreach (var group in groups)
                strArray[counter] = "Broj { " + group.Key + " } pojavljuje se { " + group.Count() + " } puta";
                counter++;
            return strArray;
        }
        public static University[] Linq2_1(University[] universityArray)
        {
            //Napišite jedan LINQ izraz koji će vam vratiti sveučilišta na kojima studiraju samo muškarci.
            Gender gender = new Gender();
            gender = Gender.Male;
            University[] onlyMaleUniversitys = new University[];
            onlyMaleUniversitys = universityArray.SelectMany(x => x.Students.Where(y => y.Gender.Equals(gender))).ToArray();
            //onlyMaleUniversitys = universityArray.Where(y => y.Students.Gender.Equals(gender))).ToArray();
            return onlyMaleUniversitys;
        }
        public static University[] Linq2_2(University[] universityArray)
        {
            throw new NotImplementedException();
        }
        public static Student[] Linq2_3(University[] universityArray)
        {
            throw new NotImplementedException();
        }
        public static Student[] Linq2_4(University[] universityArray)
        {
            throw new NotImplementedException();
        }
        public static Student[] Linq2_5(University[] universityArray)
        {
            throw new NotImplementedException();
        }
    }
}
