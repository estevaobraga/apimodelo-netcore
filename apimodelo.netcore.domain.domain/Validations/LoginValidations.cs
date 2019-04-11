using apimodelo.netcore.domain.domain.Interfaces;
using apimodelo.netcore.domain.domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace apimodelo.netcore.domain.domain.Validations
{
    public class LoginValidations : AbstractValidator<Usuario>
    {
        public LoginValidations(IUsuarioRepository usuar)
        {
            RuleFor(x => x.Login)
                .NotEmpty()
                .WithMessage("Informe o login");

            RuleFor(x => x.Senha)
                .NotEmpty()
                .WithMessage("Ïnforme a sua senha");

            RuleFor(x => x)
                .MustAsync(async (u, i) => await usuar.UsuarioExiste(u))
                .WithMessage("Usuario ou Senha incorretos")
                .WithName("Login");
        }
    }
}
