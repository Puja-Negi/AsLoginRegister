using MediatR;

namespace Application.Authentication.Queries
{
    public record CheckPhoneNumberQuery(
        string PhoneNumber) : IRequest<bool>;
}
