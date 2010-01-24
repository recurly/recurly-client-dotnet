Recurly PHP Client
==================

The Recurly .NET Client library is an open source library to interact with Recurly's subscription management from your ASP.Net website. The library interacts with Recurly's [REST API](http://support.recurly.com/faqs/api).

** This library is not complete and has not been fully tested. **

Please use this as a starting point for your .NET integration with Recurly.  If you made any improvements, please let us know and we will incorporate them into the main branch for everyone else.

Completed
---------

* API Authentication
* Reading and writing XML documents for requests and responses
* Error handling / strongly-typed exceptions
* And lots of the basics for creating and updating Recurly objects thru our REST API

To Do
-----

* Write unit tests
* Complete RecurlyInvoice class to look up invoice information
* Extend RecurlyAccount to return invoices, transactions, subscription status, etc
* Extend RecurlySubscription to cancel subscriptions
* Create RecurlyTransaction class for payment and refund information
* Add classes to read API credentials from web.config instead of static variables
* List/paginate through accounts, transactions, etc
* Process POST notifications
* Member variable validation
* Validate credit card information before submitting request


Installation
------------

If you already have git, the easiest way to download the Recurly .NET Client is with the git command:

    git clone git://github.com/recurly/recurly-client-net.git C:\path\to\recurly

If you do not have git, please check out the [Github Guide for Windows](http://github.com/guides/using-git-and-github-for-the-windows-for-newbies).


API Documentation
-----------------

Please see the [Recurly API](http://support.recurly.com/faqs/api/) for more information.