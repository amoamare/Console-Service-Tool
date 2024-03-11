namespace ConsoleServiceTool.Utils
{
    internal interface IUserControlFactory
    {
        internal T Get<T>() where T : UserControl;
        internal void Register<T>(Func<T> factory) where T : UserControl;
    }
}
