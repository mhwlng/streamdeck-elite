using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    public class FileheaderEvent : JournalEvent<FileheaderEvent.FileheaderEventArgs>
    {
        public FileheaderEvent() : base("Fileheader") { }

        public class FileheaderEventArgs : JournalEventArgs
        {
            public string GameVersion { get; set; }
            public string Build { get; set; }
            public string Language { get; set; }
            public int Part { get; set; }
        }
    }
}
