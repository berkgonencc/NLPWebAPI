namespace NLPWebApi.Algorithm
{
    public class Dictionary
    {
        public static readonly Dictionary<string, int> allNumbersDict = new Dictionary<string, int>()
        {
            {"bir" , 1}, {"iki", 2},{"üç", 3},{"dört", 4},{"beş", 5},{"altı", 6},
            {"yedi", 7},{"sekiz", 8},{"dokuz", 9},{"on", 10},{"yirmi", 20},{"otuz", 30},{"kırk", 40},
            {"elli", 50},{"altmış", 60},{"yetmiş", 70},{"seksen", 80},{"doksan", 90},{ "yüz", 100 },{ "bin", 1000 }, { "milyon", 1000000 }
        };

        public static readonly Dictionary<string, int> additionWords = new Dictionary<string, int>()
        {
            {"bir" , 1}, {"iki", 2},{"üç", 3},{"dört", 4},{"beş", 5},{"altı", 6},
            {"yedi", 7},{"sekiz", 8},{"dokuz", 9},{"on", 10},{"yirmi", 20},{"otuz", 30},{"kırk", 40},
            {"elli", 50},{"altmış", 60},{"yetmiş", 70},{"seksen", 80},{"doksan", 90}
        };

        public static readonly Dictionary<string, int> multiplicationWords = new Dictionary<string, int>()
        {
            { "yüz", 100 }, { "bin", 1000 }, { "milyon", 1000000 }
        };

        public static readonly SortedList<int, string> multipliersSorted = new SortedList<int, string>()
        {
            { 100, "yüz" }, { 1000, "bin" }, { 1000000, "milyon" }
        };
    }
}
