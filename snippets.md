#Accounts
##List Accounts
	var accounts = Accounts.List();
	while(accounts.Any())
	{
		foreach(var account in accounts)
			Console.WriteLine(account);
		accounts = accounts.Next;
	}

##Get Account
	try
	{
		var account = Accounts.Get("1");
		Console.WriteLine("Account " + account);
	}
	catch(NotFoundException e)
	{
		Console.WriteLine("Account not found.");
	}
**Please note**: the client library will raise an exception if the account is not found.

##Create Account
	var account = new Account("1")
	{
		Email = "verena@example.com",
		FirstName = "Verena",
		LastName = "Example"
	};
	account.Create();

##Close Account
	var account = Accounts.Get("1");
	account.Close();

##Reopen Account
	var account = Accounts.Get("1");
	account.Reopen();

##List Account Notes
	var account = Accounts.Get("1");
	var notes = account.GetNotes();
	while(notes.Any())
	{
		foreach(var note in notes)
			Console.WriteLine("Note: " + note.Message);
		notes = notes.Next;
	}