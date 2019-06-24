namespace Recurly
{
    public interface IShippingAddress : IRecurlyEntity
    {
        string Address1 { get; set; }
        string Address2 { get; set; }
        string City { get; set; }
        string CompanyName { get; set; }
        string Country { get; set; }
        string Email { get; set; }
        string FirstName { get; set; }
        long? Id { get; }
        string LastName { get; set; }
        string Nickname { get; set; }
        string Phone { get; set; }
        string State { get; set; }
        string VatNumber { get; set; }
        string Zip { get; set; }
    }
}