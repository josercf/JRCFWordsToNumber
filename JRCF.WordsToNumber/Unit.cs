using System.Collections.Generic;

namespace JRCF.WordsToNumber
{
    internal sealed class Unit : Expression
    {
        public override bool TokenFounded { get; set; } = true;
        private Dictionary<string, string> numbers = new Dictionary<string, string>();

        public Unit()
        {
            numbers.Add("zero", "0");
            numbers.Add("um", "1");
            numbers.Add("dois", "2");
            numbers.Add("tres", "3");
            numbers.Add("quatro", "4");
            numbers.Add("cinco", "5");
            numbers.Add("seis", "6");
            numbers.Add("meia", "6");
            numbers.Add("sete", "7");
            numbers.Add("oito", "8");
            numbers.Add("nove", "9");
        }

        public override void Interpret(Context context, string data)
        {
            if (numbers.TryGetValue(data, out string value))
            {
                context.Output += string.Format("{0}", value);
                TokenFounded = true;
                return;
            }

            TokenFounded = false;
        }
    }
}
