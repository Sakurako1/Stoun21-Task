using HrSearchApp.Data;
using HrSearchApp.Interfaces;
using HrSearchApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HrSearchApp.Repository
{
    public class VacancyRepository : IVacancyRepository
    {
        private readonly DataContext _context;

      public  VacancyRepository(DataContext context) 
        {
            _context = context;
        }

        public async Task<bool> ChangeStateAsync(int vacancyId, bool applicant)
        {
            var vacancy = await _context.Vacancies.FirstOrDefaultAsync(v => v.Id == vacancyId);
            if (vacancy == null)
            {
                throw new Exception("Vacancy not found");
            }

            if (applicant)
            {
                vacancy.State = "Стажируется";
                vacancy.Applicant = applicant;
                return await SaveAsync();
            }
            else
            {
                throw new Exception("Applicant not found, Can't change state for vacancy");
            }
        }

        public async Task<ICollection<Vacancy>> GetVacanciesAsync()
        {
            
            return await _context.Vacancies.ToListAsync();
        }

        public async Task<bool> SaveAsync()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0;
        }

        public async Task<bool> SendTaskAsync(int vacancyId)
        {
            var vacancy = await _context.Vacancies.FirstOrDefaultAsync(v => v.Id == vacancyId);
            if (vacancy != null)
            {
                vacancy.Task = true;
                return await SaveAsync();
            }
            else
            {
                throw new Exception("Vacancy not found");
            }
        }

        public async Task<bool> ClosedVacancyAsync(int vacancyId)
        {
            var vacancy = await _context.Vacancies.FirstOrDefaultAsync(v => v.Id == vacancyId);
            if (vacancy != null && vacancy.Internship)
            {
                _context.Remove(vacancy);
                return await SaveAsync();
            }

            return false;
        }

        public async Task<bool> CloseInternshipAsync(int vacancyId, bool internship)
        {
            var vacancy = await _context.Vacancies.FirstOrDefaultAsync(v => v.Id == vacancyId);
            if (vacancy == null)
            {
                throw new Exception("Vacancy not found");
            }

            if (internship)
            {
                vacancy.Internship = true;
                return await SaveAsync();
            }
            else
            {
                throw new Exception("Can't change Internship for vacancy");
            }
        }
    }
}
