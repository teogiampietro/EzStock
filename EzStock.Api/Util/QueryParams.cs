namespace EzStock.Api.Util
{
    public static class QueryParams
    {
        public static List<int> GetListInt(string values)
        {
            var result = new List<int>();
            if (values == null && string.IsNullOrEmpty(values))
                return result;

            foreach (string number in values.Split(','))
                result.Add(int.Parse(number));
            return result;
        }
    }
}
