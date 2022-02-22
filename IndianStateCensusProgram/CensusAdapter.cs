using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStateCensusProgram
{
    /// <summary>
    /// Created The Censor Adapter Class To Check The File Name, Extension And Its Header 
    /// To Return The Readed Data From Csv File(UC1)
    /// </summary>
    public class CensusAdapter
    {
        //Method to return string array which contains the data from the csv file(UC1)
        public string[] GetCensusData(string csvFilePath, string dataHeaders)
        {
            try
            {
                //Declaring string array
                string[] censusData;
                //Checking if file exist or not on a given path
                if (!File.Exists(csvFilePath))
                    throw new CensusAnalyserException("File Not Found", CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
                //Checking the correct extension of the path if the file exists
                if (Path.GetExtension(csvFilePath) != ".csv")
                    throw new CensusAnalyserException("Invalid File Type", CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE);
                //using the readAllLines to read the file line by line to store in a array
                censusData = File.ReadAllLines(csvFilePath);
                //Checking the conditions if the file have the correct data header or not
                if (censusData[0] != dataHeaders)
                {
                    throw new CensusAnalyserException("Incorrect Header In Data", CensusAnalyserException.ExceptionType.INCORRECT_HEADER);
                }
                return censusData;
            }
            catch (CensusAnalyserException ex)
            {
                throw ex;
            }
        }
    }
}
