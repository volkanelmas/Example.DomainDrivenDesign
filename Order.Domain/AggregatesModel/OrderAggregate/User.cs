using Order.Domain.SeedWork;

namespace Order.Domain.AggregatesModel.OrderAggregate
{
    public class User : ValueObject
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Email { get; private set; }
        public User(string name, string surname, string email)
        {
            Name = name;
            Surname = surname;
            Email = email;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
            yield return Surname;
            yield return Email;
        }
    }
}
