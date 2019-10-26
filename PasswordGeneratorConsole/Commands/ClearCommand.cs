using PasswordGeneratorConsole.Infrastructure.Constants;
using System;
using PasswordGeneratorConsole.Commands.Base_classes;

namespace PasswordGeneratorConsole.Commands
{
    internal class ClearCommand : Command
    {
        public override string CommandInput => CommandConstants.Clear;

        public override void Execute(params string[] parameters)
        {
            base.Execute(parameters);
            Console.Clear();
        }
    }
}
