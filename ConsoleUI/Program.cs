using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            UniversityManager um = new UniversityManager();

            um.MaleStudents();
            um.FemaleStudents();
            um.SortStudentsByAge();

            um.AllStudentsFromBeijingTech();

            um.StudentAndUniversityNameCollection();

            /*
            int[] someInts = { 30, 12, 4, 3, 12 };

            IEnumerable<int> sortedInts = from i in someInts orderby i select i;
            IEnumerable<int> reversedInts = sortedInts.Reverse();

            foreach (int i in reversedInts)
            {
                Console.WriteLine(i);
            }


            IEnumerable<int> reversedSortedInts = from i in someInts orderby i descending select i;

            foreach (int i in reversedSortedInts)
            {
                Console.WriteLine(i);
            }
            */

            /*
            Console.WriteLine("Please enter university id to see its students: ");

            string unId  = Console.ReadLine();
            try
            {
                int unIdAsInt = Convert.ToInt32(unId);
                um.AllStudentsFromUnivesityById(unIdAsInt);

            }
            catch (Exception)
            {

                Console.WriteLine("Invalid input");
            }
            */




            Console.ReadKey();

        }
    }

    class UniversityManager
    {
        public List<University> universities;
        public List<Student> students;

        public UniversityManager()
        {
            universities = new List<University>();
            students = new List<Student>();

            universities.Add(new University { Id = 1, Name = "Yale" });
            universities.Add(new University { Id = 2, Name = "Beijing Tech" });

            students.Add(new Student { Id = 1, Name = "Carla", Gender = "female", Age = 17, UniversityId = 1 });
            students.Add(new Student { Id = 2, Name = "Toni", Gender = "male", Age = 21, UniversityId = 1 });
            students.Add(new Student { Id = 3, Name = "Frank", Gender = "male", Age = 22, UniversityId = 2 });
            students.Add(new Student { Id = 4, Name = "Leyla", Gender = "female", Age = 19, UniversityId = 2 });
            students.Add(new Student { Id = 5, Name = "James", Gender = "trans-gender", Age = 25, UniversityId = 2 });
            students.Add(new Student { Id = 6, Name = "Linda", Gender = "female", Age = 22, UniversityId = 2 });
            
        }

        public void MaleStudents()
        {
            IEnumerable<Student> maleStudents = from student in students
                                                where student.Gender == "male"
                                                select student;

            Console.WriteLine("Male - Students: ");

            foreach (var student in maleStudents)
            {
                student.Print();
            }
        }

        public void FemaleStudents()
        {
            IEnumerable<Student> femaleStudents = from student in students
                                                where student.Gender == "female"
                                                select student;

            Console.WriteLine("Female - Students: ");

            foreach (var student in femaleStudents)
            {
                student.Print();
            }
        }

        public void SortStudentsByAge()
        {
            var sortedStudents = from student in students
                                 orderby student.Age
                                 select student;
            Console.WriteLine("Students sorted by Age: ");

            foreach (var student in sortedStudents)
            {
                student.Print();
            }
        }

        public void AllStudentsFromBeijingTech()
        {
            IEnumerable<Student> bjiStudents = from student in students
                                               join university in universities
                                               on student.UniversityId equals university.Id
                                               where university.Name == "Beijing Tech"
                                               select student;

            Console.WriteLine("Students from Beijing Tech: ");

            foreach (var student in bjiStudents)
            {
                student.Print();
            }
        }

        public void AllStudentsFromUnivesityById(int id)
        {
            IEnumerable<Student> studentsFromUniversity = from student in students
                                 join university in universities
                                 on student.UniversityId equals university.Id
                                 where university.Id == id
                                 select student;

            Console.WriteLine($"Students from the university with {id}: ");

            foreach (var student in studentsFromUniversity)
            {
                student.Print();
            }
        }

        public void StudentAndUniversityNameCollection()
        {
            var newCollection = from student in students
                                join university in universities
                                on student.UniversityId equals university.Id
                                orderby student.Name
                                select new
                                {
                                    StudentName = student.Name,
                                    UniversityName = university.Name
                                };

            Console.WriteLine("New Collection: ");

            foreach (var col in newCollection)
            {
                Console.WriteLine($"Student { col.StudentName } from University { col.UniversityName }");
            }
        }
    }
    class University
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Print()
        {
            Console.WriteLine($"University { Name } with id { Id }");
        }
    }

    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }

        // Foreign Key
        public int UniversityId { get; set; }

        public void Print()
        {
            Console.WriteLine($"Student { Name } with Id { Id }, " +
                $"and Age { Age } from university with the Id { UniversityId }");
        }
    }
}
