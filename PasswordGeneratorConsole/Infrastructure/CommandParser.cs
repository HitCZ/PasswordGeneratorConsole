using PasswordGeneratorConsole.Commands;
using PasswordGeneratorConsole.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PasswordGeneratorConsole.Infrastructure
{
    public static class CommandParser
    {
        public static Command ParseCommand(string input, out List<string> parameters)
        {
            if (input.IsNullOrEmpty())
                throw new ArgumentNullException(nameof(input));
            
            var lowerInput = input.ToLower();
            var splitStrings = lowerInput.Split(' ').ToList();
            var parsedCommand = CommandManager.GetCommand(splitStrings.First());
            parameters = splitStrings.Where(s => splitStrings.IndexOf(s) != 0).ToList();

            return parsedCommand;
        }
    }
}
