namespace ConsoleServiceTool.Utils
{
    internal class UserControlFactory : IUserControlFactory
    {
        private static readonly Lazy<UserControlFactory> instance = new(() => new UserControlFactory());
        private readonly Dictionary<Type, Func<UserControl>> controlFactories = [];

        private UserControlFactory() { }

        internal static UserControlFactory Instance => instance.Value;

        public void Register<T>(Func<T> factory) where T : UserControl
        {
            controlFactories[typeof(T)] = () => factory();
        }

        public T Get<T>() where T : UserControl
        {
            if (!controlFactories.ContainsKey(typeof(T)))
                throw new ArgumentException("User control type not registered.");

            return (T)controlFactories[typeof(T)]();
        }

        internal void Register<T>() where T : UserControl, new()
        {
            Register(() => new T());
        }
    }

}
