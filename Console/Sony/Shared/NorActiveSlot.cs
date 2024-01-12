namespace ConsoleServiceTool.Console.Sony.Shared
{
    internal class NorActiveSlot : INorData
    {
        private const int Size = 0x1000;
        internal byte[] Data = new byte[Size]; //offset 0x1000 seems to start with 0x80 and be filled with zeros

        internal NorActiveSlot(BinaryReader data)
        {
            data.Read(Data);
        }

        public byte[] ToArray()
        {
            return Data;
        }
    }
}
