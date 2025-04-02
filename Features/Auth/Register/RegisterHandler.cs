using EchoFlowApi.Data;
using EchoFlowApi.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EchoFlowApi.Features.Auth.Register;

public class RegisterHandler : IRequestHandler<RegisterCommand, RegisterResponse>
{
    private readonly AppDbContext _context;

    public RegisterHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<RegisterResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        if (await _context.Users.AnyAsync(x => x.Username == request.Username, cancellationToken))
            throw new Exception("Usuário já existe!");

        if (await _context.Users.AnyAsync(x => x.Email == request.Email, cancellationToken))
            throw new Exception("Email já cadastrado!");

        var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

        var user = new Users
        {
            Username = request.Username,
            Email = request.Email,
            Password = passwordHash
        };

        _context.Add(user);
        await _context.SaveChangesAsync(cancellationToken);

        return new RegisterResponse(user.Id, user.Username);
    }
}
