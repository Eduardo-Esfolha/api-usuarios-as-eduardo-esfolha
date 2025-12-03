namespace ApiUser.Application.DTOs;


public record UsuarioReadDto
{
    public int Id { get; init; }
    public string Nome { get; init; } = default!;
    public string Email { get; init; } = default!;
    public DateTime DataNascimento { get; init; }
    public string? Telefone { get; init; }
    public bool Ativo { get; init; }
    public DateTime DataCriacao { get; init; }
}
