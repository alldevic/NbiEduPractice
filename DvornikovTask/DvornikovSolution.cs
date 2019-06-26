using System.Collections.Generic;
using System.Linq;

namespace DvornikovTask
{
    public class DvornikovSolution
    {
        private readonly DvornikovSystem _system;

        public uint SystemCountN => _system.CountN;
        public uint SystemCountM => _system.CountM;
        public uint SystemComplexityTau => _system.ComplexityTau;
        public uint SystemMobilityW => _system.MobilityW;


        public int SolutionsCount => Solutions.Values.Sum(list => list.Count);

        public Dictionary<SystemSolution, List<SystemSolution>> Solutions { get; }

        public DvornikovSolution(DvornikovSystem system)
        {
            _system = system;
            Solutions = new Dictionary<SystemSolution, List<SystemSolution>>();
        }
    }
}