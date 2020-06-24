using System;
using NetDevPack.Domain;

namespace TesteSoftplan.Domain.Models
{
    public class Juros : Entity, IAggregateRoot
    {
        public Juros(Guid id, string name, string email, DateTime birthDate)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
        }

        // Empty constructor for EF
        protected Juros() { }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public DateTime BirthDate { get; private set; }
    }
}