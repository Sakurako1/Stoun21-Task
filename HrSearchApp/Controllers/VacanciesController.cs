using HrSearchApp.Interfaces;
using HrSearchApp.Models;
using HrSearchApp.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrSearchApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacanciesController : ControllerBase
    {
        private readonly IVacancyRepository _vacancyRepository;

        public VacanciesController(IVacancyRepository vacancyRepository)
        {
            _vacancyRepository = vacancyRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Vacancy>))]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetVacancies()
        {
            var vacancies = await _vacancyRepository.GetVacanciesAsync();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(vacancies);
        }



        [HttpPut("{vacancyId}")]
        public async Task<IActionResult> UpdateVacancy(int vacancyId, [FromBody] bool applicant)
        {
            try
            {
                if (applicant)
                {
                    var changeVacancy = await _vacancyRepository.ChangeStateAsync(vacancyId, applicant);

                    if (!changeVacancy)
                    {
                        return StatusCode(500, "Ошибка при изменении состояния вакансии");
                    }

                    return Ok("Вакансия успешно обновлена");
                }

                return BadRequest("Необходимо указать состояние вакансии.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Произошла ошибка при обновлении вакансии.");
            }
        }


        [HttpPut("{vacancyId}/Tasks")]
        public async Task<IActionResult> SendTask(int vacancyId)
        {

            try
            {
                var changeVacancy = await _vacancyRepository.SendTaskAsync(vacancyId);

                if (!changeVacancy)
                {
                    return StatusCode(500, "Ошибка при отправке задания.");
                }

                return Ok("Задание успешно отправлено");
            }
            catch (Exception ex)
            {
              
                return StatusCode(500, "Произошла ошибка при отправке задания.");
            }

        }

        [HttpDelete("{vacancyId}")]
        public async Task<IActionResult> ClosedVacancy(int vacancyId)
        {
            try
            {
                var closedVacancy = await _vacancyRepository.ClosedVacancyAsync(vacancyId);

                if (!closedVacancy)
                {
                    return StatusCode(500, "Ошибка при закрытии вакансии. Возможно, вакансия не найдена или уже закрыта.");
                }

                return Ok("Вакансия успешно закрыта.");
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Произошла ошибка при закрытии вакансии.");
            }

        }

        [HttpPut("{vacancyId}/Internships")]
        public async Task<IActionResult> ClosedInternship(int vacancyId, [FromBody] bool internship)
        {

            try
            {
                var changeVacancy = await _vacancyRepository.CloseInternshipAsync(vacancyId, internship);

                if (!changeVacancy)
                {
                    return StatusCode(500, "Ошибка при закрытии стажировки.");
                }

                return Ok("Стажировка успешно закрыта.");
            }
            catch (Exception ex)
            {
              
                return StatusCode(500, "Произошла ошибка при закрытии стажировки.");
            }

        }

    }
}
