using Core.Results.Bases;

namespace Core.Results
{
    public class ErrorResult : ResultBase
    {
        public ErrorResult(string message) : base(false, message)
        {
        }

        public ErrorResult() : base(false, "")
        {
        }
    }
}
