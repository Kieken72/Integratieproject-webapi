using Leisurebooker.Business.Domain;
using Leisurebooker.DataAccess.EF.Repositories;

namespace Leisurebooker.Business.Services
{
    public class MessageService : Service<Message>
    {
        public MessageService() : base(new MessageRepository()) { }
    }
}