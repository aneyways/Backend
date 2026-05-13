namespace AudioShop .Domains.Entitiies.Order
{
    public enum OrderStatus
    {
        None,
        Declined,
        Aceepted,
        Validating,
        Paid,
        Delivered,
        Refund
    }
}
