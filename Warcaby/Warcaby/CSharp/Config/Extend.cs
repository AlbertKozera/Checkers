using System.Collections;


namespace Warcaby.Forms
{
    public static class Extend
    {
        public static bool IsNullOrEmpty(this IList List)
        {
            return (List == null || List.Count < 1);
        }
        public static bool IsNullOrEmpty(this IDictionary Dictionary)
        {
            return (Dictionary == null || Dictionary.Count < 1);
        }
    }
}
