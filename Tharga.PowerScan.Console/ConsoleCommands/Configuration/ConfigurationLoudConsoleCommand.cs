﻿using Tharga.PowerScan.Interfaces;
using Tharga.Console.Commands.Base;

namespace Tharga.PowerScan.Console.ConsoleCommands.Configuration
{
    internal class ConfigurationLoudConsoleCommand : ActionCommandBase
    {
        private readonly IConnection _connection;

        public ConfigurationLoudConsoleCommand(IConnection connection)
            : base("Loud")
        {
            _connection = connection;
        }

        public override void Invoke(string[] param)
        {
            _connection.Command("$CBPVO03"); //Good Read Beep Volume
            _connection.Command("$CBTAB01"); //Ack Beep
            _connection.Command("$CBPFR02"); //Good Read Beep Frequenzy
            _connection.Command("$CBPPU01"); //Power On Alter
        }
    }
}