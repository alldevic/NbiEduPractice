using System;
using System.Collections.Generic;
using System.Linq;
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
            if (countM > 4)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (countN == 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (complexityTau == 0)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public DvornikovSolution Solve()
        {
            var result = new DvornikovSolution(this);
            var decompositions = new NumberDecomposition(CountN - 1, ComplexityTau - 1);
            var rangeTau = Enumerable.Range(1, (int) ComplexityTau).Reverse().Select(i => (uint) i).ToList();

            foreach (var decomposition in decompositions)
            {
                decomposition.Insert(0, 1);
                var tmp = Utils.MultiSum(decomposition, rangeTau);
                var tmpDecompositions = new NumberDecomposition(tmp, 5 - CountM);
                var resultDecomposition = decomposition.Skip(1).Reverse().ToArray();

                var key = new SystemSolution((uint) resultDecomposition.Length, resultDecomposition,
                    Enumerable.Range(1, (int) ComplexityTau - 1).Select(i => (uint) i).ToArray());
                
                foreach (var tmpDecomposition in tmpDecompositions)
                {
                    if (!CheckSum(tmpDecomposition))
                    {
                        continue;
                    }

                    var value = new SystemSolution((uint) tmpDecomposition.Count, tmpDecomposition.ToArray(),
                        Enumerable.Range((int)CountM + 1, (int) (5 - CountM)).Reverse().Select(i => (uint) i).ToArray());

                    if (!result.Solutions.ContainsKey(key))
                    {
                        result.Solutions.Add(key, new List<SystemSolution>());
                    }

                    result.Solutions[key].Add(value);
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