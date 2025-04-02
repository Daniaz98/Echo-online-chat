using MediatR;

namespace EchoFlowApi.Features.Auth.Login;

public record LoginCommand(string Username, string Password) : IRequest<LoginResponse>;



