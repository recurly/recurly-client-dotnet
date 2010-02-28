## Recurly .NET Client ##

The Recurly .NET Client library is an open source library to interact with Recurly's subscription management from your ASP.Net website.
The library interacts with Recurly's [REST API](http://support.recurly.com/faqs/api).  This library works with .NET 2.0 and greater.

## Installation ##

The easiest way to get the source code is to click the **Download Source** button at the top of this page.  Alternatively, you can use git.
With git intalled, the easiest way to download the Recurly .NET Client is with the git command:

    git clone git://github.com/recurly/recurly-client-net.git C:\path\to\recurly

If you do not have git and have some interest in learning about a wonderful source control tool, please check out the
[Github Guide for Windows](http://github.com/guides/using-git-and-github-for-the-windows-for-newbies).

## Configuration ##

Your API username, password, and site subdomain can be specified in your **web.config** file:

    <?xml version="1.0" encoding="utf-8" ?>
    <configuration>
      <configSections>
        <section name="recurly" type="Recurly.Configuration.RecurlySection,Recurly"/>
      </configSections>
      
      <recurly 
        username="api@company.com"
        password="1024e1285b244f4586d64dfd47e3acb3"
        subdomain="company-test" />
      
    </configuration>

## To Do ##

* Write unit tests
* List/paginate through accounts, transactions, etc
* Process POST notifications
* Member variable validation
* Validate credit card information before submitting request


## API Documentation ##

Please see the [Recurly API](http://support.recurly.com/faqs/api/) for more information.