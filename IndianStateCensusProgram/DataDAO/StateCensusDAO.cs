using System;

namespace IndianStateCensusProgram.DataDAO
{
    /// <summary>
    /// Created The Class For Indian State Census Data Access Object(UC1)
    /// </summary>
    public class StateCensusDAO
    {
        //Declaring variables
        public string state;
        public long population;
        public long area;
        public long density;

        //Declaring parameterized contructor for initializing values
        public StateCensusDAO(string state, string population, string area, string density)
        {
            this.state = state;
            this.population = Convert.ToUInt32(population);
            this.area = Convert.ToUInt32(area);
            this.density = Convert.ToUInt32(density);
        }
    }
}
