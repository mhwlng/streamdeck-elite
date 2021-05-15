using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When written: when converting a pre-2.4 engineered module
    //This is generated when converting, or previewing a conversion of a legacy module to the new system.
    //Due to the nature of the changes made for 2.5, modules generated in the old system are not compatible with 
    //the new crafting system, so players will be unable to craft with them.However, players will be given the 
    //opportunity to convert their legacy modules to the new format with the caveat that converted modules will 
    //be a recipe level below what they were before the conversion.The EngineerLegacyConvert journal entry is 
    //generated when converting a recipe, or just previewing a conversion, so some of our creative third party 
    //developers out there may be able to make tools to show how a ship loadout compares before and after 
    //converting their modules.The entry itself is the same as the EngineerCraft entry, minus the ingredients 
    //data (since no materials are required to convert), but plus an "IsPreview" bool to indicate whether this 
    //entry has been generated from a conversion, or just a preview. 

    public class EngineerLegacyConvertEvent : JournalEvent<EngineerLegacyConvertEvent.EngineerLegacyConvertEventArgs>
    {
        public EngineerLegacyConvertEvent() : base("EngineerLegacyConvert") { }

        public class EngineerLegacyConvertEventArgs : JournalEventArgs
        {
            public string Engineer { get; set; }
            public string EngineerID { get; set; }
            public string Blueprint { get; set; }
            public string BlueprintID { get; set; }
            public int Level { get; set; }
            public double Quality { get; set; }
            public EngineeringModifiers[] Modifiers { get; set; }
            public bool IsPreview { get; set; }
        }
    }
}
