using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace JRCF.WordsToNumber
{
    public class Parser
    {
        private List<string> stack = new List<string>();
        private readonly string value;

        public Parser(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));

            this.value = RemoveDiacritics(value.ToLower());
        }

        public string ConvertTextToDecimal()
        {
            var tokens = Tokenize(value);

            var context = new Context();
            var unit = new Unit();
            var ten = new Ten();
            var hundred = new Hundred();

            for (int i = 0; i < tokens.Count; i++)
            {
                if (tokens[i] == "e") continue;

                ClearForJoin(tokens, context, i);

                unit.Interpret(context, tokens[i]);
                if (unit.TokenFounded)
                {
                    if (stack.Any() && stack.Last() == "hundred")
                        context.Output = context.Output.Insert(context.Output.Length - 1, "0");

                    stack.Add("unit");
                    continue;
                }

                ten.Interpret(context, tokens[i]);
                if (ten.TokenFounded)
                {
                    stack.Add("ten");
                    continue;
                }

                hundred.Interpret(context, tokens[i]);
                if (hundred.TokenFounded)
                {
                    stack.Add("hundred");
                    continue;
                }
            }

            stack = null;
            tokens = null;

            return context.Output.Replace(" ", string.Empty);
        }

        private void ClearForJoin(List<string> tokens, Context context, int i)
        {
            if (i > -1 && tokens[i - (i == 0 ? 0 : 1)] == "e")
            {
                var item = stack.Count > 0 ? stack.Last() : string.Empty;
                var length = 0;
                switch (item)
                {
                    case "unit":
                        length = 0;
                        break;
                    case "ten":
                        length = 1;
                        break;
                    case "hundred":
                        if (tokens[i - (i == 0 ? 0 : 2)] == "cem")
                            length = 0;
                        else
                            length = 2;
                        break;
                    default:
                        length = 0;
                        break;
                }

                if (!string.IsNullOrEmpty(context.Output))
                    context.Output = context.Output.Remove(context.Output.Length - length, length);
            }
        }

        private List<string> Tokenize(string data) => data.Split(' ').ToList();

        private static string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

    }
}
