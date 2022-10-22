
using PhoneBookCRUD.models;


var phonebook = PhoneBook.GetInstance();
while (true)
{
    Console.Clear();
    Console.WriteLine("PHONEBOOK");
    phonebook!.PrintContacts();
    Console.WriteLine("------------------");
    Console.WriteLine("1. Add contact");
    Console.WriteLine("2. Delete contact");
    Console.WriteLine("3. Change contact");
    Console.WriteLine("4. Get a specific contact info");
    Console.WriteLine("0. Exit");
    var key = Console.ReadKey().Key;
    Console.Clear();
    switch (key)
    {
        case ConsoleKey.D1:
        {
            AddMethod(phonebook);
            break;
        }
        case ConsoleKey.D2:
        {
            DeleteMethod(phonebook);
            break;
        }
        case ConsoleKey.D3:
        {
            ChangeMethod(phonebook);
            break;
        }
        case ConsoleKey.D4:
        {
            GetMethod(phonebook);
            break;
        }
        case ConsoleKey.D0:
        {
            Environment.Exit(0);
            break;
        }
    }
}

static void AddMethod(PhoneBook phonebook)
{
    Console.WriteLine("\bEnter your name and phone number separated by a space");
    var tokens = Console.ReadLine()!.Split(" ");
    var result = phonebook.AddContact(new Contact()
        {Name = tokens[0], Phone = tokens[1]}).Result;
    Console.WriteLine(result ? "Contact successfully added" : "Contact with this name already exists");
    Console.ReadKey();
}

static void DeleteMethod(PhoneBook phonebook)
{
    Console.WriteLine("\bEnter the name or phone number of the contact being deleted");
    var token = Console.ReadLine()!;
    var resultByName = phonebook.DeleteContactByName(token).Result;
    if (resultByName) Console.WriteLine("Contact successfully deleted");
    else
    {
        var resultByPhone = phonebook.DeleteContactByPhone(token).Result;
        Console.WriteLine(resultByName ? "Contact successfully deleted" : "This contact does not exists");
    }
}

static void ChangeMethod(PhoneBook phonebook)
{
    Console.WriteLine("1.Change contact name");
    Console.WriteLine("2.Change contact phone");
    var key = Console.ReadKey().Key;
    switch (key)
    {
        case ConsoleKey.D1:
        {
            Console.WriteLine("\bEnter new name and phone separated by space");
            var tokens = Console.ReadLine()!.Split(" ");
            var result = phonebook.UpdateNameContact(tokens[0], tokens[1]).Result;
            Console.WriteLine(result ? "Name changed" : "Contact with this phone does not exists");
            Console.ReadKey();
            break;
        }
        case ConsoleKey.D2:
        {
            Console.WriteLine("\bEnter name and new phone separated by space");
            var tokens = Console.ReadLine()!.Split(" ");
            var result = phonebook.UpdatePhoneContact(tokens[0], tokens[1]).Result;
            Console.WriteLine(result ? "Phone changed" : "Contact with this name does not exists");
            Console.ReadKey();
            break;
        }
    }
}

static void GetMethod(PhoneBook phonebook)
{
    Console.WriteLine("1.Get contact by name");
    Console.WriteLine("2.Get contact by phone");
    var key = Console.ReadKey().Key;
    switch (key)
    {
        case ConsoleKey.D1:
        {
            Console.WriteLine("Enter name");
            var token = Console.ReadLine()!;
            var result = phonebook.GetContactByName(token).Result;
            if (result is null) Console.WriteLine("Contact with this name does not exist");
            else phonebook.PrintContact(result);
            Console.ReadKey();
            break;
        }
        case ConsoleKey.D2:
        {
            Console.WriteLine("Enter phone");
            var token = Console.ReadLine()!;
            var result = phonebook.GetContactByPhone(token).Result;
            if (result is null) Console.WriteLine("Contact with this phone does not exist");
            else phonebook.PrintContact(result);
            Console.ReadKey();
            break;
        }
    }
}