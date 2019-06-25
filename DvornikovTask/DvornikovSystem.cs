using System;
using System.Collections.Generic;
using DvornikovTask.Math;

namespace DvornikovTask
{
    public class DvornikovSystem
    {
        public uint MobilityW { get; private set; }

        public uint CountM { get; private set; }

        public uint CountN { get; private set; }

        public uint ComplexityTau { get; private set; }


        public DvornikovSystem(uint mobilityW, uint countM, uint countN, uint complexityTau)
        {
            CheckArgs(mobilityW, countM, countN, complexityTau);
            MobilityW = mobilityW;
            CountM = countM;
            CountN = countN;
            ComplexityTau = complexityTau;
        }

        public static void CheckArgs(uint mobilityW, uint countM, uint countN, uint complexityTau)
        {
            // w-?

            if (countM > 4)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (countN == 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            // tau - ?
        }

        public DvornikovSolution Solve()
        {
            var result = new DvornikovSolution();
            var countNdecompositions = new NumberDecomposition(CountN-1, ComplexityTau - 1);

            var rangeTau = new List<uint>();
            var tmpTau = ComplexityTau;
            while (tmpTau > 0)
            {
                rangeTau.Add(tmpTau);
                tmpTau--;
            }

            foreach (var decomposition in countNdecompositions)
            {
                decomposition.Insert(0, 1);
                var tmp = Utils.MultiSum(decomposition, rangeTau);
                var tmpDecompositions = new NumberDecomposition(tmp, 5 - CountM);
                foreach (var tmpDecomposition in tmpDecompositions)
                {
                    if (CheckSum(tmpDecomposition))
                    {
                        result.Solutions.Add(new SystemSolution((uint) decomposition.Count, decomposition.ToArray()));
                    }
                }
            }

            return result;
        }

        private bool CheckSum(List<uint> tmpDecomposition)
        {
            var sum = 0;
            var m = (int) CountM;
            for (var i = m + 1; i < 6; i++)
            {
                sum += (i - m) * (int) tmpDecomposition[i - m - 1];
            }

            return MobilityW == ((6 - CountM) * CountN - sum);
        }
    }
}