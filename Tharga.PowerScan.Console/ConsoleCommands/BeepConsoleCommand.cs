﻿using System.Collections.Generic;
using Tharga.Console.Commands.Base;
using Tharga.PowerScan.Interfaces;
using Tharga.PowerScan.Types;

namespace Tharga.PowerScan.Console.ConsoleCommands
{
    internal class BeepConsoleCommand : ActionCommandBase
    {
        private readonly Beep _beep;
        private readonly IConnection _connection;

        public BeepConsoleCommand(IConnection connection)
            : base("Beep", "Beep the sound on the unit")
        {
            _connection = connection;
            _beep = new Beep(connection);
        }

        public override bool CanExecute(out string reasonMessage)
        {
            var response = _connection.IsOpen;
            reasonMessage = response ? "open" : "not open";
            return response;
        }

        public override void Invoke(string[] param)
        {
            var sound = QueryParam("Beep", param, new Dictionary<BeepSound, string>
            {
                {BeepSound.ShortLowtone, BeepSound.ShortLowtone.ToString()},
                {BeepSound.ShortHightone, BeepSound.ShortHightone.ToString()},
                {BeepSound.LongLowtone, BeepSound.LongLowtone.ToString()},
                {BeepSound.GoodReadtone, BeepSound.GoodReadtone.ToString()},
                {BeepSound.BadReadtone, BeepSound.BadReadtone.ToString()}
            });

            _beep.MakeSound(sound);
        }
    }
}