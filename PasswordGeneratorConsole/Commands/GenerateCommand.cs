using PasswordGenerator.Providers;
using PasswordGeneratorConsole.Commands.Base_classes;
using PasswordGeneratorConsole.Infrastructure;
using PasswordGeneratorConsole.Infrastructure.Constants;
using System;
using PasswordGenerator.Other.Exceptions;

namespace PasswordGeneratorConsole.Commands
{
    internal class GenerateCommand : Command
    {
        #region Fields

        private readonly PasswordProvider provider;

        #endregion Fields

        #region Constructor

        public GenerateCommand()
        {
            provider = new PasswordProvider();
        }

        #endregion Constructor

        #region Overriden Members

        public override string CommandInput => CommandConstants.Generate;

        public override void Execute(params string[] parameters)
        {
            base.Execute(parameters);

            var pwParameters = PasswordParametersManager.PasswordParameters;
            var password = string.Empty;

            try
            {
                password = provider.GetPassword(pwParameters);
            }
            catch (InvalidPasswordParametersException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine(password);
        }

        public override bool CanExecute(params string[] parameters)
        {
            return base.CanExecute(parameters) && !(PasswordParametersManager.PasswordParameters is null);
        }

        #endregion Overriden Members
    }
}
