namespace HrSearchApp.Models
{
    public class Vacancy
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string State { get; set; }


        public bool Task { get; set; }
        
        public bool Applicant { get; set; }
        public bool Internship { get; set; }

        public string Department { get; set; }
    }
}
