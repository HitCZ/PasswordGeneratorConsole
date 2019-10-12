using PasswordGeneratorConsole.Commands;
using PasswordGeneratorConsole.Exceptions;
using PasswordGeneratorConsole.Extensions;
using PasswordGeneratorConsole.Infrastructure;
using PasswordGeneratorConsole.Infrastructure.Constants;
using System;
using System.Collections.Generic;

namespace PasswordGeneratorConsole
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(ConsoleConstants.WELCOME);
            Console.WriteLine(ConsoleConstants.ENTER_COMMAND);

            while (true)
            {
                var input = Console.ReadLine();

                if (input.IsNullOrEmpty())
                    Console.WriteLine(ConsoleConstants.ENTER_COMMAND);
                else
                {
                    if (!TryParseCommand(input, out var parsedCommand, out var parsedParameters))
                        continue;
                    ExecuteCommand(parsedCommand, parsedParameters);
                }
            }
            // ReSharper disable once FunctionNeverReturns
        }

        #region Private Methods
        
        private static void ExecuteCommand(Command parsedCommand, List<string> parsedParameters)
        {
            try
            {
                parsedCommand.Execute(parsedParameters.ToArray());
            }
            catch (InvalidCommandParametersException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static bool TryParseCommand(string input, out Command parsedCommand, out List<string> parsedParameters)
        {
            parsedCommand = null;
            parsedParameters = null;

            try
            {
                parsedCommand = CommandParser.ParseCommand(input, out var parameters);
                parsedParameters = parameters;
                return true;
            }
            catch (CommandNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        #endregion Private Methods
    }
}
