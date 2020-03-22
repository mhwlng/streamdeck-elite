using Newtonsoft.Json.Linq;
using System;

namespace EliteJournalReader
{
    public class MessageReceivedEventArgs : EventArgs
    {
        public JObject JObject { get; private set; }
        public string EventType { get; private set; }
        public DateTime Timestamp { get; private set; }
        public JournalEventArgs EventArgs { get; private set; }

        public MessageReceivedEventArgs(JournalEventArgs args, string eventType)
        {
            JObject = args.OriginalEvent?.DeepClone() as JObject;
            EventType = eventType;
            Timestamp = args.Timestamp;
            EventArgs = args;
        }
    }
}