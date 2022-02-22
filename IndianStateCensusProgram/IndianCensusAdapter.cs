using IndianStateCensusProgram.DataDAO;
using IndianStateCensusProgram.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStateCensusProgram
{
    /// <summary>
    /// Created The IndianCensusAdapter To Read The Csv File And Add Into The Dictionary(UC1) 
    /// </summary>
    public class IndianCensusAdapter : CensusAdapter
    {
        //Declaring string array and dictionary
        string[] censusData;
        Dictionary<string, StateDTO> censusState;

        //Method to return the dictionary of state census by reading the given csv file(UC1) 
        public Dictionary<string, StateDTO> LoadCensusData(string csvFilePath, string dataHeaders)
        {
            try
            {
                censusState = new Dictionary<string, StateDTO>();
                //Using the censusdata return by CensusAdapter method which store csv data read from file
                censusData = GetCensusData(csvFilePath, dataHeaders);
                //Condition for adding string array by skipping the first row into the dictionary(UC1) 
                foreach (string data in censusData.Skip(1))
                {
                    if (!data.Contains(","))
                    {
                        throw new CensusAnalyserException("File Containers Wrong Delimiter", CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER);
                    }
                    string[] coloumn = data.Split(',');
                    if (csvFilePath.Contains("IndianPopulation.csv"))
                        censusState.Add(coloumn[0], new StateDTO(new StateCensusDAO(coloumn[0], coloumn[1], coloumn[2], coloumn[3])));
                }
                return censusState;
            }
            catch (CensusAnalyserException ex)
            {
                throw ex;
            }
        }

    }
}
