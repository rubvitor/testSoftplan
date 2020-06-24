using System;
using FluentValidation;

namespace TesteSoftplan.Domain.Commands.Validations
{
    public abstract class JurosValidation<T> : AbstractValidator<T> where T : JurosCommand
    {
    }
}