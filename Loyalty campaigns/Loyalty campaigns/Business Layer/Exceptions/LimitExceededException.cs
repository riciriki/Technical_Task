namespace Loyalty_campaigns.Business_Layer.Exceptions
{
    public class LimitExceededException:Exception
    {
        public LimitExceededException(string message) : base(message) { }
    }
}
