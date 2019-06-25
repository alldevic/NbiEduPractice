using System.Collections.Generic;
using System.Linq;

namespace DvornikovTask.Math
{
    public class NumberDecomposition
    {
        public uint Number { get; private set; }
        public uint TermsCount { get; private set; }

        public NumberDecomposition(uint number, uint termsCount)
        {
            Number = number;
            TermsCount = termsCount;
        }

        public IEnumerator<List<uint>> GetEnumerator()
        {
            var tmp = new uint[TermsCount + 1];
            tmp[TermsCount] = Number + TermsCount;

            for (uint i = 1; i < TermsCount; i++)
            {
                tmp[i] = i;
            }

            do
            {
                var res = new uint[TermsCount];
                for (var i = 1; i <= TermsCount; i++)
                {
                    res[i - 1] = tmp[i] - tmp[i - 1] - 1;
                }

                yield return res.ToList();
            } while (NextDecomposition(tmp));
        }

        private bool NextDecomposition(uint[] prev)
        {
            for (var i = TermsCount - 1; i > 0; i--)
            {
                if (prev[i] >= Number + i)
                {
                    continue;
                }

                prev[i] = prev[i] + 1;
                for (var j = i + 1; j < TermsCount; j++)
                {
                    prev[j] = prev[j - 1] + 1;
                }

                return true;
            }

            return false;
        }
    }
}