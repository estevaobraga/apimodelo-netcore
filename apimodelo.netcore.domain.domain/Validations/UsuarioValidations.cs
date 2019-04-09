using apimodelo.netcore.domain.domain.Models;
using FluentValidation;

namespace apimodelo.netcore.domain.domain.Validations
{
    public class UsuarioValidations : AbstractValidator<Usuario>
    {
        public UsuarioValidations()
        {

            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("Preencha o Nome");

            RuleFor(x => x.Login)
                .NotEmpty()
                .WithMessage("Preencha o login");

            RuleFor(x => x.Senha)
                .NotEmpty()
                .WithMessage("Preencha a senha")
                .Length(4)
                .WithMessage("Senha deve conter no mínimo 4 caracteres");

        }
    }
}
