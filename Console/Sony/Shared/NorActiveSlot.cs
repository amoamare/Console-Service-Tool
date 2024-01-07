namespace ConsoleServiceTool.Console.Sony.Shared
{
    internal class NorActiveSlot : INorData
    {
        internal byte[] Data = new byte[0x1000];

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
