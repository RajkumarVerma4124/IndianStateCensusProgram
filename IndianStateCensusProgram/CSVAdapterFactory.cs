using IndianStateCensusProgram.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStateCensusProgram
{
    /// <summary>
    /// Created The CSVAdapterFactor Class To Return The Csv Census Data Of Given Country(UC1)
    /// </summary>
    public class CSVAdapterFactory
    {
        //Method to return the csv census data from the given file in dictionary format(UC1)
        public Dictionary<string, StateDTO> LoadCsvData(CensusAnalyser.Country country, string csvFilePath, string dataHeaders)
        {
            try
            {
                switch (country)
                {
                    case (CensusAnalyser.Country.INDIA):
                        return new IndianCensusAdapter().LoadCensusData(csvFilePath, dataHeaders);
                    default:
                        throw new CensusAnalyserException("No Such Country", CensusAnalyserException.ExceptionType.NO_SUCH_COUNTRY);
                }
            }
            catch (CensusAnalyserException ex)
            {
                throw ex;
            }
        }
    }
}
