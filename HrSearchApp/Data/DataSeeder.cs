using HrSearchApp.Models;

namespace HrSearchApp.Data
{
    public class DataSeeder
    {
        public static void SeedDatabase(DataContext db)
        {
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            var hr1 = new Hr { Id = 1, Login = "Ivan", Password = "P@ssw0rd" };
            var hr2 = new Hr { Id = 2, Login = "Peter", Password = "P@ssw0rd" };
            db.Hrs.AddRange(hr1 , hr2);
            db.SaveChanges();

        

            var vac1 = new Vacancy { Id = 1, Name = "Vacancy 1", Description = "Description for Vacancy 1", State = "Открыта", Task = false, Internship = false,  Department = "Отдел 1" , Applicant = false};
            var vac2 = new Vacancy { Id = 2, Name = "Vacancy 2", Description = "Description for Vacancy 2", State = "Открыта", Task = false, Internship = false, Department = "Отдел 2", Applicant = false };
            var vac3 = new Vacancy { Id = 3, Name = "Vacancy 3", Description = "Description for Vacancy 3", State = "Открыта", Task = false, Internship = false,  Department = "Отдел 3" , Applicant = false };
            var vac4 = new Vacancy { Id = 4, Name = "Vacancy 4", Description = "Description for Vacancy 4", State = "Открыта", Task = false, Internship = false, Department = "Отдел 4" , Applicant = false };
            var vac5 = new Vacancy { Id = 5, Name = "Vacancy 5", Description = "Description for Vacancy 5", State = "Открыта", Task = false, Internship = false, Department = "Отдел 5" , Applicant = false };
            var vac6 = new Vacancy { Id = 6, Name = "Vacancy 6", Description = "Description for Vacancy 6", State = "Открыта", Task = false, Internship = false, Department = "Отдел 6" , Applicant = false };
            var vac7 = new Vacancy { Id = 7, Name = "Vacancy 7", Description = "Description for Vacancy 7", State = "Открыта", Task = false, Internship = false, Department = "Отдел 7" , Applicant = false };
            var vac8 = new Vacancy { Id = 8, Name = "Vacancy 8", Description = "Description for Vacancy 8", State = "Открыта", Task = false, Internship = false, Department = "Отдел 8" , Applicant = false };
            var vac9 = new Vacancy { Id = 9, Name = "Vacancy 9", Description = "Description for Vacancy 9", State = "Открыта", Task = false, Internship = false, Department = "Отдел 9" , Applicant = false };
            var vac10 = new Vacancy { Id = 10, Name = "Vacancy 10", Description = "Description for Vacancy 10", State = "Открыта", Task = false, Internship = false, Department = "Отдел 10" , Applicant = false };
            var vac11 = new Vacancy { Id = 11, Name = "Vacancy 11", Description = "Description for Vacancy 11", State = "Открыта", Task = false, Internship = false, Department = "Отдел 1" , Applicant = false };
            var vac12 = new Vacancy { Id = 12, Name = "Vacancy 12", Description = "Description for Vacancy 12", State = "Открыта", Task = false, Internship = false, Department = "Отдел 2" , Applicant = false };
            var vac13 = new Vacancy { Id = 13, Name = "Vacancy 13", Description = "Description for Vacancy 13", State = "Открыта", Task = false, Internship = false, Department = "Отдел 2" , Applicant = false };
            var vac14 = new Vacancy { Id = 14, Name = "Vacancy 14", Description = "Description for Vacancy 14", State = "Открыта", Task = false, Internship = false, Department = "Отдел 3" , Applicant = false };
            var vac15 = new Vacancy { Id = 15, Name = "Vacancy 15", Description = "Description for Vacancy 15", State = "Открыта", Task = false, Internship = false, Department = "Отдел 4" , Applicant = false };
            var vac16 = new Vacancy { Id = 16, Name = "Vacancy 16", Description = "Description for Vacancy 16", State = "Открыта", Task = false, Internship = false, Department = "Отдел 5" , Applicant = false };
            var vac17 = new Vacancy { Id = 17, Name = "Vacancy 17", Description = "Description for Vacancy 17", State = "Открыта", Task = false, Internship = false, Department = "Отдел 6" , Applicant = false };
            var vac18 = new Vacancy { Id = 18, Name = "Vacancy 18", Description = "Description for Vacancy 18", State = "Открыта", Task = false, Internship = false, Department = "Отдел 7" , Applicant = false };
            var vac19 = new Vacancy { Id = 19, Name = "Vacancy 19", Description = "Description for Vacancy 19", State = "Открыта", Task = false, Internship = false, Department = "Отдел 8" , Applicant = false };
            var vac20 = new Vacancy { Id = 20, Name = "Vacancy 20", Description = "Description for Vacancy 20", State = "Открыта", Task = false, Internship = false,Department= "Отдел 9" , Applicant = false };
            db.Vacancies.AddRange(vac1, vac2, vac3, vac4, vac5, vac6, vac7, vac8, vac9, vac10, vac11, vac12, vac13, vac14, vac15, vac16, vac17, vac18, vac19, vac20);
            db.SaveChanges();

        }
    }
}
