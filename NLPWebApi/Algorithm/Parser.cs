namespace NLPWebApi.Algorithm
{
    public class Parser
    {
        // Given a string text, the method convert it string text with digits
        public string InputParser(string text)
        {
            ConvertToDigit convertToDigit = new ConvertToDigit();
            SplitConnectedNumberWords splitConnectedNumberWords = new SplitConnectedNumberWords();
            try
            {
                // Firstly, check if there is a connected words and digits ( ie: "ikiyüzelli", "50" )
                var textArray = splitConnectedNumberWords.SplitConnectedWords(text).Split(" ");

                var result = "";
                var tmpNumberList = new List<string>();
                var output = new List<string>();

                // Loop through the text array
                for (int i = 0; i < textArray.Length; i++)
                {
                    // If the next word is a number inside of an array, add to temporary number list
                    if (Dictionary.additionWords.ContainsKey(textArray[i]) || Dictionary.multiplicationWords.ContainsKey(textArray[i]))
                    {
                        tmpNumberList.Add(textArray[i]);
                    }
                    // Otherwise, first check the temporary number list is empty?
                    // If it is empty, word is added to output list directly.
                    else
                    {
                        // Secondly, If it is not empty, send the resulting number string to the number converter method (ie: WordToDigit)
                        // and, the result added to the output list.
                        if (tmpNumberList.Any())
                        {
                            int numberResult = convertToDigit.WordToDigit(string.Join(" ", tmpNumberList));
                            output.Add(numberResult.ToString());
                            tmpNumberList.Clear();
                        }
                        output.Add(textArray[i]);
                    }
                }
                // If there is a number word in the end of the string,
                // send the resulting number string to WordToDigit Method
                if (tmpNumberList.Any())
                {
                    output.Add(convertToDigit.WordToDigit(string.Join(" ", tmpNumberList)).ToString());
                }

                // Prepare the output
                result = string.Join(" ", output);
                return result;
            }
            catch
            {
                Console.WriteLine("Error: InputParser");
                return "";
            }
        }
    }
}
