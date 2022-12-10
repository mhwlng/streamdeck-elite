using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using WindowsInput;
using WindowsInput.Native;
using BarRaider.SdTools;
using EliteJournalReader.Events;

namespace Elite.Buttons
{
    public abstract class EliteKeypadBase : KeypadBase
    {

        protected EliteKeypadBase(SDConnection connection, InitialPayload payload) : base(connection, payload)
        {
        }

        public override void Dispose()
        {
        }

        public override void KeyReleased(KeyPayload payload) { }

        public override void OnTick()
        {
            StreamDeckCommon.HandleOnTick(Connection);
        }

        public override void ReceivedGlobalSettings(ReceivedGlobalSettingsPayload payload) { }


    }
}
