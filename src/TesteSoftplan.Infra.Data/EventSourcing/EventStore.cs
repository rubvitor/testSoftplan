using Equinox.Infra.Data.Repository.EventSourcing;
using NetDevPack.Identity.User;
using NetDevPack.Messaging;
using Newtonsoft.Json;
using TesteSoftplan.Domain.Core.Events;

namespace Equinox.Infra.Data.EventSourcing
{
    public class EventStore : IEventStore
    {
        private readonly IAspNetUser _user;
        private readonly IEventStoreRepository _eventStoreRepository;
        public EventStore(IEventStoreRepository eventStoreRepository, IAspNetUser user)
        {
            _eventStoreRepository = eventStoreRepository;
            _user = user;
        }

        public void Save<T>(T theEvent) where T : Event
        {
            // Using Newtonsoft.Json because System.Text.Json
            // is a sad joke and far to be considered "Done"
            var serializedData = JsonConvert.SerializeObject(theEvent);

            var storedEvent = new StoredEvent(
                theEvent,
                serializedData,
                _user.Name ?? _user.GetUserEmail());
        }
    }
}