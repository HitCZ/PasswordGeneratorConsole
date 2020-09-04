using PasswordGeneratorConsole.Infrastructure.Constants;
using System;
using PasswordGeneratorConsole.Commands.Base_classes;

namespace PasswordGeneratorConsole.Commands
{
    internal class HelpCommand : Command
    {
        private const string MESSAGE = "List of Commands:\n" +
                                       "\t Help - displays help screen.\n" +
                                       "\t Params - displays currently set parameters.\n" +
                                       "\t    Inner parameters:\n" +
                                       "\t\t L - length of the password.\n" +
                                       "\t\t N - specifies how many numbers should be in the password.\n" +
                                       "\t\t S - specifies how many special characters (#,! etc.) should be in the password. \n" +
                                       "\t\t A - specifies how many letters shouls be in the password. Uppercase and lowercase count must be specified. \n" +
                                       "\n\t\t Alphabetical modifiers:\n" +
                                       "\t\t\t Lower - specifies how many lowercase letters should be in the password.\n" +
                                       "\t\t\t Upper - specifies how many uppercase letters should be in the password.\n" +
                                       "\t Clear - clears the console.\n" +
                                       "\t Generate - generates and prints the password into the console.\n" +
                                       "\n Example scenario for generating a password:\n" +
                                       "\t params l 10\n" +
                                       "\t params n 3\n" +
                                       "\t params s 2\n" +
                                       "\t params a lower 3\n" +
                                       "\t params a upper 2\n" +
                                       "\t params (optional, to check if the parameters are set correctly)\n" +
                                       "\t generate\n";

        #region Overriden Members

        public override string CommandInput => CommandConstants.Help;

        public override void Execute(params string[] parameters)
        {
            base.Execute(parameters);
            Console.WriteLine(MESSAGE);
        }

        #endregion Overriden Members
    }
}
