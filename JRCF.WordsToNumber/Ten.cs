using System.Collections.Generic;

namespace JRCF.WordsToNumber
{
    internal sealed class Ten : Expression
    {
        public override bool TokenFounded { get; set; }
        private Dictionary<string, string> numbers = new Dictionary<string, string>();

        public Ten()
        {
            numbers.Add("dez", "10");
            numbers.Add("onze", "11");
            numbers.Add("doze", "12");
            numbers.Add("treze", "13");
            numbers.Add("catorze", "14");
            numbers.Add("quatorze", "14");
            numbers.Add("quinze", "15");
            numbers.Add("dezesseis", "16");
            numbers.Add("dezessete", "17");
            numbers.Add("dezoito", "18");
            numbers.Add("dezenove", "19");
            numbers.Add("vinte", "20");
            numbers.Add("trinta", "30");
            numbers.Add("quarenta", "40");
            numbers.Add("cinquenta", "50");
            numbers.Add("sessenta", "60");
            numbers.Add("setenta", "70");
            numbers.Add("oitenta", "80");
            numbers.Add("noventa", "90");
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
