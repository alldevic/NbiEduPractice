using System;

namespace DvornikovTask
{
    public class DvornikovTask
    {
        public uint MobilityW { get; private set; }

        public uint CountM { get; private set; }

        public uint CountN { get; private set; }

        public uint ComplexityTau { get; private set; }


        public DvornikovTask(uint mobilityW, uint countM, uint countN, uint complexityTau)
        {
            CheckArgs(mobilityW, countM, countN, complexityTau);
            MobilityW = mobilityW;
            CountM = countM;
            CountN = countN;
            ComplexityTau = complexityTau;
        }

        public static void CheckArgs(uint mobilityW, uint countM, uint countN, uint complexityTau)
        {
            throw new NotImplementedException();
        }

        public DvornikovSolution Solve()
        {
            throw new NotImplementedException();
        }
    }
}