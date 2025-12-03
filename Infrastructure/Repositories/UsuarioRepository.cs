using ApiUser.Interfaces;

namespace ApiUser.Infrastructure.Repositories;

using domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;


public class UsuarioRepository : IUsuarioRepository
{
    private readonly AppDbContext _context;
    private IUsuarioRepository _usuarioRepositoryImplementation;

    public UsuarioRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Usuario>> GetAllAsync(CancellationToken ct)
    {
        return await _context.Usuarios.AsNoTracking().ToListAsync(ct);

    }

    public async Task<Usuario?> GetByIdAsync(int id, CancellationToken ct)
    {
        return await _context.Usuarios.FindAsync(new object[] { id }, ct);

    }

    public async Task<Usuario?> GetByEmailAsync(string email, CancellationToken ct)
    {
        return await _context.Usuarios.FindAsync(new object[] { email }, ct);

    }

    public async Task AddAsync(Usuario usuario, CancellationToken ct)
    {
        await _context.Usuarios.AddAsync(usuario, ct);

    }

    public Task UpdateAsync(Usuario usuario, CancellationToken ct)
    {
        _context.Usuarios.Update(usuario);
        return Task.CompletedTask;
    }

    public Task RemoveAsync(Usuario usuario, CancellationToken ct)
    {
        _context.Usuarios.Remove(usuario);
        return Task.CompletedTask;
    }

    public async Task<bool> EmailExistsAsync(string email, CancellationToken ct)
    {
        return await _context.Usuarios
            .AnyAsync(u => u.Email == email, ct);
    }

    public async Task<int> SaveChangesAsync(CancellationToken ct)
    {
        await _context.SaveChangesAsync(ct);
        return await _context.SaveChangesAsync();
    }
}
    

    