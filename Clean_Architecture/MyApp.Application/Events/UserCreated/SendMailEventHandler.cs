using MediatR;

namespace MyApp.Application.Events.UserCreated
{
    public class SendMailEventHandler :
        INotificationHandler<UserCreatedEvent>
      {
        public async Task Handle(UserCreatedEvent notification,
            CancellationToken cancellationToken)
        {
            //add the logic..................

           Console.WriteLine("Sending the mail");

        }
    }
}
