using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayProcessor.Application.DTOs
{
    /// <summary>
    /// Data transfor object representing the use case result structure
    /// </summary>
    public class LongestIncreasingSequenceResult
    {
        public int[] ResultArray { get; set; } = [];
        public override string ToString()
        {
            return string.Join(' ', ResultArray);
        }
    }
}
