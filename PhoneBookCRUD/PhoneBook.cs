
using Microsoft.EntityFrameworkCore;

namespace PhoneBookCRUD.models;

public class PhoneBook
{

    private static PhoneBook? _instance;
    private DatabaseContext _context = new();

    private PhoneBook()
    {
    }

    public static PhoneBook? GetInstance()
    {
        return _instance ??= new PhoneBook();
    }

    public async Task<List<Contact>> GetAllContacts()
    {
        return await _context.Contacts.OrderBy(contact => contact.Name).ToListAsync();
    }

    public async Task<bool> AddContact(Contact contact)
    {
        var contactDb = await _context.Contacts.SingleOrDefaultAsync(x => x.Name == contact.Name);
        if (contactDb != null) return false;
        _context.Contacts.Add(contact);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<Contact?> GetContactByName(string name)
    {
        return await _context.Contacts.SingleOrDefaultAsync(contact => contact.Name == name);
    }

    public async Task<Contact?> GetContactByPhone(string phone)
    {
        return await _context.Contacts.SingleOrDefaultAsync(contact => contact.Phone == phone);
    }

    public async Task<bool> DeleteContactByPhone(string phone)
    {
        var contactToDelete = GetContactByPhone(phone).Result;
        if (contactToDelete is null)
        {
            return false;
        }

        _context.Contacts.Remove(contactToDelete);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteContactByName(string name)
    {
        var contactToDelete = GetContactByName(name).Result;
        if (contactToDelete is null)
        {
            return false;
        }

        _context.Contacts.Remove(contactToDelete);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateNameContact(string newName, string phone)
    {
        var contactToUpdate = GetContactByPhone(phone).Result;
        if (contactToUpdate is null)
        {
            return false;
        }

        contactToUpdate.Name = newName;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdatePhoneContact(string name, string newPhone)
    {
        var contactToUpdate = GetContactByPhone(name).Result;
        if (contactToUpdate is null)
        {
            return false;
        }

        contactToUpdate.Phone = newPhone;
        await _context.SaveChangesAsync();
        return true;
    }

    public void PrintContacts()
    {
        var contacts = GetAllContacts().Result;
        for (int i = 0; i < contacts.Count; i++)
        {
            Console.WriteLine($"{i+1}. {contacts[i].Name}  -  {contacts[i].Phone}");
        }
    }

    public void PrintContact(Contact contact)
    {
        Console.WriteLine($"Name - {contact.Name}  Phone - {contact.Phone}");
    }


}