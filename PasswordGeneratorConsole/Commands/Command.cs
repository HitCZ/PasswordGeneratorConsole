using PasswordGeneratorConsole.Infrastructure.Comparers;
using System.Collections.ObjectModel;
using System.Linq;
using PasswordGeneratorConsole.Exceptions;

namespace PasswordGeneratorConsole.Commands
{
    public abstract class Command
    {
        public abstract string CommandInput { get; }
        public ReadOnlyCollection<string> Parameters { get; }
        
        protected Command(params string[] parameters)
        {
            Parameters = new ReadOnlyCollection<string>(parameters);
        }

        public virtual void Execute(params string[] parameters)
        {
            if (!CanExecute(parameters))
                throw new InvalidCommandParametersException(parameters);
        }

        public virtual bool CanExecute(params string[] parameters)
        {
            var comparer = new ListStringEqualityComparer(false);
            var equal = comparer.Equals(Parameters.ToList(), parameters.ToList());

            return equal;
        }
    }
}
