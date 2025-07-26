using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<(string Name, int Score)> students = new List<(string, int)>();

            Console.WriteLine("=== Student Rank Tracker ===");
            Console.WriteLine("Enter 10 student names and their scores:");

            for (int i = 1; i <= 10; i++)
            {
                Console.Write($"\nEnter name of student #{i}: ");
                string name = Console.ReadLine();

                Console.Write($"Enter score of {name}: ");
                int score;
                while (!int.TryParse(Console.ReadLine(), out score) || score < 0)
                {
                    Console.Write("Invalid input. Please enter a valid positive number: ");
                }

                students.Add((name, score));
            }

            var sortedStudents = students
                .OrderByDescending(s => s.Score)
                .ThenBy(s => s.Name)
                .ToList();

            Console.WriteLine("\n=== Top 3 Students ===");
            for (int rank = 0; rank < 3 && rank < sortedStudents.Count; rank++)
            {
                var student = sortedStudents[rank];
                Console.WriteLine($"Rank {rank + 1}: {student.Name} - Score: {student.Score}");
            }

        }
    }

}
