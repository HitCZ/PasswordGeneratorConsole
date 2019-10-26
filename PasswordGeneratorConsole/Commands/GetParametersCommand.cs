using PasswordGeneratorConsole.Infrastructure.Constants;
using System;
using PasswordGeneratorConsole.Commands.Base_classes;

namespace PasswordGeneratorConsole.Commands
{
    internal class GetParametersCommand : Command
    {
        #region Overriden Members

        public override string CommandInput => CommandConstants.GetParameters;

        public override void Execute(params string[] parameters)
        {
            throw new NotImplementedException();
        }

        #endregion Overriden Members
    }
}
