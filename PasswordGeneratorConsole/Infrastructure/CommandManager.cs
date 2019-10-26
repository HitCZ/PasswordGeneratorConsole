using PasswordGeneratorConsole.Commands.Base_classes;
using PasswordGeneratorConsole.Exceptions;
using PasswordGeneratorConsole.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PasswordGeneratorConsole.Infrastructure
{
    public static class CommandManager
    {
        #region Properties

        public static Dictionary<string, Command> AllCommands { get; }

        #endregion Properties

        #region Constructor

        static CommandManager()
        {
            var allCommands = GetInstancesOfAllCommandTypes();
            AllCommands = allCommands.ToDictionary(c => c.CommandInput.ToLower(), c => c);
        }

        #endregion Constructor

        #region Public Methods

        public static Command GetCommand(string commandInput)
        {
            if (AllCommands.IsNullOrEmpty())
                throw new ArgumentNullException(nameof(AllCommands));
            var valueFound = AllCommands.TryGetValue(commandInput, out var command);

            return valueFound ? command : throw new CommandNotFoundException(commandInput);
        }

        #endregion Public Methods

        #region Private Methods

        private static List<Command> GetInstancesOfAllCommandTypes()
        {
            var allCommandTypes = Assembly.GetAssembly(typeof(Command)).GetTypes()
                                                                       .Where(t => t.IsClass
                                                                                && !t.IsAbstract
                                                                                && t.IsSubclassOf(typeof(Command)));
            var result = new List<Command>();
            result.AddRange(allCommandTypes.Select(
                                                       commandType => (Command) Activator.CreateInstance(commandType)));

            return result;
        }

        #endregion Private Methods
    }
}
