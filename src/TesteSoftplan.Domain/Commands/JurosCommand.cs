using System;
using NetDevPack.Messaging;

namespace TesteSoftplan.Domain.Commands
{
    public abstract class JurosCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }

        public string Email { get; protected set; }

        public DateTime BirthDate { get; protected set; }
    }
}