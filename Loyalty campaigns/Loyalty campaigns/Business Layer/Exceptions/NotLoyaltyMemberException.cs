namespace Loyalty_campaigns.Business_Layer.Exceptions
{
    public class NotLoyaltyMemberException:Exception
    {
        public NotLoyaltyMemberException(string message) : base(message) { }
    }
}
