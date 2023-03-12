namespace NLPWebApi.Common
{
    public class ReverseFunction
    {
        public static string ReverseChar(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
