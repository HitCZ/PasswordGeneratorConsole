using PasswordGeneratorConsole.Infrastructure.Constants;
using System;

namespace PasswordGeneratorConsole.Commands
{
    internal class HelpCommand : Command
    {
        #region Overriden Members

        public override string CommandInput => CommandConstants.Help;
        
        public override void Execute(params string[] parameters)
        {
            base.Execute(parameters);
            
        }

        #endregion Overriden Members
    }
}
