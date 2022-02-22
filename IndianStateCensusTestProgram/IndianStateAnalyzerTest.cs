using IndianStateCensusProgram;
using IndianStateCensusProgram.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace IndianStateCensusTestProgram
{
    [TestClass]
    public class IndianStateAnalyzerTest
    {
        //AAA Methodlogy
        //Arrange
        //List of file paths for indian state census(UC1)
        string stateCensusFilePath = @"E:\CODING\Coding\React Web Apps\coreAPI\Fellowship\IndianStateCensusProgram\IndianStateCensusProgram\CSVFiles\IndianPopulation.csv";
        string wrongFilePath = @"E:\CODING\Coding\React Web Apps\coreAPI\Fellowship\IndianStateCensusProgram\IndianStateCensusProgram\CSVFiles\IndianPopulations.csv";
        string wrongTypeFilePath = @"E:\CODING\Coding\React Web Apps\coreAPI\Fellowship\IndianStateCensusProgram\IndianStateCensusProgram\CSVFiles\IndianPopulation.txt";
        string wrongDelimiterFilePath = @"E:\CODING\Coding\React Web Apps\coreAPI\Fellowship\IndianStateCensusProgram\IndianStateCensusProgram\CSVFiles\DelimiterIndiaStateCensusData.csv";
        string wrongHeaderFilePath = @"E:\CODING\Coding\React Web Apps\coreAPI\Fellowship\IndianStateCensusProgram\IndianStateCensusProgram\CSVFiles\WrongIndiaStateCensusData.csv";
        string stateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        //List of file paths for indian state code(UC2)
        string stateCodeFilePath = @"E:\CODING\Coding\React Web Apps\coreAPI\Fellowship\IndianStateCensusProgram\IndianStateCensusProgram\CSVFiles\IndiaStateCode.csv";
        string wrongSCodeFilePath = @"E:\CODING\Coding\React Web Apps\coreAPI\Fellowship\IndianStateCensusProgram\IndianStateCensusProgram\CSVFiles\IndiaStateCodes.csv";
        string wrongSCodeTypeFilePath = @"E:\CODING\Coding\React Web Apps\coreAPI\Fellowship\IndianStateCensusProgram\IndianStateCensusProgram\CSVFiles\IndiaStateCode.txt";
        string wrongSCodeDelimiterFilePath = @"E:\CODING\Coding\React Web Apps\coreAPI\Fellowship\IndianStateCensusProgram\IndianStateCensusProgram\CSVFiles\DelimiterIndiaStateCode.csv";
        string wrongSCodeHeaderFilePath = @"E:\CODING\Coding\React Web Apps\coreAPI\Fellowship\IndianStateCensusProgram\IndianStateCensusProgram\CSVFiles\WrongIndiaStateCode.csv";
        string stateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        //Object for csv adapter class
        CSVAdapterFactory csvAdapter;
        Dictionary<string, StateDTO> stateCensusRecords;
        Dictionary<string, StateDTO> stateCodeRecords;

        //Initializing the objects
        [TestInitialize]
        public void Setup()
        {
            csvAdapter = new CSVAdapterFactory();
            stateCensusRecords = new Dictionary<string, StateDTO>();
            stateCodeRecords = new Dictionary<string, StateDTO>();
        }

        //Test case for returning the total count from census and state code if path is correct(UC1-TC1.1 && UC2-TC2.1)
        [TestCategory("Indian State Census And Code")]
        [TestMethod]
        public void GivenStateCodeOrCensusCsvReturnRecordsCount()
        {
            stateCensusRecords = csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, stateCensusFilePath, stateCensusHeaders);
            stateCodeRecords = csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, stateCodeFilePath, stateCodeHeaders);
            Assert.AreEqual(29, stateCensusRecords.Count);
            Assert.AreEqual(37, stateCodeRecords.Count);
        }

        //Test case for returning the file not found custom exception if path is incorrect(UC1-TC1.2 && UC2-TC2.2)
        [TestCategory("Indian State Census And Code")]
        [TestMethod]
        public void GivenWrongFileThrowsCustomException()
        {
            var customCensusException = Assert.ThrowsException<CensusAnalyserException>(() => csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongFilePath, stateCensusHeaders));
            var stateCodeException = Assert.ThrowsException<CensusAnalyserException>(() => csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongSCodeFilePath, stateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, customCensusException.exception);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateCodeException.exception);
        }

        //Test case for returning the invalid file type custom exception if file name is same and extension is different(UC1-TC1.3 && UC2-TC2.3)
        [TestCategory("Indian State Census And Code")]
        [TestMethod]
        public void GivenWrongFileTypeThrowsCustomException()
        {
            var customCensusException = Assert.ThrowsException<CensusAnalyserException>(() => csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongTypeFilePath, stateCensusHeaders));
            var stateCodeException = Assert.ThrowsException<CensusAnalyserException>(() => csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongSCodeTypeFilePath, stateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, customCensusException.exception);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, stateCodeException.exception);
        }

        //Test case for returning the incorrect delimeter in data custom exception if path is correct(UC1-TC1.4 && UC2-TC2.4)
        [TestCategory("Indian State Census And Code")]
        [TestMethod]
        public void GivenWrongDelimiterThrowsCustomException()
        {
            var customCensusException = Assert.ThrowsException<CensusAnalyserException>(() => csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongDelimiterFilePath, stateCensusHeaders));
            var stateCodeException = Assert.ThrowsException<CensusAnalyserException>(() => csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongSCodeDelimiterFilePath, stateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, customCensusException.exception);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, stateCodeException.exception);
        }

        //Test case for returning the incorrect header custom exception if path is correct(UC1-TC1.5  && UC2-TC2.5)
        [TestCategory("Indian State Census And Code")]
        [TestMethod]
        public void GivenWrongeHeaderThrowsCustomException()
        {
            var customCensusException = Assert.ThrowsException<CensusAnalyserException>(() => csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongHeaderFilePath, stateCensusHeaders));
            var stateCodeException = Assert.ThrowsException<CensusAnalyserException>(() => csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongSCodeHeaderFilePath, stateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, customCensusException.exception);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, stateCodeException.exception);
        }
    }
}
