using System.Linq;

namespace DAL
{
    public abstract class Person
    {
        public string LastName { get; protected set; }
        public string FirstName { get; protected set; }
        public ISpecialBehavior[] SpecialBehaviors { get; private set; } = new ISpecialBehavior[] { new PlayChess() };

        protected Person() { }
        protected Person(string firstName, string lastName, ISpecialBehavior specialBehavior)
        {
            FirstName = firstName;
            LastName = lastName;
            SpecialBehaviors = SpecialBehaviors.Append(specialBehavior).ToArray();
        }
    }
}
