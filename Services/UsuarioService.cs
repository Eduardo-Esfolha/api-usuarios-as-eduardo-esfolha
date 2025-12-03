namespace ApiUser.Services;

using ApiUser.Application.DTOs;
using ApiUser.domain.Entities;
using ApiUser.Interfaces;




public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _repo;

    public UsuarioService(IUsuarioRepository repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<UsuarioReadDto>> ListarAsync(CancellationToken ct)
    {
        var usuarios = await _repo.GetAllAsync(ct);

        return usuarios.Select(u => new UsuarioReadDto
        {
            Id = u.Id,
            Nome = u.Nome,
            Email = u.Email,
            DataCriacao = u.DataCriacao
        });
    }

    public async Task<UsuarioReadDto> ObterAsync(int id, CancellationToken ct)
    {
        var usuario = await _repo.GetByIdAsync(id, ct);
        if (usuario == null)
            return null;

        return new UsuarioReadDto
        {
            Id = usuario.Id,
            Nome = usuario.Nome,
            Email = usuario.Email,
            DataCriacao = usuario.DataCriacao
        };
    }

    public async Task<UsuarioReadDto> CriarAsync(UsuarioCreateDto dto, CancellationToken ct)
    {
        if (await EmailJaCadastradoAsync(dto.Email, ct))
            throw new InvalidOperationException("E-mail já está cadastrado.");

        var usuario = new Usuario
        {
            Nome = dto.Nome,
            Email = dto.Email,
            DataCriacao = DateTime.UtcNow
        };

        await _repo.AddAsync(usuario, ct);

        return new UsuarioReadDto
        {
            Id = usuario.Id,
            Nome = usuario.Nome,
            Email = usuario.Email,
            DataCriacao = usuario.DataCriacao
        };
    }

    public async Task<UsuarioReadDto> AtualizarAsync(int id, UsuarioUpdateDto dto, CancellationToken ct)
    {
        var usuario = await _repo.GetByIdAsync(id, ct);
        if (usuario == null)
            throw new KeyNotFoundException("Usuário não encontrado.");

        // Verificar email duplicado se mudou o email
        if (usuario.Email != dto.Email && await EmailJaCadastradoAsync(dto.Email, ct))
            throw new InvalidOperationException("E-mail já está cadastrado.");

        usuario.Nome = dto.Nome;
        usuario.Email = dto.Email;

        await _repo.UpdateAsync(usuario, ct);

        return new UsuarioReadDto
        {
            Id = usuario.Id,
            Nome = usuario.Nome,
            Email = usuario.Email,
            DataCriacao = usuario.DataCriacao
        };
    }

    public async Task<bool> RemoverAsync(int id, CancellationToken ct)
    {
        var usuario = await _repo.GetByIdAsync(id, ct);
        if (usuario == null)
            return false;

        await _repo.RemoveAsync(usuario, ct);
        return true;
    }

    public async Task<bool> EmailJaCadastradoAsync(string email, CancellationToken ct)
    {
        return await _repo.EmailExistsAsync(email, ct);
    }
}
