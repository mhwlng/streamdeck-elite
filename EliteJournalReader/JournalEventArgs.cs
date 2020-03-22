using Newtonsoft.Json.Linq;
using System;
using System.Globalization;

namespace EliteJournalReader
{
    public class JournalEventArgs : EventArgs
    {
        public JObject OriginalEvent { get; set; }

        public DateTime Timestamp { get; set; }

        public JournalEventArgs()
        {
        }

        public virtual void PostProcess(JObject evt) { }

        public virtual JournalEventArgs Clone() => (JournalEventArgs)MemberwiseClone();
    }
}