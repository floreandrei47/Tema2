using GenericsExercise.Console.Services;
using GenericsExercise.Console.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GenericsExercise.Console
{
    public class Program
    {
        private static StudentService studentService;
        private static UniversityService universityService;

       // AddStundent

        static async Task AddStudent()
        {
            try
            {
                StudentDTO student = new StudentDTO();

                System.Console.WriteLine("Introdu un ID:");

                student.Id = System.Console.ReadLine();

                System.Console.WriteLine("Introdu prenumele studentului:");

                student.FirstName = System.Console.ReadLine();

                System.Console.WriteLine("Introdu numele studentului:");

                student.LastName = System.Console.ReadLine();

                await studentService.InsertAsync(student);

            }

            catch(ArgumentException)
            {
                System.Console.WriteLine("ID invalid");
            }
            catch (InvalidOperationException)
            {

                System.Console.WriteLine("Cannot insert more than 3 entities of the same type");
            }  

        }
        // Add University
         static async Task AddUniversity()
         {
             try
             {
                 UniversityDTO university = new UniversityDTO();

                 System.Console.WriteLine("Introdu un ID:");

                 university.Id = System.Console.ReadLine();

                 System.Console.WriteLine("Introdu numele universitatii:");

                 university.Name = System.Console.ReadLine();

                 System.Console.WriteLine("Introdu adresa universitatii:");

                 university.Address = System.Console.ReadLine();

                 await universityService.InsertAsync(university);

             }

             catch (ArgumentException)
             {
                 System.Console.WriteLine("ID invalid");
             }
             catch (InvalidOperationException)
             {

                 System.Console.WriteLine("Cannot insert more than 3 entities of the same type");
             }

         }

        // Print students
        static async Task PrintStudents()
        {
            try
            {
                var students = await studentService.GetAllAsync();
                foreach (var student in students)
                {
                    System.Console.WriteLine($"{student.Id}  {student.FirstName}  {student.LastName}");
                }
            }
            catch (InvalidOperationException)
            {
                System.Console.WriteLine("No entities of this type stored");

            }

        }

        // Print Univesties
        static async Task PrintUniversities()
        {
            try
            {

                var universities = await universityService.GetAllAsync();
                foreach (var university in universities)
                {
                    System.Console.WriteLine($"{university.Id}  {university.Name}  {university.Address}");
                }


            }
            catch(InvalidOperationException)
            {
                System.Console.WriteLine("No entities of this type stored");

            }

        }


        static async Task Main(string[] args)
        {
            studentService = new StudentService();

            while (true)
            {
                System.Console.WriteLine("Introdu o comanda:");
                System.Console.WriteLine("1. Student nou");
                System.Console.WriteLine("2. Universitate noua");
                System.Console.WriteLine("3. Afiseaza studenti");
                System.Console.WriteLine("4. Afiseaza universitati");

                var input= System.Console.ReadLine();

                switch (input)
                {
                    case "1":
                      await  AddStudent();
                        break;
                    case "2":
                        await AddUniversity();
                        break;
                    case "3":
                       await PrintStudents();
                        break;
                    case "4":
                        await PrintUniversities();
                        break;
                    default : System.Console.WriteLine("Comanda invalida");
                        break;
                }

            }


        }
    }
}