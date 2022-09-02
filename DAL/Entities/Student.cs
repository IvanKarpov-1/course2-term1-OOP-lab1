namespace DAL
{
    public class Student : Person
    {
        public string Course { get; private set; }
        public string StudentId { get; private set; }
        public double Gpa { get; private set; }
        public string Country { get; private set; }
        public string NumberOfScorebook { get; private set; }

        public Student()
        {
        }

        public Student(string course, string studentId, double gpa, string country, string numberOfScorebook,
            string firstName, string lastName) : base(firstName, lastName, new Study())
        {
            Course = course;
            StudentId = studentId;
            Gpa = gpa;
            Country = country;
            NumberOfScorebook = numberOfScorebook;
        }
    }
}