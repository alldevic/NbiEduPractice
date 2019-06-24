using System.Collections.Generic;

namespace DvornikovTask
{
    public class DvornikovSolution
    {
        public int PairsCount { get; private set; }
        public List<SystemSolution> Solutions { get; set; }

        public DvornikovSolution()
        {
            Solutions = new List<SystemSolution>();
        }
    }
}