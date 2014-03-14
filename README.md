﻿# Recurly .NET Client

The Recurly .NET Client library is an open source library to interact with Recurly's subscription management from your ASP.Net website.
The library interacts with Recurly's [REST API](http://support.recurly.com/faqs/api).  This library works with .NET 2.0 and greater.

## Installation

The easiest way to get the source code is to click the **Download Source** button at the top of this page.  Alternatively, you can use git.
With git installed, the easiest way to download the Recurly .NET Client is with the git command:

    git clone git://github.com/recurly/recurly-client-net.git C:\path\to\recurly

If you do not have git and have some interest in learning about a wonderful source control tool, please check out the
[Github Guide for Windows](http://github.com/guides/using-git-and-github-for-the-windows-for-newbies).

## Configuration

Your API Key, and site subdomain can be specified in your **web.config** file:

    <?xml version="1.0" encoding="utf-8" ?>
    <configuration>
      <configSections>
        <section name="recurly" type="Recurly.Configuration.RecurlySection,Recurly"/>
      </configSections>
      
      <recurly 
        apiKey="123456789012345678901234567890ab"
        privateKey="123456789012345678901234567890cd"
        subdomain="company" />
      
    </configuration>

__Please note:__ API credentials changed with version v0.0.4.2. **API Username** and **Environment** are no longer required. **Password** has been renamed to **API Key**.

## API Documentation

Please see the [Recurly API](http://docs.recurly.com/api/basics/) for more information.

## Support

- [https://support.recurly.com](https://support.recurly.com)
- [stackoverflow](http://stackoverflow.com/questions/tagged/recurly)

## Announcements

- [@recurly](https://twitter.com/recurly)
- [Google Group Announcements](https://groups.google.com/group/recurly-api)
