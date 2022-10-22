
using Microsoft.EntityFrameworkCore;
using PhoneBookCRUD.models;

namespace PhoneBookCRUD;

public class DatabaseContext : DbContext
{
    public DbSet<Contact> Contacts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        options.UseNpgsql("Server=localhost;Port=5432;Database=PhoneBook;User Id=user;Password=user");
    
}