namespace Core.Results.Bases
{
    public abstract class ResultBase
    {
        public bool IsSuccessful { get; }
        public string Message { get; set; }

        protected ResultBase(bool isSuccessful, string message)
        {
            IsSuccessful = isSuccessful;
            Message = message;
        }
    }
}
