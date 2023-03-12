namespace NLPWebApi.Algorithm
{
    public class ConvertToDigit
    {
        // Given a number word, the method converts it to integer
        public int WordToDigit(string input)
        {
            var multiplicationWords = Dictionary.multiplicationWords;
            var additionWords = Dictionary.additionWords;

            try
            {
                string[] inputArray = input.ToLower().Split(' ');

                // Special case: "bin", when the array starts with "bin",
                // the method add "bir" to beginning of the array
                if (inputArray[0] == "bin")
                {
                    List<string> wordList = inputArray.ToList();
                    wordList.Insert(0, "bir");
                    inputArray = wordList.ToArray();
                }

                int lastMultiplierIndex = 0;
                int lastMultiplier = 0;
                List<int> limiterIndices = new List<int>();
                // Add first index "0" into the limiter
                limiterIndices.Add(0);

                // Loop through to find multiplication word indexes
                for (int i = 0; i < inputArray.Count(); ++i)
                {
                    // check the last biggest multiplier index
                    for (int j = lastMultiplierIndex; j < inputArray.Count(); ++j)
                    {
                        if (multiplicationWords.ContainsKey(inputArray[j]))
                        {
                            if (multiplicationWords[inputArray[j]] > lastMultiplier)
                            {
                                lastMultiplierIndex = j;
                                lastMultiplier = multiplicationWords[inputArray[j]];
                            }
                        }
                    }
                    // Do not push another limiter if the number contains one word
                    if (lastMultiplierIndex != limiterIndices.Last())
                    {
                        limiterIndices.Add(lastMultiplierIndex);
                    }
                    lastMultiplier = 0;
                }

                // Add last index of input into the limiter to get size of entire array
                limiterIndices.Add(inputArray.Count() - 1);

                int total = 0;
                int tmpTotal = 0;

                // Go from left to right, calculate all limited areas, sum all the results of limited areas
                for (int i = 0; i < limiterIndices.Count() - 1; i++)
                {
                    int startingIndex = limiterIndices[i];

                    if (i != 0)
                        startingIndex += 1;

                    int endIndex = limiterIndices[i + 1];
                    for (int j = startingIndex; j <= endIndex; j++)
                    {
                        if (additionWords.ContainsKey(inputArray[j]))
                        {
                            tmpTotal += additionWords[inputArray[j]];
                        }
                        else
                        {
                            if (j == startingIndex)
                                tmpTotal = 1;
                            tmpTotal *= multiplicationWords[inputArray[j]];
                        }
                    }
                    total += tmpTotal;
                    tmpTotal = 0;
                }
                // Prepare the output
                return total;
            }
            catch
            {
                Console.WriteLine("Error: WordToDigit");
                return -1;
            }
        }
    }
}

