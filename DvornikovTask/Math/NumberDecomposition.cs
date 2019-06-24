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
            var decomposition = new uint[TermsCount];
            decomposition[0] = Number;
            yield return decomposition.ToList();
            while (decomposition[TermsCount - 1] != Number)
            {
                yield return NextDecomposition(decomposition);
            }
        }

        // TODO: выводит далеко не все разложения
        private List<uint> NextDecomposition(uint[] decomposition)
        {
            var max = decomposition.ToList().IndexOf(decomposition.First(x => x != 0));
            for (int i = max; i < decomposition.Length; i++)
            {
                if (decomposition[i] != 0 && decomposition[i] > decomposition[max])
                {
                    max = i;
                }
            }

            decomposition[max]--;


            if (max + 1 > decomposition.Length - 1)
            {
                var tmp = decomposition.Cast<int>().Sum() + 1;
                for (int i = 0; i < decomposition.Length; i++)
                {
                    decomposition[i] = 0;
                }

                decomposition[max] = (uint) tmp;
            }
            else
            {
                decomposition[max + 1]++;
            }


            return decomposition.ToList();
        }
    }
}