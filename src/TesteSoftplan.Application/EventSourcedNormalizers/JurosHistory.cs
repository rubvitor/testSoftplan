using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using TesteSoftplan.Domain.Core.Events;

namespace TesteSoftplan.Application.EventSourcedNormalizers
{
    public static class JurosHistory
    {
        public static IList<JurosHistoryData> HistoryData { get; set; }

        public static IList<JurosHistoryData> ToJavaScriptCustomerHistory(IList<StoredEvent> storedEvents)
        {
            return null;
        }

        private static void CustomerHistoryDeserializer(IEnumerable<StoredEvent> storedEvents)
        {
            
            
        }
    }
}