namespace DAL
{
    public abstract class Employee : Person
    {
        public string Salary { get; protected set; }

        protected Employee() { }
        protected Employee(string salary, string firstName, string lastName, ISpecialBehavior specialBehavior) : base(firstName, lastName, specialBehavior)
        {
            Salary = salary;
        }
    }
}
