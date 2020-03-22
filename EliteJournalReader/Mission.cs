namespace EliteJournalReader
{
    public struct Mission
    {
        public long MissionID { get; set; }
        public string Name { get; set; }
        public bool PassengerMission { get; set; }
        public int Expires { get; set; }
    }
}