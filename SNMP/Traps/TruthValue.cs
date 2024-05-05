using Lextm.SharpSnmpLib;

namespace BToolbox.SNMP
{
    public static class TruthValue
    {

        public const int VALUE_TRUE = 1;
        public const int VALUE_FALSE = 2;

        public static Integer32 Create(bool value) => new(value ? VALUE_TRUE : VALUE_FALSE);

        public static bool CheckForDo(ISnmpData data, string messageToDoWhat = null)
        {
            messageToDoWhat ??= "do the action";
            void throwInvalidInputException(ErrorCode errorCode)
                => throw new SnmpErrorCodeException(errorCode, $"Value must be a TruthValue ({VALUE_TRUE} or {VALUE_FALSE}) and set to 1 ({VALUE_TRUE}) to {messageToDoWhat}.");
            if (data is not Integer32 intData)
                throwInvalidInputException(ErrorCode.WrongType);
            int value = intData.ToInt32();
            if ((value != VALUE_TRUE) && (value != VALUE_FALSE))
                throwInvalidInputException(ErrorCode.WrongValue);
            return (value == VALUE_TRUE);
        }

    }
}
