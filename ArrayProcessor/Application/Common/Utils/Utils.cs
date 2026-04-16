using ArrayProcessor.Application.Parsers;

namespace ArrayProcessor.Application.Common.Utils
{
    public class Utils
    {
        public static int[] ParseStringToIntegerArray(string str, string separator = ",")
        {
            if (string.IsNullOrEmpty(str))
            {
                return [];
            }
            IntArrayParser parser = new IntArrayParser();
            return parser.Parse(str,separator);
        }
        /// <summary>
        /// The method loop on the input integer array and detects the longest increasing sequence which is returned as output
        /// if input array is empty, empty array is returned
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static int[] GetLongestIncreasingSequence(int[] intArray)
        {
            var n = intArray.Length;
            if (n == 0)
            {
                return [];
            }
            int seqStart = 0;
            int maxLength = 0;
            int maxStart = 0;
            int seqLength = 0;
            // Loop on array and count longest sequence compare to previous and store most current
            for (int i = 0; i < n; i++)
            {
                // If array first position or value greater than previous increase length.
                if (i == 0 || intArray[i] > intArray[i - 1])
                {
                    seqLength++; // increase the length
                }
                else // increasing sequence stopped at i, so need to restart counting new sequence
                {
                    //check if current result is better than the stored max.
                    if (seqLength > maxLength)
                    {
                        maxLength = seqLength;
                        maxStart = seqStart; //store starting possition of the new max sequence
                    }
                    // starting over - set new start point for next chain
                    seqStart = i;
                    seqLength = 1; //minimum length is 1 (For first position in the sequence)
                }
            }
            //check last result in case the last array position was the end of the longest sequence
            if (seqLength > maxLength)
            {
                maxLength = seqLength;
                maxStart = seqStart;
            }
            return intArray[maxStart..(maxStart + maxLength)];
        }
    }
}
