using GenericsExercise.Console.Services.DTOs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GenericsExercise.Console.Services
{
    public class StudentService
    {
        private readonly Persistence persistence;
     
        public StudentService()
        {
            persistence = new Persistence();
        }

        public async Task InsertAsync(StudentDTO newStudent)
        {
            Student student = new Student
            {
                Id = newStudent.Id,
                FirstName = newStudent.FirstName,
                LastName = newStudent.LastName

            };

           await persistence.InsertAsync<Student>(student);
            
        }
        public async Task<IEnumerable<StudentDTO>> GetAllAsync()
        {
            var students = await persistence.GetAllAsync<Student>();
            var studentDTOlist = new List<StudentDTO>();

            foreach (var student in students)
            {
                StudentDTO newStudent = new StudentDTO
                {
                    Id = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName

                };
                studentDTOlist.Add(newStudent);
            }
            return studentDTOlist;
        }
    }
}
