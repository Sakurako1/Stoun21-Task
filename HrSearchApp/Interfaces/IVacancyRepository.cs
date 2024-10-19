using HrSearchApp.Models;

namespace HrSearchApp.Interfaces
{
    public interface IVacancyRepository
    {
        Task<bool> SendTaskAsync(int vacancyId);
        Task<bool> ChangeStateAsync(int vacancyId, bool applicant);
        Task<bool> CloseInternshipAsync(int vacancyId, bool internship);
        Task<bool> ClosedVacancyAsync(int vacancyId);
        Task<bool> SaveAsync();
        Task<ICollection<Vacancy>> GetVacanciesAsync();
    }
}
