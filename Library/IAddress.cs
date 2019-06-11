namespace Recurly
{
    public interface IAddress : IRecurlyEntity
    {
        string Address1 { get; set; }
        string Address2 { get; set; }
        string City { get; set; }
        string Company { get; set; }
        string Country { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string NameOnAccount { get; set; }
        string Phone { get; set; }
        string State { get; set; }
        string Zip { get; set; }
    }
}