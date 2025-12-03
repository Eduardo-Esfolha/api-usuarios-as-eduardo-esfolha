namespace ApiUser.Validators;

using FluentValidation;
using ApiUser.Application.DTOs;
using ApiUser.Interfaces;

public class UsuarioUpdateDtoValidator : AbstractValidator<UsuarioUpdateDto>
{
    public UsuarioUpdateDtoValidator(IUsuarioService usuarioService)
    {
        // Nome
        RuleFor(x => x.Nome)
            .NotEmpty().WithMessage("O nome é obrigatório.")
            .Length(3, 100).WithMessage("O nome deve ter entre 3 e 100 caracteres.");

        // Email
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("O email é obrigatório.")
            .EmailAddress().WithMessage("O email informado é inválido.")
            .MustAsync(async (dto, email, ct) =>
            {
                // Permite o mesmo email do próprio usuário
                var jaExiste = await usuarioService.EmailJaCadastradoAsync(email, ct);

                if (!jaExiste) return true;

                // Se existe, precisamos verificar se é do mesmo usuário
                var usuario = await usuarioService.ObterAsync(dto.Id, ct);

                if (usuario is null) return false;

                return usuario.Email == email; // Mesmo email do próprio usuário → permitido
            })
            .WithMessage("O email informado já está em uso por outro usuário.");

        // DataNascimento
        var ruleBuilderOptions = RuleFor(x => x.DataNascimento)
            .NotEmpty().WithMessage("A data de nascimento é obrigatória.");
        }
    }
