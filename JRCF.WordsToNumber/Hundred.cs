using System.Collections.Generic;

namespace JRCF.WordsToNumber
{
    internal sealed class Hundred : Expression
    {
        public override bool TokenFounded { get; set; }
        private Dictionary<string, string> numbers = new Dictionary<string, string>();

        public Hundred()
        {
            numbers.Add("cem", "100");
            numbers.Add("cento", "100");
            numbers.Add("duzentos", "200");
            numbers.Add("trezentos", "300");
            numbers.Add("quatrocentos", "400");
            numbers.Add("quinhentos", "500");
            numbers.Add("seiscentos", "600");
            numbers.Add("setescentos", "700");
            numbers.Add("oitocentos", "800");
            numbers.Add("novecentos", "900");
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