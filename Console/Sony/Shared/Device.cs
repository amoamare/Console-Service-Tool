namespace ConsoleServiceTool.Console.Sony.Shared
{
    internal class Device
    {
        internal string Port { get; }
        internal string? FriendlyName { get; }
        internal string? InstanceId { get; }
        internal string? DeviceLocationPath { get; }
        internal bool IsProductIdSet { get; }
        internal bool IsVenderIdSet { get; }
        internal bool HasProductAndVendorId => IsProductIdSet && IsVenderIdSet;
        internal int ProductId { get; }
        internal int VendorId { get; }
        internal string? DeviceParent { get; }
        internal string? DeviceSerialNumber { get; }

        internal Device(string port, string? friendlyName)
        {
            Port = port;
            FriendlyName = friendlyName;
        }


        internal Device(string port, string friendlyName, string deviceLocationPath) : this(port, friendlyName)
        {
            DeviceLocationPath = deviceLocationPath;
        }

        internal Device(string port, string friendlyName, string instanceId, string deviceLocationPath, string deviceParent) : this(port, friendlyName, deviceLocationPath)
        {
            InstanceId = instanceId;
            DeviceParent = deviceParent;
            var split = DeviceParent.Split('\\');
            if (split != null && split.Length > 0)
                DeviceSerialNumber = split.LastOrDefault();

        }

        public override string? ToString()
        {
            return FriendlyName;
        }
    }
}

