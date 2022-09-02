namespace DAL
{
    public class Manager : Employee
    {
        public int CountOfSubordinates { get; private set; }

        public Manager()
        {
        }

        public Manager(int countOfSubordinates, string salary, string firstName, string lastName) : base(salary,
            firstName, lastName, new Manage())
        {
            CountOfSubordinates = countOfSubordinates;
        }
    }
}