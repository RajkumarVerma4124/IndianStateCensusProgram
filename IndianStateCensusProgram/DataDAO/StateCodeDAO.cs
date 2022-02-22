using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStateCensusProgram.DataDAO
{
    /// <summary>
    /// Created The Class For Indian State Census Data Access Object(UC2)
    /// </summary>
    public class StateCodeDAO
    {
        //Declaring variables
        public int serialNumber;
        public string stateName;
        public int tinNumber;
        public string stateCode;

        //Declaring parameterized contructor for initializing values
        public StateCodeDAO(string serialNumber, string stateName, string tin, string stateCode)
        {
            this.serialNumber = Convert.ToInt32(serialNumber);
            this.stateName = stateName;
            this.tinNumber = Convert.ToInt32(tin);
            this.stateCode = stateCode;
        }
    }
}
