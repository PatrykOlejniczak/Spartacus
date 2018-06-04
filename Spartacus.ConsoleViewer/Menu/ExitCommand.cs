using System;

namespace Spartacus.ConsoleViewer.Menu
{
    public class ExitCommand : IMenuCommand
    {
        public string Description => "Exit";

        public void Execute()
        {
            Environment.Exit(0);
        }
    }
}
