using Tharga.Console.Commands.Base;

namespace Tharga.PowerScan.Console.ConsoleCommands.Connection
{
    internal class ConnectionConsoleCommands : ContainerCommandBase
    {
        public ConnectionConsoleCommands()
            : base("Connection")
        {
            RegisterCommand<ListSerialPortsConsoleCommand>();
            RegisterCommand<OpenConnectionConsoleCommand>();
            RegisterCommand<CloseConnectionConsoleCommand>();
        }
    }
}