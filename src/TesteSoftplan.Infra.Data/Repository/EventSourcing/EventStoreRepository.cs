using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Equinox.Infra.Data.Repository.EventSourcing
{
    public class EventStoreRepository : IEventStoreRepository
    {
        public EventStoreRepository()
        {
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}