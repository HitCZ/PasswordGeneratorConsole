using PasswordGeneratorConsole.Exceptions;
using PasswordGeneratorConsole.Extensions;
using PasswordGeneratorConsole.Infrastructure.Comparers;
using System.Collections.ObjectModel;
using System.Linq;

namespace PasswordGeneratorConsole.Commands.Base_classes
{
    public abstract class Command
    {
        #region Properties

        public abstract string CommandInput { get; }
        public ReadOnlyCollection<string> Parameters { get; }

        #endregion Properties

        #region Constructor

        protected Command(params string[] parameters)
        {
            Parameters = new ReadOnlyCollection<string>(parameters);
        }

        #endregion Constructor

        #region Public Methods

        public virtual void Execute(params string[] parameters)
        {
            if (!CanExecute(parameters))
                throw new InvalidCommandParametersException(parameters);
        }

        public virtual bool CanExecute(params string[] parameters)
        {
            if (Parameters.IsNullOrEmpty() && !parameters.IsNullOrEmpty())
                return false;
            if (parameters.IsNullOrEmpty())
                return true;

            var comparer = new StringEqualityComparer(false);

            var lastParam = parameters.Last();
            var paramCopy = (string[])parameters.Clone();

            if (lastParam.IsNumber())
                paramCopy = paramCopy.Take(paramCopy.Length - 2).ToArray();

            var result = paramCopy.All(p => Parameters.Contains(p, comparer));
            return result;
        }

        #endregion Public Methods
    }
}