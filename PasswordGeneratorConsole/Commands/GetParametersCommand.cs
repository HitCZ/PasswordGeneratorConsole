﻿using PasswordGeneratorConsole.Infrastructure.Constants;
using System;

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
