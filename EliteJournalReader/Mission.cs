namespace EliteJournalReader
{
    public struct Mission
    {
        public string MissionID { get; set; }
        public string Name { get; set; }
        public bool PassengerMission { get; set; }
        public int Expires { get; set; }
    }
}