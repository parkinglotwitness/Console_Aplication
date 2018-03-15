namespace Wrapper
{
    class Staff
    {
        public string Name { get; set; }
        public uint Num { get; set; }
        public byte Rank { get; set; }

        public Staff(string Name, uint Num, byte Rank)
        {
            this.Name = Name;
            this.Num = Num;
            this.Rank = Rank;
        }

        public Staff()
        {

        }
    }
}
