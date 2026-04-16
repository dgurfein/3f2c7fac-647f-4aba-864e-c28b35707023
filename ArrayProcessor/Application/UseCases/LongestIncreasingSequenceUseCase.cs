using ArrayProcessor.Application.DTOs;
using ArrayProcessor.Application.Interfaces;
using ArrayProcessor.Application.Parsers;

namespace ArrayProcessor.Application.UseCases
{
    // This file holds the use case for the longest increasing sequence case and all the processing implementations
    // All included in single file as they are short and simple. Consider splitting to separate files if it grows bigger.

    /// <summary>
    /// The longest incrasing use case. 
    /// Takes an array of integers, find the longest sequence of increasing numbers in it. and returns it
    /// If array contains more than one increasing sequence with same length (max length), the first instance is returned
    /// </summary>
    public sealed class LongestIncreasingSequenceUseCase : IUseCase
    {
        private readonly IParser<LongestIncreasingSequenceRequest> _parser;
        private readonly IValidator<LongestIncreasingSequenceRequest> _validator;
        private readonly IProcessor<LongestIncreasingSequenceRequest, LongestIncreasingSequenceResult> _processor;

        public string Name => UseCaseNames.LongestIncreasingSequence.ToString();

        public string Prompt =>
            "Enter an array of integers values sperated by spaces (e.g. 3 0 101 23466):";

        public string CommandLineUsage =>
            "input is an array of integers sperated by space  (e.g. 3 0 101 23466)";

        public LongestIncreasingSequenceUseCase(
            IParser<LongestIncreasingSequenceRequest> parser,
            IValidator<LongestIncreasingSequenceRequest> validator,
            IProcessor<LongestIncreasingSequenceRequest, LongestIncreasingSequenceResult> processor)
        {
            _parser = parser;
            _validator = validator;
            _processor = processor;
        }

        public object ParseInput(string rawInput) => _parser.Parse(rawInput);

        public void ValidateInput(object input) => _validator.Validate((LongestIncreasingSequenceRequest)input);

        public object Process(object input) => _processor.Process((LongestIncreasingSequenceRequest)input);

        // can probably do with IFormatter for more complex output presentation, kept implementation here as  it is simple
        public string FormatOutput(object result) => $"Longest Increasing Seuqeunce: {((LongestIncreasingSequenceResult)result).ToString()}";
    }

    internal sealed class NumberChainParser : IParser<LongestIncreasingSequenceRequest>
    {
        private readonly IntArrayParser _intParser = new();

        public LongestIncreasingSequenceRequest Parse(string rawInput)
        {
            return new LongestIncreasingSequenceRequest(_intParser.Parse(rawInput," "));
        } 
    }
    internal sealed class NumberChainValidator : IValidator<LongestIncreasingSequenceRequest>
    {
        /// <summary>
        /// Validate the input, empty arrays are not allowed. 
        /// Not checking length at this stage, in 'real life' I would probably set some limits on the array size to avoid overflows
        /// </summary>
        /// <param name="input"></param>
        /// <exception cref="Exception"></exception>
        public void Validate(LongestIncreasingSequenceRequest input)
        {
            var nums = input.NumberArray;

            if (nums.Length == 0)
                throw new Exception("Array cannot be empty.");

            var n = nums.Length;
        }
    }
    internal sealed class NumberChainProcessor : IProcessor<LongestIncreasingSequenceRequest, LongestIncreasingSequenceResult>
    {
        public LongestIncreasingSequenceResult Process1(LongestIncreasingSequenceRequest request)
        {
            var nums = request.NumberArray;

            var n = nums.Length;
            int seqStart = 0;
            int maxLength = 0;
            int maxStart = 0;
            int seqLength = 0;
            // Loop on array and count longest sequence compare to previous and store most current
            for (int i = 0; i < n; i++)
            {
                // If array first position or value greater than previous increase length.
                if (i == 0 || nums[i] > nums[i - 1])
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
            return new LongestIncreasingSequenceResult
            {
                // extract a sub array from best result start position to its end (based on length)
                ResultArray = nums[maxStart..(maxStart + maxLength)]
            };
        }
        // alternative recursive approach, not currently used by the program, but included in test cases.
        public LongestIncreasingSequenceResult Process(LongestIncreasingSequenceRequest request)
        {
            var nums = request.NumberArray;
            var result = GetLongestIncreasingSeq(nums, 0);
 
            return new LongestIncreasingSequenceResult
            {
                // extract a sub array from best result start position to the end
                ResultArray = nums[result.Item1..(result.Item1+result.Item2)]
            };
        }

        private (int,int) GetLongestIncreasingSeq(int[] intArray, int origPosition)
        {
            //scan the array from position 1 to the end, return the endIndex of the increasing sequence
            //as in the first position that no longer increases, if none found return -1 as default
            var endIndex = Enumerable.Range(1, intArray.Length - 1)
                      // -1 is returned if we got to end of array and no entry found
                      .FirstOrDefault(i => intArray[i] <= intArray[i - 1], -1); 
            if (endIndex == -1) // end array reached, return starting position and the length to the end.
            {
                return (origPosition, intArray.Length);
            }
            // sequence broken before the end, call recursively with remaining array
            var subArray = intArray[endIndex..intArray.Length];
            // recursevly go to next position
            var nextSequence = GetLongestIncreasingSeq(subArray, origPosition+endIndex);
            // Return the better entry from the 2 calls:
            if (nextSequence.Item2 > endIndex)
            {
                return (nextSequence.Item1, nextSequence.Item2);
            }
            return (origPosition, endIndex);
        }
    }

}
