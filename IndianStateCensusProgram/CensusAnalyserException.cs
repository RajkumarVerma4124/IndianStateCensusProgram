using System;

namespace IndianStateCensusProgram
{
    /// <summary>
    /// Created The CensusAnalyserException Class To Create The Custom Exceptions Using Base Class Exception(UC1)
    /// </summary>
    public class CensusAnalyserException : Exception
    {
        //Declaring the the enum variable to access the different enum types
        public ExceptionType exception;

        //Decaring enum constants  
        public enum ExceptionType
        {
            FILE_NOT_FOUND, INVALID_FILE_TYPE, INCORRECT_HEADER,
            NO_SUCH_COUNTRY,
            INCORRECT_DELIMITER
        }

        //Parameterized cotructor which is extending the base construcor to initalize the message
        public CensusAnalyserException(string message, ExceptionType exception) : base(message)
        {
            this.exception = exception;
        }
    }
}
