using PasswordGenerator.Other;

namespace PasswordGeneratorConsole.Infrastructure
{
    public static class PasswordParametersManager
    {
        #region Properties

        public static PasswordParameters PasswordParameters { get; private set; } = new PasswordParameters();

        #endregion Properties

        #region Public Methods
        
        public static PasswordParameters GetNewPasswordParameters()
        {
            PasswordParameters = new PasswordParameters();
            return PasswordParameters;
        }

        #endregion Public Methods
    }
}
