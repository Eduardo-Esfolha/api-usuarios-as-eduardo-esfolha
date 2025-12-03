namespace ApiUser.Application.DTOs;

public  record  UsuarioUpdateDto(

    string  Nome,
    
    int Id,

    string  Email,

    DateTime  DataNascimento,

    string? Telefone,

    bool  Ativo

);