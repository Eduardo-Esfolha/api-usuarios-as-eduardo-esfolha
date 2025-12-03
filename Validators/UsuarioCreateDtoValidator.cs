namespace ApiUser.Validators;

using FluentValidation;
using ApiUser.Application.DTOs;

public class UsuarioCreateDtoValidator : AbstractValidator<UsuarioCreateDto>
{
    public UsuarioCreateDtoValidator()
    {
        // Nome
        RuleFor(x => x.Nome)
            .NotEmpty().WithMessage("O nome é obrigatório.")
            .Length(3, 100).WithMessage("O nome deve ter entre 3 e 100 caracteres.");

        // Email
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("O email é obrigatório.")
            .EmailAddress().WithMessage("O email informado é inválido.");

        // Senha
        RuleFor(x => x.Senha)
            .NotEmpty().WithMessage("A senha é obrigatória.")
            .MinimumLength(6).WithMessage("A senha deve ter no mínimo 6 caracteres.");

        // DataNascimento
        RuleFor(x => x.DataNascimento)
            .NotEmpty().WithMessage("A data de nascimento é obrigatória.");

        // Telefone (opcional)
        RuleFor(x => x.Telefone)
            .Matches(@"^\(?\d{2}\)?\s?\d{4,5}\-?\d{4}$")
            .When(x => !string.IsNullOrWhiteSpace(x.Telefone))
            .WithMessage("O telefone deve estar em um formato brasileiro válido.");
    }
}
