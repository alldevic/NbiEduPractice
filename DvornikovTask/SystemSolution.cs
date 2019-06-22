namespace DvornikovTask
{
    public class SystemSolution
    {
        public uint DimensionsCount { get; }
        public uint[] Values { get; }

        public SystemSolution(uint dimension, uint[] values)
        {
            DimensionsCount = dimension;
            Values = values;
        }
    }
}