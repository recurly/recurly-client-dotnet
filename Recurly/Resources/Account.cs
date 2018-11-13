using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace Recurly.Resources {
  public class Account : Resource {
  
    
    [DeserializeAs(Name = "address")]
    public Address Address { get; set; }
  
    
    [DeserializeAs(Name = "billing_info")]
    public BillingInfo BillingInfo { get; set; }
  
    /// <value>Additional email address that should receive account correspondence. These should be separated only by commas. These CC emails will receive all emails that the `email` field also receives.</value>
    [DeserializeAs(Name = "cc_emails")]
    public string CcEmails { get; set; }
  
    /// <value>The unique identifier of the account. This cannot be changed once the account is created.</value>
    [DeserializeAs(Name = "code")]
    public string Code { get; set; }
  
    
    [DeserializeAs(Name = "company")]
    public string Company { get; set; }
  
    /// <value>When the account was created.</value>
    [DeserializeAs(Name = "created_at")]
    public DateTime? CreatedAt { get; set; }
  
    
    [DeserializeAs(Name = "custom_fields")]
    public List<CustomField> CustomFields { get; set; }
  
    /// <value>If present, when the account was last marked inactive.</value>
    [DeserializeAs(Name = "deleted_at")]
    public DateTime? DeletedAt { get; set; }
  
    /// <value>The email address used for communicating with this customer. The customer will also use this email address to log into your hosted account management pages. This value does not need to be unique.</value>
    [DeserializeAs(Name = "email")]
    public string Email { get; set; }
  
    
    [DeserializeAs(Name = "first_name")]
    public string FirstName { get; set; }
  
    /// <value>The unique token for automatically logging the account in to the hosted management pages. You may automatically log the user into their hosted management pages by directing the user to: `https://{subdomain}.recurly.com/account/{hosted_login_token}`.</value>
    [DeserializeAs(Name = "hosted_login_token")]
    public string HostedLoginToken { get; set; }
  
    
    [DeserializeAs(Name = "id")]
    public string Id { get; set; }
  
    
    [DeserializeAs(Name = "last_name")]
    public string LastName { get; set; }
  
    /// <value>Object type</value>
    [DeserializeAs(Name = "object")]
    public string Object { get; set; }
  
    /// <value>The UUID of the parent account associated with this account.</value>
    [DeserializeAs(Name = "parent_account_id")]
    public string ParentAccountId { get; set; }
  
    /// <value>Used to determine the language and locale of emails sent on behalf of the merchant to the customer.</value>
    [DeserializeAs(Name = "preferred_locale")]
    public string PreferredLocale { get; set; }
  
    /// <value>The shipping addresses on the account.</value>
    [DeserializeAs(Name = "shipping_addresses")]
    public List<ShippingAddress> ShippingAddresses { get; set; }
  
    /// <value>Accounts can be either active or inactive.</value>
    [DeserializeAs(Name = "state")]
    public string State { get; set; }
  
    /// <value>The tax status of the account. `true` exempts tax on the account, `false` applies tax on the account.</value>
    [DeserializeAs(Name = "tax_exempt")]
    public bool? TaxExempt { get; set; }
  
    /// <value>When the account was last changed.</value>
    [DeserializeAs(Name = "updated_at")]
    public DateTime? UpdatedAt { get; set; }
  
    /// <value>A secondary value for the account.</value>
    [DeserializeAs(Name = "username")]
    public string Username { get; set; }
  
    /// <value>The VAT number of the account (to avoid having the VAT applied). This is only used for manually collected invoices.</value>
    [DeserializeAs(Name = "vat_number")]
    public string VatNumber { get; set; }
  
  }
}
