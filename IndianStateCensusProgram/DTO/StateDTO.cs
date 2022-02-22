using IndianStateCensusProgram.DataDAO;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStateCensusProgram.DTO
{
    /// <summary>
    /// Created The State Data Transfer Object For Different DAO(UC1&UC2) 
    /// </summary>
    public class StateDTO
    {
        //Declaring variables
        public string state;
        public long population;
        public long area;
        public long density;
        public int serialNumber;
        public string stateName;
        public string stateCode;
        public int tinNumber;

        //Declaring parameterized contructor for initializing values
        public StateDTO(StateCensusDAO censusDAO)
        {
            this.state = censusDAO.state;
            this.population = censusDAO.population;
            this.area = censusDAO.area;
            this.density = censusDAO.density;
        }
        public StateDTO(StateCodeDAO stateCodeDAO)
        {
            this.serialNumber = stateCodeDAO.serialNumber;
            this.stateName = stateCodeDAO.stateName;
            this.tinNumber = stateCodeDAO.tinNumber;
            this.stateCode = stateCodeDAO.stateCode;
        }

    }
}
