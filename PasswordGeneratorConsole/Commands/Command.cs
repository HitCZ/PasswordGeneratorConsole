using PasswordGeneratorConsole.Extensions;
using System.Collections.ObjectModel;
using System.Linq;

namespace PasswordGeneratorConsole.Commands
{
    internal abstract class Command
    {
        public ReadOnlyCollection<string> Parameters { get; }

        protected Command(params string[] parameters)
        {
            Parameters = new ReadOnlyCollection<string>(parameters);
        }

        public abstract void Execute(params string[] parameters);

        public virtual bool CanExecute(params string[] parameters)
        {
            if (Parameters.IsNullOrEmpty() || parameters.IsNullOrEmpty())
                return false;

            var equal = Parameters.SequenceEqual(parameters.OrderBy(p => p));

            return equal;
        }
    }
}
