using GenericsExercise.Console.Services.DTOs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GenericsExercise.Console.Services
{
   public class UniversityService
    {
        private readonly Persistence persistence;

        public UniversityService()
        {
            persistence = new Persistence();
        }

        public async Task InsertAsync(UniversityDTO newUniversity)
        {
            University university = new University
            {
                Id = newUniversity.Id,
                Name = newUniversity.Name,
                Address = newUniversity.Address

            };

            await persistence.InsertAsync<University>(university);

        }

        public async Task<IEnumerable<UniversityDTO>> GetAllAsync()
        {
            var universities = await persistence.GetAllAsync<University>();
            var UniversityDTOlist = new List<UniversityDTO>();

            foreach (var university in universities)
            {
                UniversityDTO newUniversity = new UniversityDTO
                {
                    Id = university.Id,
                    Name = university.Name,
                    Address = university.Address

                };
                UniversityDTOlist.Add(newUniversity);
            }
            return UniversityDTOlist;
        }
    }


}
