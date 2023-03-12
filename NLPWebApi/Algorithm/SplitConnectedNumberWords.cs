using NLPWebApi.Algorithm;

namespace NLPWebApi.Algorithm
{
    public class SplitConnectedNumberWords
    {
        // Given a string input, the method separating words from each other
        public string SplitConnectedWords(string input)
        {
            try
            {
                var inputArray = input.ToLower().Split(' ');
                ConvertToWord convertToWord = new ConvertToWord();
                List<string> output = new List<string>();

                // special cases: "milyon" and "sonra";
                string specialCase0 = "sonra";
                string specialCase1 = "milyon";

                // For all the input words
                for (int i = 0; i < inputArray.Length; i++)
                {
                    // Handle special cases
                    if (inputArray[i] == specialCase0 || inputArray[i] == specialCase1)
                    {
                        output.Add(inputArray[i]);
                        continue;
                    }

                    // Handle: "milyonda", "onmilyon", "onmilyonda"
                    // Taking first index and length of "milyon"
                    int milyonContainingWordIndex = inputArray[i].IndexOf(specialCase1);
                    int milyonContainingWordSize = inputArray[i].Length;
                    if (milyonContainingWordIndex != -1)
                    {
                        // There are pre and post words around "milyon" (i.e: "onmilyonda")
                        if (milyonContainingWordIndex > 0 && milyonContainingWordSize > milyonContainingWordIndex + specialCase1.Length)
                        {
                            output.Add(inputArray[i].Substring(0, milyonContainingWordIndex));
                            output.Add(specialCase1);
                            output.Add(inputArray[i].Substring(milyonContainingWordIndex + specialCase1.Length, milyonContainingWordSize - (milyonContainingWordIndex + specialCase1.Length)));
                        }
                        // There is pre word around "milyon" (i.e: "onmilyon")
                        else if (milyonContainingWordIndex > 0)
                        {
                            output.Add(inputArray[i].Substring(0, milyonContainingWordIndex));
                            output.Add(specialCase1);
                        }
                        // There is post word around "milyon" (i.e: "milyonda")
                        else
                        {
                            output.Add(specialCase1);
                            output.Add(inputArray[i].Substring(milyonContainingWordIndex + specialCase1.Length, milyonContainingWordSize - (milyonContainingWordIndex + specialCase1.Length)));
                        }
                        continue;
                    }

                    // Handle the connected words
                    // Adding startIndex and length of the words into sorted dictionary to separate words from each other
                    SortedDictionary<int, int> separationIndices = new SortedDictionary<int, int>();
                    foreach (var item in Dictionary.allNumbersDict.Keys)
                    {
                        int startIndex = inputArray[i].IndexOf(item);
                        if (startIndex != -1)
                        {
                            separationIndices.Add(startIndex, item.Length);
                        }
                    }

                    int totalLength = 0;
                    // If the dictionary is empty, add the word directly to the output
                    if (separationIndices.Count() == 0)
                    {
                        int n;
                        bool isNumeric = int.TryParse(inputArray[i], out n);
                        if (isNumeric)
                        {
                            var result = convertToWord.DigitToWord(inputArray[i]);
                            output.Add(result);
                        }
                        else
                        {
                            output.Add(inputArray[i]);
                        }
                    }
                    // Otherwise, separating words from each other
                    else
                    {
                        foreach (var item in separationIndices)
                        {
                            totalLength += item.Value;
                            string num = inputArray[i].Substring(item.Key, item.Value);
                            output.Add(num);
                        }
                        // If word starts with number ( ie: bir, iki, ...)
                        if (totalLength != inputArray[i].Length && separationIndices.Keys.First() == 0)
                        {
                            // A word that is not a number word is detected
                            int sizeOfRemaining = inputArray[i].Length - totalLength;
                            string word = inputArray[i].Substring(totalLength, sizeOfRemaining);

                            // If the remaining word is a number string or not
                            int n;
                            bool isNumeric = int.TryParse(word, out n);
                            if (isNumeric)
                            {
                                var result = convertToWord.DigitToWord(word);
                                output.Add(result);
                            }
                            else
                            {
                                output.Add(word);
                            }
                        }
                    }
                }
                // Prepare the output
                return string.Join(" ", output);
            }
            catch
            {
                Console.WriteLine("Error: SplitConnectedNumberWords");
                return "";
            }
        }
    }
}

