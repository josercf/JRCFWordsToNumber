using System;
using System.Collections.Generic;
using System.Text;

namespace JRCF.WordsToNumber
{
    public interface IExpression
    {
        void Interpret(Context context, string data);
    }
}
