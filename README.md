# Recurly .NET Client

The Recurly .NET Client library is an open source library to interact with Recurly's subscription management from your ASP.Net website.
The library interacts with Recurly's [REST API](http://support.recurly.com/faqs/api).  This library works with .NET 2.0 and greater.

## Installation

The easiest way to get the source code is to click the **Download Source** button at the top of this page.  Alternatively, you can use git.
With git installed, the easiest way to download the Recurly .NET Client is with the git command:

    git clone git://github.com/recurly/recurly-client-net.git C:\path\to\recurly

If you do not have git and have some interest in learning about a wonderful source control tool, please check out the
[Github Guide for Windows](http://github.com/guides/using-git-and-github-for-the-windows-for-newbies).

## Configuration

Your API Key, and site subdomain can be specified in your **web.config** or for testing **app.config** file:

    <?xml version="1.0" encoding="utf-8" ?>
    <configuration>
      <configSections>
        <section name="recurly" type="Recurly.Configuration.RecurlySection,Recurly"/>
      </configSections>      
      
      <recurly>
        <apps>
          <add name="instance1" apikey="apiKey1" privatekey="" subdomain="subdomain1"/>
          <add name="instance2" apikey="apiKey2" privatekey="" subdomain="subdomain2"/>
        </apps>
      </recurly>
    
    </configuration>

__Please note:__ API credentials changed with version v0.0.4.2. **API Username** and **Environment** are no longer required. **Password** has been renamed to **API Key**.

## To Do

* Write unit tests
* List/paginate through accounts, transactions, etc
* Process POST notifications
* Member variable validation
* Validate credit card information before submitting request


## API Documentation

Please see the [Recurly API](http://docs.recurly.com/api/basics/) for more information.