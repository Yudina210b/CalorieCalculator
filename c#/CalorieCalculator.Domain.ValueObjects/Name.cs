using Domain.ValueObjects.Base;
using Domain.ValueObjects.Validators;

namespace Domain.ValueObjects
{
    public sealed class Name : ValueObject<string>
    {
        public Name(string value) : base(new NameValidator(), value) { }
    }
}