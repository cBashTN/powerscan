﻿using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using Tharga.PowerScan.Interfaces;
using Tharga.Console.Commands.Base;

namespace Tharga.PowerScan.Console.ConsoleCommands.Connection
{
    internal class OpenConnectionConsoleCommand : ActionCommandBase
    {
        private readonly IConnection _connection;

        public OpenConnectionConsoleCommand(IConnection connection)
            : base("Open", "Opens a connection.")
        {
            _connection = connection;

            this.RegisterQuery("Port", "Port", () => { return SerialPort.GetPortNames().Select(x => new KeyValuePair<string, string>(x, x)); });
        }

        public override bool CanExecute(out string reasonMessage)
        {
            if (_connection.IsOpen)
            {
                reasonMessage = "Already connected.";
                return false;
            }

            return base.CanExecute(out reasonMessage);
        }

        public override void Invoke(string[] param)
        {
            var portName = GetParam<string>("Port");
            _connection.Open(new Entities.Transport(portName));
        }
    }
}