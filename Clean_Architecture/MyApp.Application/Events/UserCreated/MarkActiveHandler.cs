using MediatR;

namespace MyApp.Application.Events.UserCreated
{
    public class MarkActiveHandler :
        INotificationHandler<UserCreatedEvent>
    {
        public async Task Handle(UserCreatedEvent notification,
            CancellationToken cancellationToken)
        {
            //add the logic..................
            Console.WriteLine("Marking the User as Active");

        }
    }
}


