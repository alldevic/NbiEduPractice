using System;
using System.Collections.Generic;

namespace DvornikovTask.Math
{
    public static class Utils
    {
        public static uint MultiSum(List<uint> firstList, List<uint> secondList)
        {
            if (firstList.Count != secondList.Count)
            {
                throw new ArgumentException();
            }

            uint result = 0;
            for (var i = 0; i < firstList.Count; i++)
            {
                result += firstList[i] * secondList[i];
            }

            return result;
        }
    }
}