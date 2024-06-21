using Tharga.Console.Commands.Base;
using Tharga.PowerScan.Interfaces;

namespace Tharga.PowerScan.Console.ConsoleCommands.Configuration
{
    internal class ConfigurationEndConsoleCommand : ActionCommandBase
    {
        private readonly IConnection _connection;

        public ConfigurationEndConsoleCommand(IConnection connection)
            : base("End")
        {
            _connection = connection;
        }

        public override void Invoke(string[] param)
        {
            _connection.Configuration.End();
            OutputInformation("Connection mode ended.");
        }
    }
}