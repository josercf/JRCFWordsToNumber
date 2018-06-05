namespace JRCF.WordsToNumber
{
    public static class StringExtensions
    {
        public static int ToInt(this string value)
        {
            var parser = new Parser(value);
            var number = parser.ConvertTextToDecimal();

            if (int.TryParse(number, out int newValue))
                return newValue;

            return 0;
        }

        public static decimal ToDecimal(this string value)
        {
            var parser = new Parser(value);
            var number = parser.ConvertTextToDecimal();

            if (decimal.TryParse(number, out decimal newValue))
                return newValue;

            return 0;
        }

        public static string Parse(this string value)
        {
            var parser = new Parser(value);
            var number = parser.ConvertTextToDecimal();

            return number;
        }
    }
}
