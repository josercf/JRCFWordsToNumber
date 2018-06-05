
namespace JRCF.WordsToNumber
{
    public abstract class Expression : IExpression
    {
        public abstract void Interpret(Context context, string data);
        public abstract bool TokenFounded { get; set; }
    }
}
