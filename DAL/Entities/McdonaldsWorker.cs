namespace DAL
{
    public class McdonaldsWorker : Employee
    {
        public bool Diploma { get; private set; }

        public McdonaldsWorker()
        {
        }

        public McdonaldsWorker(bool diploma, string salary, string firstName, string lastName) : base(salary, firstName,
            lastName, new TakeOrders())
        {
            Diploma = diploma;
        }
    }
}