using System;

namespace Recurly
{
    public interface IDelivery : IRecurlyEntity
    {
        IAddress Address { get; set; }
        DateTime? DeliverAt { get; set; }
        string EmailAddress { get; set; }
        string FirstName { get; set; }
        string GifterName { get; set; }
        string LastName { get; set; }
        Delivery.DeliveryMethod Method { get; set; }
        string PersonalMessage { get; set; }
    }
}