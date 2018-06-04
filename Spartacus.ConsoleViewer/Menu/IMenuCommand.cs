namespace Spartacus.ConsoleViewer.Menu
{
    public interface IMenuCommand
    {
        string Description { get; }
        void Execute();
    }
}
