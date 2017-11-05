using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using _1_zadatak;
using _5_zadatak;

namespace Zadatak1_test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("MAin\n");
            //Case1();
            //Case2();
            //Case3();
            //Stopwatch stopwatch = new Stopwatch();
            //stopwatch.Start();
            //LongOperation("A");
            //LongOperation("B");
            //LongOperation("C");
            //LongOperation("D");
            //LongOperation("E");
            //stopwatch.Stop();
            //Console.WriteLine(" Synchronous long operation calls finished {0} sec.",stopwatch.Elapsed.TotalSeconds);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Parallel.Invoke(() => LongOperation("A"),
                            () => LongOperation("B"),
                            () => LongOperation("C"),
                            () => LongOperation("D"),
                            () => LongOperation("E"));
            stopwatch.Stop();
            Console.WriteLine(" Parallel long operation calls finished {0} sec.", stopwatch.Elapsed.TotalSeconds);
            Console.ReadLine();
        }

        private static void Case1()
        {
            var topStudents = new List<Student>()
            {
                new Student("Ivan", jmbag: "001234567"),
                new Student("Luka", jmbag: "3274272"),
                new Student("Ana", jmbag: "9382832")
            };
            foreach (Student topStudent in topStudents)
            {
                Console.WriteLine(topStudent.Name);
                Console.WriteLine(topStudent.Jmbag);

            }
            var ivan = new Student("Ivan", jmbag: "001234567");
            // false
            bool isIvanTopStudent = topStudents.Contains(ivan);
            Console.WriteLine("isIvanTopStudent" + isIvanTopStudent);
        }

        private static void Case2()
        {
            var list = new List<Student>()
            {
                new Student("Ivan", jmbag: "001234567"),
                new Student("Ivan", jmbag: "001234567")
            };

            // 2
            var distinctStudentCount = list.Distinct().Count();
            Console.WriteLine(distinctStudentCount);
        }

        private static void Case3()
        {
            var topStudents = new List<Student>()
            {
                new Student("Ivan", jmbag: "001234567"),
                new Student("Luka", jmbag: "3274272"),
                new Student("Ana", jmbag: "9382832")
            };

            var ivan = new Student("Ivan", jmbag: "001234567");
            // false
            // == operator is a different operation from .Equals()
            // Maybe it isn't such a bad idea to override it as well
            bool isIvanTopStudent = topStudents.Any(s => s == ivan);
            Console.WriteLine(isIvanTopStudent);
        }

        public static void LongOperation(string taskName)
        {
            Thread.Sleep(1000);
            Console.WriteLine("{0} Finished . Executing Thread : {1}", taskName, Thread.CurrentThread.ManagedThreadId);
        }
    }
}
