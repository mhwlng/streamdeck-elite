using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When Written: when a screen snapshot is saved
    //Parameters: 
    //�	Filename: filename of screenshot
    //�	Width: size in pixels
    //�	Height: size in pixels
    //�	System: current star system
    //�	Body: name of nearest body
    //�	Latitude: The latitude and longitude will be included if on a planet or in low-altitude flight
    //�	Longitude
    public class ScreenshotEvent : JournalEvent<ScreenshotEvent.ScreenshotEventArgs>
    {
        public ScreenshotEvent() : base("Screenshot") { }

        public class ScreenshotEventArgs : JournalEventArgs
        {
            public string Filename { get; set; }
            public long Width { get; set; }
            public int Height { get; set; }
            public string System { get; set; }
            public string Body { get; set; }
            public double? Latitude { get; set; }
            public double? Longitude { get; set; }
            public double? Altitude { get; set; }
            public int Heading { get; set; }
        }
    }
}
