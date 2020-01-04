using PasswordGenerator.Other;
using PasswordGeneratorConsole.Commands.Base_classes;
using PasswordGeneratorConsole.Exceptions;
using PasswordGeneratorConsole.Extensions;
using PasswordGeneratorConsole.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PasswordGeneratorConsole.Commands
{
    public class ParametersCommand : Command
    {
        #region Fields

        private const string LENGTH_PARAM = "l";
        private const string NUMBERS_PARAM = "n";
        private const string ALPHABET_PARAM = "a";
        private const string SPECIAL_CHAR_PARAM = "s";
        private const string LOWER_PARAM = "lower";
        private const string UPPER_PARAM = "upper";
        private readonly List<string> mainParams = new List<string> { LENGTH_PARAM, NUMBERS_PARAM, ALPHABET_PARAM, SPECIAL_CHAR_PARAM };
        private readonly List<string> modifierParams = new List<string> { LOWER_PARAM, UPPER_PARAM };

        #endregion Fields

        #region Constructor

        public ParametersCommand()
            : base(LENGTH_PARAM, NUMBERS_PARAM, ALPHABET_PARAM, SPECIAL_CHAR_PARAM, LOWER_PARAM, UPPER_PARAM)
        {
        }

        #endregion Constructor

        #region Command Members

        public override string CommandInput { get; } = "params";

        public override void Execute(params string[] parameters)
        {
            base.Execute(parameters);

            if (parameters.IsNullOrEmpty())
                Console.WriteLine(PasswordParametersManager.PasswordParameters.GetParametersSummary());
            else
                ProcessParameters(parameters);
        }

        #endregion Command Members

        #region Private Methods

        private void ProcessParameters(string[] parameters)
        {
            var firstParam = parameters.FirstOrDefault();
            var pwParameters = PasswordParametersManager.PasswordParameters;

            if (!mainParams.Contains(firstParam))
                throw new InvalidSequenceOfParametersException();

            if (parameters.Length == 1)
                HandleSingleParameter(pwParameters, firstParam);
            else if (parameters.Length > 1)
                HandleParameterWithModifiers(pwParameters, parameters);
        }

        private void HandleSingleParameter(PasswordParameters pwParameters, string parameter)
        {
            switch (parameter)
            {
                case LENGTH_PARAM:
                    Console.WriteLine(pwParameters.GetLengthSummary());
                    break;
                case ALPHABET_PARAM:
                    Console.WriteLine(pwParameters.GetAlphabetSummary());
                    break;
                case NUMBERS_PARAM:
                    Console.WriteLine(pwParameters.GetNumbersSummary());
                    break;
                case SPECIAL_CHAR_PARAM:
                    Console.WriteLine(pwParameters.GetSpecialCharsSummary());
                    break;
            }
        }

        private void HandleParameterWithModifiers(PasswordParameters pwParameters, string[] parameters)
        {
            if (pwParameters is null || parameters.IsNullOrEmpty() 
                                     || parameters.Length <= 1 
                                     || parameters.Any(p => p.IsNullOrEmpty()))
                return;

            var firstParam = parameters.First();
            var modifiers = parameters.Skip(1).ToArray();

            if (modifiers.Any(m => !m.IsNumber() && !modifierParams.Contains(m)))
                throw new InvalidCommandParametersException(modifiers);

            switch (firstParam)
            {
                case LENGTH_PARAM:
                    ProcessLengthParameter(pwParameters, modifiers);
                    break;
                case ALPHABET_PARAM:
                    ProcessAlphabetParameter(pwParameters, modifiers);
                    break;
                case NUMBERS_PARAM:
                    ProcessNumbersParameter(pwParameters, modifiers);
                    break;
                case SPECIAL_CHAR_PARAM:
                    ProcessSpecialCharsParameter(pwParameters, modifiers);
                    break;
            }
        }

        private int ConvertFirstModifierToInt(string[] modifiers)
        {
            if (modifiers.Length != 1)
                throw new InvalidSequenceOfParametersException();

            var firstModifier = modifiers.First();

            if (!firstModifier.IsNumber())
                throw new InvalidSequenceOfParametersException();

            var result = int.Parse(firstModifier);
            return result;
        }

        private void ProcessLengthParameter(PasswordParameters pwParameters, string[] modifiers)
        {
            var numericalModifier = ConvertFirstModifierToInt(modifiers);
            pwParameters.PasswordLength = numericalModifier;
        }

        private void ProcessSpecialCharsParameter(PasswordParameters pwParameters, string[] modifiers)
        {
            var numericalModifier = ConvertFirstModifierToInt(modifiers);
            pwParameters.ExactSpecialCharactersCount = numericalModifier;
        }

        private void ProcessNumbersParameter(PasswordParameters pwParameters, string[] modifiers)
        {
            var numericalModifier = ConvertFirstModifierToInt(modifiers);
            pwParameters.ExactNumbersCount = numericalModifier;
        }

        private void ProcessSingleAlphabetModifier(PasswordParameters pwParameters, string modifier)
        {
            switch (modifier)
            {
                case LOWER_PARAM:
                    Console.WriteLine(pwParameters.GetAlphabetSummary(true));
                    break;
                case UPPER_PARAM:
                    Console.WriteLine(pwParameters.GetAlphabetSummary(false));
                    break;
            }
        }

        private void ProcessMultipleAlphabetModifiers(PasswordParameters pwParameters, string[] modifiers)
        {
            var firstModifier = modifiers.First();
            var secondModifier = modifiers[1];

            if (!secondModifier.IsNumber())
                throw new InvalidSequenceOfParametersException();

            var numericalModifier = int.Parse(secondModifier);

            switch (firstModifier)
            {
                case LOWER_PARAM:
                    pwParameters.ExactLowerAlphabetCount = numericalModifier;
                    break;
                case UPPER_PARAM:
                    pwParameters.ExactUpperAlphabetCount = numericalModifier;
                    break;
            }
        }

        private void ProcessAlphabetParameter(PasswordParameters pwParameters, string[] modifiers)
        {
            if (modifiers.Length > 2 || modifiers.IsNullOrEmpty())
                throw new InvalidSequenceOfParametersException();

            if (modifiers.Length == 1)
                ProcessSingleAlphabetModifier(pwParameters, modifiers.First());
            else
                ProcessMultipleAlphabetModifiers(pwParameters, modifiers);
        }

        #endregion Private Methods
    }
}