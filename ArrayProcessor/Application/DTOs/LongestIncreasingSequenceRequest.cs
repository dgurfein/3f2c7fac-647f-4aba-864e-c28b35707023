using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayProcessor.Application.DTOs
{
    /// <summary>
    /// Data transfor object representing the use case request structure
    /// </summary>
    public class LongestIncreasingSequenceRequest
    {
        public int[] NumberArray { get; } = [];
        public LongestIncreasingSequenceRequest(int[] numbers)
        {
            NumberArray = numbers;
        }
    }
}
