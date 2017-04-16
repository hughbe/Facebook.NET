using System.Text;

namespace Facebook.Requests
{
    public abstract class Request
    {
        internal abstract void Format(StringBuilder builder);
    }
}
