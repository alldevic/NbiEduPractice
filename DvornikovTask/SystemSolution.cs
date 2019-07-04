namespace DvornikovTask
 {
     public class SystemSolution
     {
         public uint DimensionsCount { get; }
         public uint[] Values { get; }
 
         public uint[] Indexes { get; }
 
         public SystemSolution(uint dimension, uint[] values, uint[] indexes)
         {
             DimensionsCount = dimension;
             Values = values;
             Indexes = indexes;
         }
         
     }
 }