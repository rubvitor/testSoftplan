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
            HistoryData = new List<JurosHistoryData>();
            CustomerHistoryDeserializer(storedEvents);

            var sorted = HistoryData.OrderBy(c => c.Timestamp);
            var list = new List<JurosHistoryData>();
            var last = new JurosHistoryData();

            foreach (var change in sorted)
            {
                var jsSlot = new JurosHistoryData
                {
                    Id = change.Id == Guid.Empty.ToString() || change.Id == last.Id
                        ? ""
                        : change.Id,
                    Name = string.IsNullOrWhiteSpace(change.Name) || change.Name == last.Name
                        ? ""
                        : change.Name,
                    Email = string.IsNullOrWhiteSpace(change.Email) || change.Email == last.Email
                        ? ""
                        : change.Email,
                    BirthDate = string.IsNullOrWhiteSpace(change.BirthDate) || change.BirthDate == last.BirthDate
                        ? ""
                        : change.BirthDate.Substring(0,10),
                    Action = string.IsNullOrWhiteSpace(change.Action) ? "" : change.Action,
                    Timestamp = change.Timestamp,
                    Who = change.Who
                };

                list.Add(jsSlot);
                last = change;
            }
            return list;
        }

        private static void CustomerHistoryDeserializer(IEnumerable<StoredEvent> storedEvents)
        {
            foreach (var e in storedEvents)
            {
                var historyData = JsonSerializer.Deserialize<JurosHistoryData>(e.Data);
                historyData.Timestamp = DateTime.Parse(historyData.Timestamp).ToString("yyyy'-'MM'-'dd' - 'HH':'mm':'ss");

                switch (e.MessageType)
                {
                    case "CustomerRegisteredEvent":
                        historyData.Action = "Registered";
                        historyData.Who = e.User;
                        break;
                    case "CustomerUpdatedEvent":
                        historyData.Action = "Updated";
                        historyData.Who = e.User;
                        break;
                    case "CustomerRemovedEvent":
                        historyData.Action = "Removed";
                        historyData.Who = e.User;
                        break;
                    default:
                        historyData.Action = "Unrecognized";
                        historyData.Who = e.User ?? "Anonymous";
                        break;

                }
                HistoryData.Add(historyData);
            }
        }
    }
}