using MediatR;

namespace EchoFlowApi.Features.Auth.Register;

public record RegisterCommand(string Username, string Email, string Password) : IRequest<RegisterResponse>;

