using NLPWebApi.Common;

namespace NLPWebApi.Algorithm
{
    public class ConvertToWord
    {
        // Given a string input number, the method converting it handwriting number
        public string DigitToWord(string input)
        {
            try
            {
                var inputArray = input.Split(' ');
                List<string> output = new List<string>();
                Stack<List<string>> returnValue = new Stack<List<string>>();

                foreach (string word in inputArray)
                {
                    int number = 0;
                    if (!int.TryParse(word, out number))
                        continue;

                    if (number == 0)
                    {
                        return "sıfır";
                    }

                    int chunkSize = 3;
                    int chunkNumber = 0;

                    chunkNumber = word.Length / chunkSize;
                    if (word.Length % chunkSize != 0)
                        chunkNumber += 1;

                    // For each chunk extract the word equivalent
                    string tmpReverse = ReverseFunction.ReverseChar(word);
                    for (int i = 0; i < chunkNumber; i++)
                    {
                        string thisChunk = "";
                        if (i == chunkNumber - 1 && (word.Length % chunkSize != 0))
                            thisChunk = tmpReverse.Substring(i * chunkSize, word.Length % chunkSize);
                        else
                            thisChunk = tmpReverse.Substring(i * chunkSize, chunkSize);



                        foreach (var item in Dictionary.allNumbersDict)
                        {
                            if (thisChunk.Length != 3)
                                break;

                            if (item.Value == thisChunk[2] - '0') // Hundreds
                            {
                                if (item.Value != 1)
                                    output.Add(item.Key);
                                output.Add("yüz");
                                break;
                            }
                        }

                        foreach (var item in Dictionary.allNumbersDict)
                        {
                            if (thisChunk.Length < 2)
                                break;

                            if (item.Value == thisChunk[1] - '0') // Tens
                            {
                                int tmp = item.Value * 10;
                                foreach (var val in Dictionary.allNumbersDict)
                                {
                                    if (val.Value == tmp)
                                    {
                                        output.Add(val.Key);
                                        break;
                                    }
                                }
                            }
                        }

                        foreach (var item in Dictionary.allNumbersDict)
                        {
                            if (thisChunk.Length < 1)
                                break;

                            if (item.Value == thisChunk[0] - '0') // Ones
                            {
                                output.Add(item.Key);
                                break;
                            }
                        }

                        if (i > 0)
                        {
                            double tmpMult = Math.Pow(1000.0, (double)i);
                            output.Add(Dictionary.multipliersSorted[(int)tmpMult]);
                        }

                        // Use stack to reverse the order
                        // reverse the chunks ex: c1c2 will be c2c1
                        List<string> tmpCopyList = new List<string>(output); 
                        returnValue.Push(tmpCopyList);
                        output.Clear();
                    }
                }

                // Clear stack one by one to create the output
                foreach (var item in returnValue)
                {
                    foreach (var word in item)
                    {
                        output.Add(word);
                    }
                }

                // Prepare the output
                return string.Join(" ", output);
            }
            catch
            {
                Console.WriteLine("Error: DigitToWord");
                return "";
            }
        }
    }
}
