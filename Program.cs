using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RetrieveStudentData
{
    class Program
    {
        static List<(string Name, string Class)> students = new List<(string, string)>();

        static void Main(string[] args)
        {
            LoadData();
            SortData();

            Console.WriteLine("Sorted Student List:");
            DisplayStudents();

            Console.WriteLine("\nEnter a student name to search:");
            string searchName = Console.ReadLine();
            var student = SearchStudent(searchName);

            if (student.HasValue)
                Console.WriteLine($"Found: {student.Value.Name}, Class: {student.Value.Class}");
            else
                Console.WriteLine("Student not found.");

            Console.ReadKey();
        }

        static void LoadData()
        {
            string filePath = "C:\\Users\\lenovo\\OneDrive\\Desktop\\Project 3\\studentdata.txt"; // Ensure this path is correct
            using (var reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split(',');
                    if (parts.Length == 2)
                        students.Add((parts[0].Trim(), parts[1].Trim()));
                }
            }
        }

        static void SortData()
        {
            students.Sort((x, y) => x.Name.CompareTo(y.Name));
        }

        static (string Name, string Class)? SearchStudent(string name)
        {
            return students.FirstOrDefault(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        static void DisplayStudents()
        {
            foreach (var student in students)
            {
                Console.WriteLine($"Name: {student.Name}, Class: {student.Class}");
            }
        }
    }
}
